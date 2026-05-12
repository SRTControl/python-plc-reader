# Connect to default localhost:5672 with queue name 'plc_writer_queue'
# python plc-writer.py -q plc_writer_queue

import json
import pika
import sys
import argparse
from datetime import datetime
import pylogix as pl

# Global PLC object
plc_client = None

def write_to_plc(tag_name, value):
    """Write a single value to PLC using global connection"""
    global plc_client
    
    if plc_client is None:
        print(f"ERROR: PLC not connected")
        return False
    
    try:
        # Write value to PLC tag
        result = plc_client.Write(tag_name, float(value))
        
        if result.Status == 'Success':
            return True
        else:
            print(f"Failed to write {tag_name}: {result.Status}")
            return False
    except Exception as e:
        print(f"Error writing to PLC: {e}")
        return False

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
    
    # Format values to 2 decimal places for display
    blower5_delta_display = f"{blower5_delta:.2f}" if blower5_delta is not None else "N/A"
    blower5_min_display = f"{blower5_min:.2f}" if blower5_min is not None else "N/A"
    blower5_max_display = f"{blower5_max:.2f}" if blower5_max is not None else "N/A"
    
    blower6_delta_display = f"{blower6_delta:.2f}" if blower6_delta is not None else "N/A"
    blower6_min_display = f"{blower6_min:.2f}" if blower6_min is not None else "N/A"
    blower6_max_display = f"{blower6_max:.2f}" if blower6_max is not None else "N/A"
    
    blower7_delta_display = f"{blower7_delta:.2f}" if blower7_delta is not None else "N/A"
    blower7_min_display = f"{blower7_min:.2f}" if blower7_min is not None else "N/A"
    blower7_max_display = f"{blower7_max:.2f}" if blower7_max is not None else "N/A"
    
    blower8_delta_display = f"{blower8_delta:.2f}" if blower8_delta is not None else "N/A"
    blower8_min_display = f"{blower8_min:.2f}" if blower8_min is not None else "N/A"
    blower8_max_display = f"{blower8_max:.2f}" if blower8_max is not None else "N/A"
    
    pressure_delta_display = f"{pressure_delta:.2f}" if pressure_delta is not None else "N/A"
    pressure_min_display = f"{pressure_min:.2f}" if pressure_min is not None else "N/A"
    pressure_max_display = f"{pressure_max:.2f}" if pressure_max is not None else "N/A"
    
    # Get current timestamp in HH:MM:SS format
    current_time = datetime.now().strftime("%H:%M:%S")
    
    # Display received data
    print("#" * 40)
    print(f"[{current_time}] - BL5: Delta={blower5_delta_display}, Min={blower5_min_display}, Max={blower5_max_display}")
    print(f"[{current_time}] - BL6: Delta={blower6_delta_display}, Min={blower6_min_display}, Max={blower6_max_display}")
    print(f"[{current_time}] - BL7: Delta={blower7_delta_display}, Min={blower7_min_display}, Max={blower7_max_display}")
    print(f"[{current_time}] - BL8: Delta={blower8_delta_display}, Min={blower8_min_display}, Max={blower8_max_display}")
    print(f"[{current_time}] - CMN: Delta={pressure_delta_display}, Min={pressure_min_display}, Max={pressure_max_display}")
    
    # Write data to PLC
    print(f"\n[{current_time}] Writing to PLC...")
    
    # Map PlantDO tags to PLC tags (adjust these mappings as needed)
    plc_writes = []
    
    if blower5_delta is not None:
        plc_writes.append(("Blower5.VanePositionDeltaMAX", blower5_delta))
    if blower5_min is not None:
        plc_writes.append(("Blower5.VanePositionMIN", blower5_min))
    if blower5_max is not None:
        plc_writes.append(("Blower5.VanePositionMAX", blower5_max))
    
    if blower6_delta is not None:
        plc_writes.append(("Blower6.VanePositionDeltaMAX", blower6_delta))
    if blower6_min is not None:
        plc_writes.append(("Blower6.VanePositionMIN", blower6_min))
    if blower6_max is not None:
        plc_writes.append(("Blower6.VanePositionMAX", blower6_max))
    
    if blower7_delta is not None:
        plc_writes.append(("Blower7.VanePositionDeltaMAX", blower7_delta))
    if blower7_min is not None:
        plc_writes.append(("Blower7.VanePositionMIN", blower7_min))
    if blower7_max is not None:
        plc_writes.append(("Blower7.VanePositionMAX", blower7_max))
    
    if blower8_delta is not None:
        plc_writes.append(("Blower8.VanePositionDeltaMAX", blower8_delta))
    if blower8_min is not None:
        plc_writes.append(("Blower8.VanePositionMIN", blower8_min))
    if blower8_max is not None:
        plc_writes.append(("Blower8.VanePositionMAX", blower8_max))
    
    if pressure_delta is not None:
        plc_writes.append(("Common.PressureDeltaMAX", pressure_delta))
    if pressure_min is not None:
        plc_writes.append(("Common.PressureMIN", pressure_min))
    if pressure_max is not None:
        plc_writes.append(("Common.PressureMAX", pressure_max))
    
    # Write all values to PLC using the persistent connection
    if plc_writes:
        try:
            print(f"Writing {len(plc_writes)} values to PLC...")
            
            for tag_name, value in plc_writes:
                if write_to_plc(tag_name, value):
                    print(f"SUCCESS: {tag_name} = {value:.2f}")
                else:
                    print(f"FAILED : {tag_name}")
            
            print("PLC write operations completed")
            
        except Exception as e:
            print(f"Error writing to PLC: {e}")
    else:
        print("No valid values to write to PLC")
    
    print("-" * 40)
    
    # Acknowledge receipt
    ch.basic_ack(delivery_tag=method.delivery_tag)


def main():
    global plc_client
    
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
        # Initialize PLC connection once at startup
        print(f"Connecting to PLC at 192.142.0.11...")
        plc_client = pl.PLC()
        plc_client.IPAddress = '192.142.0.11'
        plc_client.SocketTimeout = 2
        print("PLC connection established successfully")
        
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
        
        print(f"\nWaiting for messages from queue '{queue_name}'...")
        print(f"RabbitMQ host: {args.host}:{args.port}")
        print(f"PLC IP address: 192.142.0.11")
        print("Press Ctrl+C to stop\n")
        
        channel.start_consuming()
        
    except KeyboardInterrupt:
        print("\n\nProgram stopped by user (Ctrl+C)")
    except Exception as e:
        print(f"\nError: {e}")
    finally:
        # Close PLC connection
        if plc_client is not None:
            try:
                plc_client.Close()
                print("PLC connection closed")
            except Exception as e:
                print(f"Error closing PLC connection: {e}")
        
        # Properly close RabbitMQ connection
        if channel and channel.is_open:
            try:
                channel.stop_consuming()
                print("Stopping consumption...")
            except:
                pass
        
        if connection and connection.is_open:
            connection.close()
            print("RabbitMQ connection closed")
        
        print("Exiting program")


if __name__ == "__main__":
    main()