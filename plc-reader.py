import logging
import threading
import time

import pylogix as pl

class PLCReader:
    def __init__(self, tags):        
        self._stop_event = threading.Event();        
        self._thread = None
        self._tags = tags
        
        
        # Logger configuration
        logging.basicConfig(filename='logger-example.log',
                    level=logging.INFO,
                    format="%(asctime)s: %(levelname)s - %(message)s",
                    datefmt='%Y-%m-%d %H:%M:%S')
             
        self._logger = logging.getLogger(__name__)
        
    def do_action(self):
        #####################################################
        # PLC reader action
        with pl.PLC() as plc:
            plc.IPAddress = '192.142.0.11'
            results = plc.Read(self._tags)
            
            values = []
            for result in results:
                #if result.Status == 'Success':
                #    success_counter = success_counter + 1                
                #self._logger.info(f"{result.TagName} : {result.Value} STATUS: {result.Status}")
                #if result.Status == 'Success':
                #    values.append(f'{result.Value:0.2f}')
                if result.Value is not None:
                    values.append(f'{result.Value:0.2f}')
                else:
                    values.append('NONE')
            
            str_values = ';'.join(values)
            current_time = time.strftime('%H:%M:%S')            
            self._logger.info(f'{current_time}\t{str_values}')
            print(f'{current_time}: {int(time.time())}')
        #####################################################
        
    def start(self, interval = 5):
        
        def worker():
            while not self._stop_event.is_set():
                self.do_action()
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
    
    tags = [] # Empty tag list
    file_name = 'full-tag-list.txt'
    # file_name = 'tank-3-tag-list.txt'
    with open(file_name, 'r', encoding='utf-8') as file:
        tags = [line.strip() for line in file]
    
    time_interval = 60*60*24 # 24 hrs.
    # time_interval = 60*5 # 5 min.
        
    plcreader = PLCReader(tags)    
    plcreader.start(interval=1) # One time per 1 sec.    
    
    plcreader._logger.info(f'PyLogix version: {pl.__version__}')
    plcreader._logger.info(f'OPC tags: {len(tags)}')
    plcreader._logger.info(f'Time interval: {time_interval}')
    
    try:
        
        # while True:
        time.sleep(time_interval)
        plcreader._logger.info('Timer interrupt ...')
        print("\nTimer interrupt ...")
    except KeyboardInterrupt:
        plcreader._logger.info('Keyboard interrupt ...')
        print("\nKeyboard interrupt ...")
    finally:
        plcreader.stop()