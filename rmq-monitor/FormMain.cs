using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace RMQMonitor
{
    public partial class FormMain : Form
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private RabbitMQ.Client.IChannel _channel;
        private string _consumerTag = string.Empty;

        private bool _isConnected = false;
        public FormMain()
        {
            InitializeComponent();
        }

        private async Task OpenRabbitMQConnectionAsync()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            _factory.AutomaticRecoveryEnabled = true;

            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                string jsonString = Encoding.UTF8.GetString(body);

                try
                {
                    var data = JsonConvert.DeserializeObject<PlantDataDiff>(jsonString);
                    string value;

                    if (data != null)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            #region COMMON
                            textBoxTimeStamp.Text = UnixTimeStampToDateTime((double)data.TimeStamp).ToLongTimeString();
                            textBoxCount.Text = data.PlantData.Count.ToString();

                            if (data.PlantData.TryGetValue("Tank3.Grid3.Airflow.MeterReadings", out value))
                                AF33.Text = value;
                            if (data.PlantData.TryGetValue("Tank3.Grid4.Airflow.MeterReadings", out value))
                                AF34.Text = value;
                            if (data.PlantData.TryGetValue("Tank3.Grid5.Airflow.MeterReadings", out value))
                                AF35.Text = value;
                            if (data.PlantData.TryGetValue("Tank3.Grid6.Airflow.MeterReadings", out value))
                                AF36.Text = value;
                            if (data.PlantData.TryGetValue("Tank3.Grid7.Airflow.MeterReadings", out value))
                                AF37.Text = value;

                            if (data.PlantData.TryGetValue("Tank4.Grid3.Airflow.MeterReadings", out value))
                                AF43.Text = value;
                            if (data.PlantData.TryGetValue("Tank4.Grid4.Airflow.MeterReadings", out value))
                                AF44.Text = value;
                            if (data.PlantData.TryGetValue("Tank4.Grid5.Airflow.MeterReadings", out value))
                                AF45.Text = value;
                            if (data.PlantData.TryGetValue("Tank4.Grid6.Airflow.MeterReadings", out value))
                                AF46.Text = value;
                            if (data.PlantData.TryGetValue("Tank4.Grid7.Airflow.MeterReadings", out value))
                                AF47.Text = value;

                            if (data.PlantData.TryGetValue("Tank5.Grid3.Airflow.MeterReadings", out value))
                                AF53.Text = value;
                            if (data.PlantData.TryGetValue("Tank5.Grid4.Airflow.MeterReadings", out value))
                                AF54.Text = value;
                            if (data.PlantData.TryGetValue("Tank5.Grid5.Airflow.MeterReadings", out value))
                                AF55.Text = value;
                            if (data.PlantData.TryGetValue("Tank5.Grid6.Airflow.MeterReadings", out value))
                                AF56.Text = value;
                            if (data.PlantData.TryGetValue("Tank5.Grid7.Airflow.MeterReadings", out value))
                                AF57.Text = value;
                            #endregion
                        }));
                    }
                }
                catch (Exception ex)
                {
                    // appLog.Error(ex.ToString());
                }

                // Copy or deserialise the payload and process the message                
                await _channel.BasicAckAsync(ea.DeliveryTag, false);
            };
            // This consumer tag identifies the subscription when it has to be cancelled
            string _queueName = textBoxQueueName.Text;
            string _consumerTag = await _channel.BasicConsumeAsync(_queueName, false, consumer);
        }

        private async Task CloseRabbitMQConnectionAsync()
        {
            await _channel.BasicCancelAsync(_consumerTag);

            await _channel.CloseAsync();
            await _connection.CloseAsync();
            await _channel.DisposeAsync();
            await _connection.DisposeAsync();
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
#if DEBUG
            string jsonString = "{\"TimeStamp\": 1767634292, \"PlantDate\": {\"Common.PressureReadings\": \"8.75\", \"Tank3.Airflow.MeterReadings\": \"1422.00\", \"Tank3.Grid3.Airflow.MeterReadings\": \"371.23\", \"Tank3.Grid5.Airflow.MeterReadings\": \"324.07\", \"Tank3.Grid6.Airflow.MeterReadings\": \"202.83\", \"Tank3.Grid6.DO.MeterReadings\": \"1.08\", \"Tank3.Grid6.NH3.MeterReadings\": \"2.75\", \"Tank3.Grid7.Airflow.MeterReadings\": \"262.80\", \"Tank3.Grid7.Airflow.ValvePositionReadings\": \"61.99\", \"Tank3.HydraulicFlow.MeterReadings\": \"11.74\", \"Tank4.Airflow.MeterReadings\": \"1531.00\", \"Tank4.Grid3.Airflow.MeterReadings\": \"389.17\", \"Tank4.Grid4.Airflow.MeterReadings\": \"272.77\", \"Tank4.Grid5.Airflow.MeterReadings\": \"260.50\", \"Tank4.Grid6.Airflow.MeterReadings\": \"255.53\", \"Tank4.Grid7.Airflow.MeterReadings\": \"250.50\", \"Tank4.HydraulicFlow.MeterReadings\": \"11.74\", \"Tank5.Airflow.MeterReadings\": \"1612.56\", \"Tank5.Airflow.ValvePositionReadings\": \"47.25\", \"Tank5.Grid3.Airflow.MeterReadings\": \"373.40\", \"Tank5.Grid4.Airflow.MeterReadings\": \"184.73\", \"Tank5.Grid4.DO.MeterReadings\": \"2.62\", \"Tank5.Grid5.Airflow.MeterReadings\": \"608.83\", \"Tank5.Grid6.Airflow.MeterReadings\": \"254.07\", \"Tank5.Grid7.Airflow.MeterReadings\": \"209.50\", \"Tank5.HydraulicFlow.MeterReadings\": \"11.74\"}}";

            var data = JsonConvert.DeserializeObject<PlantDataDiff>(jsonString);
            MessageBox.Show("Done");
#else
            _isConnected = !_isConnected;

            if (_isConnected)
            {
                _ = OpenRabbitMQConnectionAsync();
                buttonConnection.Text = "DISCONNECT";
            }
            else
            {
                _ = CloseRabbitMQConnectionAsync();
                buttonConnection.Text = "CONNECT";
            }
#endif
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
