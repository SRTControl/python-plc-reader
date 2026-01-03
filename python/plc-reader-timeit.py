import logging
import threading
import time
import timeit

from rmqhelper import RabbitMQProducer
from enum import Enum

import pylogix as pl

class PLCReadMode(Enum):
    FULL = 1    # Read FULL tag list
    DIFF = 2    # Read DIFF tag list

class PLCReader:
    '''
    The PLCReader class is used for direct access to PLC for reading and writing tags.
    
    Attributes:
        _tags (list): List of tags
        _logger: Class logger
        _plcstate (dict): PLC current state {TAGName, TAGValue} or {TAGID, TAGValue}
        
    Methods:
        start (int): Start the PLCReader
        stop(): Stop the PLCReader
    '''
    def __init__(self, tags, plc_read_mode, full_read_interval=300):        
        # Self configuration
        self._stop_event = threading.Event();        
        self._thread = None
        self._tags = tags
        self._tags_diff = tags
        self._plc_readmode = plc_read_mode
        self._plc_state = {}
        self._producer = None
        self._plc_fullread_interval = full_read_interval
        self._plc_fullread_timestemp = int(time.time())
        
        self._plc = pl.PLC()
        self._plc.IPAddress = '192.142.0.11'
        self._plc.SocketTimeout = 2
                
        # Logger configuration
        logging.basicConfig(filename='logger-example.log',
                    level=logging.DEBUG,
                    format="%(asctime)s: %(levelname)s - %(message)s",
                    datefmt='%Y-%m-%d %H:%M:%S')             
        self._logger = logging.getLogger(__name__)
        
        # Reduce log level for pika
        logging.getLogger("pika").setLevel(logging.WARNING)
        # Disable propagation for pika
        logging.getLogger("pika").propagate = False
        
    def read_plc(self):
        #####################################################
        # PLC reader action
        startReadTheTags = timeit.default_timer()
        if self._plc_readmode == PLCReadMode.FULL:
            results = self._plc.Read(self._tags) # Read ALL tags
        elif self._plc_readmode == PLCReadMode.OFTEN:
            if int(time.time()) - self._plc_fullread_timestemp >= self._plc_fullread_interval:
                self._plc_fullread_timestemp = int(time.time())
                results = self._plc.Read(self._tags) # Read ALL tags
            else:
                results = self._plc.Read(self._tags_diff) # Read DIFF tags
        endReadTheTags = timeit.default_timer()            
        
        startPLCBuffer = timeit.default_timer()            
        plc_buff = {} # Temporary PLC buffer
        for result in results:
            if result.Status == 'Success':
                if result.Value is not None:
                    plc_buff[result.TagName] = f'{result.Value:0.2f}'
                else:
                    plc_buff[result.TagName] = 'NONE'
        endPLCBuffer = timeit.default_timer()
        
        startNewValues = timeit.default_timer()
        # The dictionary with the new values only
        plc_diff = {k: v for k, v in plc_buff.items() if k not in self._plc_state or self._plc_state[k] != v}
        if len(plc_diff) > 0:
            self._plc_state.update(plc_diff)
            self._tags_diff = list(plc_diff.keys()) # Save the DIFF tags list
        endNewValues = timeit.default_timer()
        
        hhmm_time = time.strftime('%H:%M:%S')
        unix_time = int(time.time())
        
        startMapping = timeit.default_timer()
        # Mapping PLC to the Plant structure
        plant_data = {
                'TimeStamp': unix_time,
                'Common': {
                    'AirTemperatureReadings': self._plc_state.get('Common.AirTemperatureReadings', 0),
                    'IsDOmasterInOperation': int(float(self._plc_state.get('Common.IsDOmasterInOperation', 0))),
                    'PressureReadings': self._plc_state.get('Common.PressureReadings', 0),
                    'RainGaugeReadings': self._plc_state.get('Common.RainGaugeReadings', 0),
                    'WaterTemperatureReadings': self._plc_state.get('Common.WaterTemperatureReadings', 0),
                    'pHReadings_1': self._plc_state.get('Common.pHReadings_1', 0),
                    'pHReadings_2': self._plc_state.get('Common.pHReadings_2', 0),
                    'pHReadings_3': self._plc_state.get('Common.pHReadings_3', 0)
                },
                'Blower7': {
                    'InOperation': int(float(self._plc_state.get('Blower7.InOperation', 0))),
                    'Power': self._plc_state.get('Blower7.Power', 0),
                    'StartStopSignal': int(float(self._plc_state.get('Blower7.StartStopSignal', 0))),
                    'VanePositionReadings': self._plc_state.get('Blower7.VanePositionReadings', 0),
                    'VanePositionSetPoint': self._plc_state.get('Blower7.VanePositionSetPoint', 0)
                    },
                'Blower8': {
                    'InOperation': int(float(self._plc_state.get('Blower8.InOperation', 0))),
                    'Power': self._plc_state.get('Blower8.Power', 0),
                    'StartStopSignal': int(float(self._plc_state.get('Blower8.StartStopSignal', 0))),
                    'VanePositionReadings': self._plc_state.get('Blower8.VanePositionReadings', 0),
                    'VanePositionSetPoint': self._plc_state.get('Blower8.VanePositionSetPoint', 0)
                    },
                'Tank3': {
                    'HydraulicFlow': {
                        'MeterReadings': self._plc_state.get('Tank3.HydraulicFlow.MeterReadings', 0)
                    },
                    'Airflow': {
                        'MeterReadings': self._plc_state.get('Tank3.Airflow.MeterReadings', 0),
                        'SetPoint': self._plc_state.get('Tank3.Airflow.SetPoint', 0),
                        'ValvePositionReadings': self._plc_state.get('Tank3.Airflow.ValvePositionReadings', 0),
                        'ValvePositionSetPoint': self._plc_state.get('Tank3.Airflow.ValvePositionSetPoint', 0)
                    },
                    'Grid3': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid3.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid3.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank3.Grid3.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank3.Grid3.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid3.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid3.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid3.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid3.NH3.SetPoint', 0)
                        }
                    },
                    'Grid4': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid4.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid4.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank3.Grid4.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank3.Grid4.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid4.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid4.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid4.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid4.NH3.SetPoint', 0)
                        }
                    },
                    'Grid5': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid5.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid5.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank3.Grid5.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank3.Grid5.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid5.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid5.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid5.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid5.NH3.SetPoint', 0)
                        }
                    },
                    'Grid6': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid6.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid6.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank3.Grid6.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank3.Grid6.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid6.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid6.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid6.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid6.NH3.SetPoint', 0)
                        }
                    },
                    'Grid7': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid7.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid7.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank3.Grid7.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank3.Grid7.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid7.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid7.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank3.Grid7.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank3.Grid7.NH3.SetPoint', 0)
                        }
                    }                    
                },
                'Tank4': {
                    'HydraulicFlow': {
                        'MeterReadings': self._plc_state.get('Tank4.HydraulicFlow.MeterReadings', 0)
                    },
                    'Airflow': {
                        'MeterReadings': self._plc_state.get('Tank4.Airflow.MeterReadings', 0),
                        'SetPoint': self._plc_state.get('Tank4.Airflow.SetPoint', 0),
                        'ValvePositionReadings': self._plc_state.get('Tank4.Airflow.ValvePositionReadings', 0),
                        'ValvePositionSetPoint': self._plc_state.get('Tank4.Airflow.ValvePositionSetPoint', 0)
                    },
                    'Grid3': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid3.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid3.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank4.Grid3.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank4.Grid3.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid3.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid3.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid3.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid3.NH3.SetPoint', 0)
                        }
                    },
                    'Grid4': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid4.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid4.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank4.Grid4.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank4.Grid4.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid4.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid4.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid4.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid4.NH3.SetPoint', 0)
                        }
                    },
                    'Grid5': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid5.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid5.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank4.Grid5.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank4.Grid5.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid5.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid5.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid5.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid5.NH3.SetPoint', 0)
                        }
                    },
                    'Grid6': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid6.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid6.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank4.Grid6.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank4.Grid6.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid6.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid6.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid6.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid6.NH3.SetPoint', 0)
                        }
                    },
                    'Grid7': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid7.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid7.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank4.Grid7.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank4.Grid7.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid7.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid7.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank4.Grid7.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank4.Grid7.NH3.SetPoint', 0)
                        }
                    }                    
                },
                'Tank5': {
                    'HydraulicFlow': {
                        'MeterReadings': self._plc_state.get('Tank5.HydraulicFlow.MeterReadings', 0)
                    },
                    'Airflow': {
                        'MeterReadings': self._plc_state.get('Tank5.Airflow.MeterReadings', 0),
                        'SetPoint': self._plc_state.get('Tank5.Airflow.SetPoint', 0),
                        'ValvePositionReadings': self._plc_state.get('Tank5.Airflow.ValvePositionReadings', 0),
                        'ValvePositionSetPoint': self._plc_state.get('Tank5.Airflow.ValvePositionSetPoint', 0)
                    },
                    'Grid3': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid3.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid3.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank5.Grid3.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank5.Grid3.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid3.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid3.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid3.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid3.NH3.SetPoint', 0)
                        }
                    },
                    'Grid4': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid4.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid4.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank5.Grid4.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank5.Grid4.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid4.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid4.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid4.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid4.NH3.SetPoint', 0)
                        }
                    },
                    'Grid5': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid5.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid5.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank5.Grid5.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank5.Grid5.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid5.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid5.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid5.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid5.NH3.SetPoint', 0)
                        }
                    },
                    'Grid6': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid6.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid6.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank5.Grid6.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank5.Grid6.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid6.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid6.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid6.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid6.NH3.SetPoint', 0)
                        }
                    },
                    'Grid7': {
                        'Airflow': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid7.Airflow.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid7.Airflow.SetPoint', 0),
                            'ValvePositionReadings': self._plc_state.get('Tank5.Grid7.Airflow.ValvePositionReadings', 0),
                            'ValvePositionSetPoint': self._plc_state.get('Tank5.Grid7.Airflow.ValvePositionSetPoint', 0)
                        },
                        'DO': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid7.DO.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid7.DO.SetPoint', 0)
                        },
                        'NH3': {
                            'MeterReadings': self._plc_state.get('Tank5.Grid7.NH3.MeterReadings', 0),
                            'SetPoint': self._plc_state.get('Tank5.Grid7.NH3.SetPoint', 0)
                        }
                    }                    
                }
            }
        endMapping = timeit.default_timer()
        
        startRabbitMQ = timeit.default_timer()
        # Sending the data to RabbitMQ
        self._producer.send_dict(plant_data, 'plc_read_queue')            
        endRabbitMQ = timeit.default_timer()
        
        print(f'{hhmm_time}: {len(self._plc_state)}/{len(results)};\tT: {endReadTheTags - startReadTheTags:.6f}; B: {endPLCBuffer - startPLCBuffer:.6f}; N: {endNewValues - startNewValues:.6f}; M: {endMapping - startMapping:.6f}; R: {endRabbitMQ - startRabbitMQ:.6f}')
        # logger is disabled to save the time...
        # self._logger.info(f'{hhmm_time}: {len(self._plc_state)}/{len(plc_diff)}')
        #####################################################
        
    def start(self, interval = 5):
        
        # RabbitMQ initialization
        self._producer = RabbitMQProducer (
            host = 'localhost',
            port = 5672,
            username = 'guest',
            password = 'guest'
        )
        # Opent the RabbitMQ connection
        if self._producer.connect():
            self._producer.declare_queue('plc_read_queue')
        
        def worker():
            while not self._stop_event.is_set():
                self.read_plc()
                self._stop_event.wait(interval)
        
        self._logger.warning('PLCReader started')
        self._thread = threading.Thread(target=worker, daemon=True)        
        self._thread.start()
        
        
    def stop(self):
        # Close the RabbitMQ connection
        self._producer.close()
        
        self._stop_event.set()
        if self._thread:
            self._thread.join(timeout=5)
        self._logger.warning('PLCReader stopped')


if __name__ == '__main__':
    
    # Read the tag list from the source file
    tags = [] # Empty tag list
    file_name = 'full-tag-list.txt' # Full tags list
    # file_name = 'tank-3-tag-list.txt' # Lite tags list
    with open(file_name, 'r', encoding='utf-8') as file:
        tags = [line.strip() for line in file]
    
    time_interval = 60*60*24 # 24 hrs.
        
    plcreader = PLCReader(tags, PLCReadMode.FULL)
    plcreader.start(interval=1) # One time per 1 sec.
    
    # Debug information
    plcreader._logger.info(f'PyLogix version: {pl.__version__}')
    plcreader._logger.info(f'OPC tags: {len(tags)}')
    plcreader._logger.info(f'Time interval: {time_interval}')
    
    try:
        while True:
            ...
        
        time.sleep(time_interval)
        plcreader._logger.info('Timer interrupt ...')
        print("\nTimer interrupt ...")
    except KeyboardInterrupt:
        plcreader._logger.info('Keyboard interrupt ...')
        print("\nKeyboard interrupt ...")
    finally:
        plcreader.stop()