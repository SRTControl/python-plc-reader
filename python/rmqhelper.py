import json
import pika
import time

class RabbitMQProducer:
    def __init__(self, host = 'localhost', port = 5672, username = 'guest', password = 'guest'):
        """
        Initializing a connection to RabbitMQ
        """
        self.connection_params = pika.ConnectionParameters (
            host = host,
            port = port,
            credentials = pika.PlainCredentials (
                username = username, 
                password = password
            ),
            # Timeouts
            heartbeat = 600,
            blocked_connection_timeout = 300
        )
        self.connection = None
        self.channel = None
        
    def connect(self):
        try:
            self.connection = pika.BlockingConnection(self.connection_params)
            self.channel = self.connection.channel()
            print(f"Connected to RabbitMQ {self.connection_params.host}:{self.connection_params.port}")
            return True
        except Exception as e:
            print(f"Connection error: {e}")
            return False
        
    def declare_queue(self, queue_name = 'plc_read_queue', durable = True):
        """
        Declaring a queue
        durable=True - The queue will survive a RabbitMQ broker restart
        """
        try:
            self.channel.queue_declare (
                queue = queue_name,
                durable = durable,  # Persist messages across restarts
                arguments = {
                    'x-message-ttl': 86400000  # TTL 24 hrs
                }
            )
            print(f"Queue '{queue_name}' declared")
            return True
        except Exception as e:
            print(f"Queue declaration error: {e}")
            return False
        
    def close(self):
        if self.connection and not self.connection.is_closed:
            self.connection.close()
            print("Connection closed")
    
    def __enter__(self):
        self.connect()
        return self
    
    def __exit__(self, exc_type, exc_val, exc_tb):
        self.close()
        
    def send_dict(self, data_dict, queue_name='plc_control_queue', exchange = '', priority = 0, headers = None):
        """
        Sending a dictionary to the queue
        
        Args:
            data_dict: Dictionary to send
            queue_name: Name of the queue
            exchange: Exchange name (empty string for default exchange)
            priority: Message priority (0-255)
            headers: Additional headers
        """
        if not isinstance(data_dict, dict):
            raise ValueError("data_dict must be a dictionary")
        
        # Converting the dictionary to JSON
        message_body = json.dumps(data_dict, ensure_ascii = False)        
        
        # Creating message properties
        properties = pika.BasicProperties (
            delivery_mode = 2,  # Save the message to disk (persistent)
            content_type = 'application/json',
            content_encoding = 'utf-8',
            priority = priority,
            headers = headers or {},
            timestamp = int(time.time())  # The timestamp
        )
        
        try:
            # Publishing the message
            self.channel.basic_publish (
                exchange = exchange,
                routing_key = queue_name,
                body = message_body,
                properties = properties,
                mandatory = True  # Guarantee delivery
            )
                        
            return True
            
        except Exception as e:
            print(f"Message sending error: {e}")
            return False