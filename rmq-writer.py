import json
import pika
import time
import logging
import random

from datetime import datetime


class RabbitMQProducer:
    def __init__(self, host = 'localhost', port = 5672, username = 'guest', password = 'guest'):
        """
        Инициализация подключения к RabbitMQ
        """
        self.connection_params = pika.ConnectionParameters (
            host = host,
            port = port,
            credentials = pika.PlainCredentials (
                username = username, 
                password = password
            ),
            # Таймауты для надежности
            heartbeat = 600,
            blocked_connection_timeout = 300
        )
        self.connection = None
        self.channel = None
        
    def connect(self):
        try:
            self.connection = pika.BlockingConnection(self.connection_params)
            self.channel = self.connection.channel()
            print(f"Подключено к RabbitMQ на {self.connection_params.host}:{self.connection_params.port}")
            return True
        except Exception as e:
            print(f"Ошибка подключения: {e}")
            return False
        
    def declare_queue(self, queue_name = 'plc_read_queue', durable = True):
        """
        Объявление очереди
        durable=True - очередь сохранится после перезагрузки RabbitMQ
        """
        try:
            self.channel.queue_declare (
                queue = queue_name,
                durable = durable,  # Сохранять сообщения при перезапуске
                arguments = {
                    'x-message-ttl': 86400000  # TTL 24 часа (необязательно)
                }
            )
            print(f"Очередь '{queue_name}' объявлена")
            return True
        except Exception as e:
            print(f"Ошибка объявления очереди: {e}")
            return False
        
    def close(self):
        if self.connection and not self.connection.is_closed:
            self.connection.close()
            print("Соединение закрыто")
    
    def __enter__(self):
        self.connect()
        return self
    
    def __exit__(self, exc_type, exc_val, exc_tb):
        self.close()
        
    def send_dict(self, data_dict, queue_name='plc_read_queue', exchange = '', priority = 0, headers = None):
        """
        Отправка словаря в очередь
        
        Args:
            data_dict: словарь для отправки
            queue_name: имя очереди
            exchange: имя exchange (пустая строка для default exchange)
            priority: приоритет сообщения (0-255)
            headers: дополнительные заголовки
        """
        if not isinstance(data_dict, dict):
            raise ValueError("data_dict должен быть словарем")
        
        # Преобразуем словарь в JSON
        message_body = json.dumps(data_dict, ensure_ascii = False)        
        
        # Создаем свойства сообщения
        properties = pika.BasicProperties (
            delivery_mode = 2,  # Сохранять сообщение на диске (persistent)
            content_type = 'application/json',
            content_encoding = 'utf-8',
            priority = priority,
            headers = headers or {},
            timestamp = int(time.time())  # Временная метка
        )
        
        try:
            # Публикуем сообщение
            self.channel.basic_publish (
                exchange = exchange,
                routing_key = queue_name,
                body = message_body,
                properties = properties,
                mandatory = True  # Гарантировать доставку
            )
            
            #print(f"\n")
            #print(f"Отправлено в очередь '{queue_name}':")
            #print(f"Размер: {len(message_body)} байт")
            #print(f"Время: {datetime.now().strftime('%H:%M:%S')}")
            #print(f"Данные: {message_body}")
            print(f"{message_body}")
            return True
            
        except Exception as e:
            print(f"Ошибка отправки: {e}")
            return False


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