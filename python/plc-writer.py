# Connect to default localhost:5672 with queue name 'plc_writer_queue'
# python plc-writer.py -q plc_writer_queue

import json
import pika
import sys
import argparse
from datetime import datetime

def process_message(ch, method, properties, body):
    """Process received message"""
    data = json.loads(body.decode('utf-8'))
    
    # Parse values into separate variables
    blower5_delta = data.get("PlantDO.PLCB.Blower5.VanePositionDeltaMAX")
    blower5_min = data.get("PlantDO.PLCB.Blower5.VanePositionMIN")
    blower5_max = data.get("PlantDO.PLCB.Blower5.VanePositionMAX")
    
    blower6_delta = data.get("PlantDO.PLCB.Blower6.VanePositionDeltaMAX")
    blower6_min = data.get("PlantDO.PLCB.Blower6.VanePositionMIN")
    blower6_max = data.get("PlantDO.PLCB.Blower6.VanePositionMAX")
    
    blower7_delta = data.get("PlantDO.PLCB.Blower7.VanePositionDeltaMAX")
    blower7_min = data.get("PlantDO.PLCB.Blower7.VanePositionMIN")
    blower7_max = data.get("PlantDO.PLCB.Blower7.VanePositionMAX")
    
    blower8_delta = data.get("PlantDO.PLCB.Blower8.VanePositionDeltaMAX")
    blower8_min = data.get("PlantDO.PLCB.Blower8.VanePositionMIN")
    blower8_max = data.get("PlantDO.PLCB.Blower8.VanePositionMAX")
    
    pressure_delta = data.get("PlantDO.PLCB.Common.PressureDeltaMAX")
    pressure_min = data.get("PlantDO.PLCB.Common.PressureMIN")
    pressure_max = data.get("PlantDO.PLCB.Common.PressureMAX")
    
    # Format values to 2 decimal places
    blower5_delta = f"{blower5_delta:.2f}" if blower5_delta is not None else "N/A"
    blower5_min = f"{blower5_min:.2f}" if blower5_min is not None else "N/A"
    blower5_max = f"{blower5_max:.2f}" if blower5_max is not None else "N/A"
    
    blower6_delta = f"{blower6_delta:.2f}" if blower6_delta is not None else "N/A"
    blower6_min = f"{blower6_min:.2f}" if blower6_min is not None else "N/A"
    blower6_max = f"{blower6_max:.2f}" if blower6_max is not None else "N/A"
    
    blower7_delta = f"{blower7_delta:.2f}" if blower7_delta is not None else "N/A"
    blower7_min = f"{blower7_min:.2f}" if blower7_min is not None else "N/A"
    blower7_max = f"{blower7_max:.2f}" if blower7_max is not None else "N/A"
    
    blower8_delta = f"{blower8_delta:.2f}" if blower8_delta is not None else "N/A"
    blower8_min = f"{blower8_min:.2f}" if blower8_min is not None else "N/A"
    blower8_max = f"{blower8_max:.2f}" if blower8_max is not None else "N/A"
    
    pressure_delta = f"{pressure_delta:.2f}" if pressure_delta is not None else "N/A"
    pressure_min = f"{pressure_min:.2f}" if pressure_min is not None else "N/A"
    pressure_max = f"{pressure_max:.2f}" if pressure_max is not None else "N/A"
    
    # Get current timestamp in HH:MM:SS format
    current_time = datetime.now().strftime("%H:%M:%S")
    
    # Use the received data (example)
    print("#" * 40)
    print(f"[{current_time}] - BL5: Delta={blower5_delta}, Min={blower5_min}, Max={blower5_max}")
    print(f"[{current_time}] - BL6: Delta={blower6_delta}, Min={blower6_min}, Max={blower6_max}")
    print(f"[{current_time}] - BL7: Delta={blower7_delta}, Min={blower7_min}, Max={blower7_max}")
    print(f"[{current_time}] - BL8: Delta={blower8_delta}, Min={blower8_min}, Max={blower8_max}")
    print(f"[{current_time}] - CMN: Delta={pressure_delta}, Min={pressure_min}, Max={pressure_max}")    
    
    # Acknowledge receipt
    ch.basic_ack(delivery_tag=method.delivery_tag)


def main():
    # Parse command line arguments
    parser = argparse.ArgumentParser(description='RabbitMQ consumer for PLC data')
    parser.add_argument('-q', '--queue', 
                        type=str, 
                        required=True,
                        help='Queue name to consume messages from')
    parser.add_argument('-H', '--host', 
                        type=str, 
                        default='localhost',
                        help='RabbitMQ host (default: localhost)')
    parser.add_argument('-p', '--port', 
                        type=int, 
                        default=5672,
                        help='RabbitMQ port (default: 5672)')
    
    args = parser.parse_args()
    
    connection = None
    channel = None
    
    try:
        # Connect to RabbitMQ
        connection = pika.BlockingConnection(
            pika.ConnectionParameters(host=args.host, port=args.port)
        )
        channel = connection.channel()
        
        # Declare queue
        queue_name = args.queue
        channel.queue_declare(queue=queue_name, durable=True)
        
        # Configure consumption
        channel.basic_qos(prefetch_count=1)
        channel.basic_consume(queue=queue_name, on_message_callback=process_message)
        
        print(f"Waiting for messages from queue '{queue_name}'...")
        print(f"RabbitMQ host: {args.host}:{args.port}")
        print("Press Ctrl+C to stop\n")
        
        channel.start_consuming()
        
    except KeyboardInterrupt:
        print("\n\nProgram stopped by user (Ctrl+C)")
    except Exception as e:
        print(f"\nError: {e}")
    finally:
        # Properly close the connection
        if channel and channel.is_open:
            try:
                channel.stop_consuming()
                print("Stopping consumption...")
            except:
                pass
        
        if connection and connection.is_open:
            connection.close()
            print("Connection closed")
        
        print("Exiting program")


if __name__ == "__main__":
    main()