import logging
import threading
import time

import pylogix as pl

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
    def __init__(self, tags):        
        # Self configuration
        self._stop_event = threading.Event();        
        self._thread = None
        self._tags = tags
        self._plc_state = {}
                
        # Logger configuration
        logging.basicConfig(filename='logger-example.log',
                    level=logging.INFO,
                    format="%(asctime)s: %(levelname)s - %(message)s",
                    datefmt='%Y-%m-%d %H:%M:%S')             
        self._logger = logging.getLogger(__name__)
        
    def read_plc(self):
        #####################################################
        # PLC reader action
        with pl.PLC() as plc:
            plc.IPAddress = '192.142.0.11' # PLC IP address
            results = plc.Read(self._tags) # Read the tags
            
            plc_buff = {} # Temporary PLC buffer
            for result in results:                
                if result.Status == 'Success':
                    if result.Value is not None:
                        plc_buff[result.TagName] = f'{result.Value:0.2f}'
                    else:
                        plc_buff[result.TagName] = 'NONE'
            
            # The dictionary with the new values only            
            plc_diff = {k: v for k, v in plc_buff.items() 
                       if k not in self._plc_state or self._plc_state[k] != v}
            
            if len(plc_diff) > 0:
                self._plc_state.update(plc_diff)
            
            hhmm_time = time.strftime('%H:%M:%S')
            unix_time = int(time.time())
            
            self._logger.info(f'{hhmm_time}: {len(self._plc_state)}/{len(plc_diff)}')
        #####################################################
        
    def start(self, interval = 5):
        
        def worker():
            while not self._stop_event.is_set():
                self.read_plc()
                self._stop_event.wait(interval)
        
        self._logger.warning('PLCReader started')
        self._thread = threading.Thread(target=worker, daemon=True)        
        self._thread.start()
        
        
    def stop(self):
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
    time_interval = 60*5 # 5 min.
        
    plcreader = PLCReader(tags)    
    plcreader.start(interval=1) # One time per 1 sec.
    
    # Debug information
    plcreader._logger.info(f'PyLogix version: {pl.__version__}')
    plcreader._logger.info(f'OPC tags: {len(tags)}')
    plcreader._logger.info(f'Time interval: {time_interval}')
    
    try:
        time.sleep(time_interval)
        plcreader._logger.info('Timer interrupt ...')
        print("\nTimer interrupt ...")
    except KeyboardInterrupt:
        plcreader._logger.info('Keyboard interrupt ...')
        print("\nKeyboard interrupt ...")
    finally:
        plcreader.stop()