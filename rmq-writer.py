import json
import pika
import time
import logging
import random

from datetime import datetime
from rmqhelper import RabbitMQProducer

if __name__ == "__main__":
    try:
        producer = RabbitMQProducer (
            host = 'localhost',
            port = 5672,
            username = 'guest',
            password = 'guest'
        )
        
        if producer.connect():
            producer.declare_queue('plc_read_queue')
            
        while True:            
            user_data = {
            "Pressure": round(random.uniform(0.5, 15.0), 2),
            "Temperature": round(random.uniform(15.0, 35.0), 1),
            "TimeStamp": int(time.time())
            }            
            time.sleep(0.5)
            producer.send_dict(user_data, 'plc_read_queue')
    
    except KeyboardInterrupt:
        producer.close()
        print("\n\nОстановлено пользователем")
    except Exception as e:
        print(f"\nКритическая ошибка: {e}")