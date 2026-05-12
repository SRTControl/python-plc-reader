using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMQWriter
{
    public partial class FormMain : Form
    {
        private bool _isConnected = false;
        private string _queueName = string.Empty;

        private ConnectionFactory _factory;
        private IConnection _connection;
        private RabbitMQ.Client.IChannel _channel;
        private string _consumerTag = string.Empty;

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
                Password = "guest",

                AutomaticRecoveryEnabled = true,                    // Включение авто-восстановления
                NetworkRecoveryInterval = TimeSpan.FromSeconds(5),  // Интервал попыток
                TopologyRecoveryEnabled = true,                     // Восстановление топологии (очереди, обменники)
                RequestedHeartbeat = TimeSpan.FromSeconds(60)       // Heartbeat для обнаружения разрывов
            };

            _factory.AutomaticRecoveryEnabled = true;

            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            //// Аргументы для ограничения длины очереди
            //var arguments = new Dictionary<string, object>
            //{
            //    { "x-max-length", 1 },              // Максимум 1 сообщение в очереди
            //    { "x-overflow", "drop-head" },      // Удалять самые старые при переполнении
            //    { "x-message-ttl", 86400000 }       // TTL 24 часа (опционально)
            //};

            //await _channel.QueueDeclareAsync(
            //    queue: _queueName,
            //    durable: true,
            //    exclusive: false,
            //    autoDelete: false,
            //    arguments: arguments);

            await _channel.QueueDeclareAsync(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false);
        }

        private async Task CloseRabbitMQConnectionAsync()
        {
            await _channel.QueuePurgeAsync(_queueName);

            await _channel.CloseAsync();
            await _connection.CloseAsync();
            await _channel.DisposeAsync();
            await _connection.DisposeAsync();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            _isConnected = !_isConnected;

            if (_isConnected)
            {
                _queueName = textBoxQueueName.Text;
                _ = OpenRabbitMQConnectionAsync();
                timerMain.Interval = Int32.Parse(textBoxTimerInterval.Text);
                timerMain.Start();

                buttonConnection.Text = "DISCONNECT";
            }
            else
            {
                timerMain.Stop();
                _ = OnTimerStop();

                _ = CloseRabbitMQConnectionAsync();
                
                buttonConnection.Text = "CONNECT";
            }
        }

        private async void timerMain_Tick(object sender, EventArgs e)
        {
            timerMain.Stop();
            try
            {
                bool isConnected = _connection != null && _connection.IsOpen && _channel != null && _channel.IsOpen;

                if (isConnected)
                {
                    // Data Generation
                    Random random = new Random();
                    double[] numbers = new double[15];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = random.NextDouble() * 100;
                    }

                    // GUI Update
                    BeginInvoke(new Action(() =>
                    {
                        ucBL5.Delta = numbers[0];
                        ucBL5.Min = numbers[1];
                        ucBL5.Max = numbers[2];

                        ucBL6.Delta = numbers[3];
                        ucBL6.Min = numbers[4];
                        ucBL6.Max = numbers[5];

                        ucBL7.Delta = numbers[6];
                        ucBL7.Min = numbers[7];
                        ucBL7.Max = numbers[8];

                        ucBL8.Delta = numbers[9];
                        ucBL8.Min = numbers[10];
                        ucBL8.Max = numbers[11];

                        ucCM.Delta = numbers[12];
                        ucCM.Min = numbers[13];
                        ucCM.Max = numbers[14];
                    }));

                    // Writing data to RabbitMQ
                    Dictionary<string, double> data = new Dictionary<string, double>();
                    data.Add("PlantDO.PLCB.Blower5.VanePositionDeltaMAX", numbers[0]);
                    data.Add("PlantDO.PLCB.Blower5.VanePositionMIN", numbers[1]);
                    data.Add("PlantDO.PLCB.Blower5.VanePositionMAX", numbers[2]);

                    data.Add("PlantDO.PLCB.Blower6.VanePositionDeltaMAX", numbers[3]);
                    data.Add("PlantDO.PLCB.Blower6.VanePositionMIN", numbers[4]);
                    data.Add("PlantDO.PLCB.Blower6.VanePositionMAX", numbers[5]);

                    data.Add("PlantDO.PLCB.Blower7.VanePositionDeltaMAX", numbers[6]);
                    data.Add("PlantDO.PLCB.Blower7.VanePositionMIN", numbers[7]);
                    data.Add("PlantDO.PLCB.Blower7.VanePositionMAX", numbers[8]);

                    data.Add("PlantDO.PLCB.Blower8.VanePositionDeltaMAX", numbers[9]);
                    data.Add("PlantDO.PLCB.Blower8.VanePositionMIN", numbers[10]);
                    data.Add("PlantDO.PLCB.Blower8.VanePositionMAX", numbers[11]);

                    data.Add("PlantDO.PLCB.Common.PressureDeltaMAX", numbers[12]);
                    data.Add("PlantDO.PLCB.Common.PressureMIN", numbers[13]);
                    data.Add("PlantDO.PLCB.Common.PressureMAX", numbers[14]);

                    string jsonString = JsonConvert.SerializeObject(data);
                    byte[] body = Encoding.UTF8.GetBytes(jsonString);

                    await _channel.BasicPublishAsync(
                        exchange: "",
                        routingKey: _queueName,
                        body: body);
                }
            }
            finally
            {
                timerMain.Start();
            }
            
        }

        private async Task OnTimerStop()
        {
            // GUI Update
            BeginInvoke(new Action(() =>
            {
                ucBL5.Delta = 0.0;
                ucBL5.Min = 0.0;
                ucBL5.Max = 0.0;

                ucBL6.Delta = 0.0;
                ucBL6.Min = 0.0;
                ucBL6.Max = 0.0;

                ucBL7.Delta = 0.0;
                ucBL7.Min = 0.0;
                ucBL7.Max = 0.0;

                ucBL8.Delta = 0.0;
                ucBL8.Min = 0.0;
                ucBL8.Max = 0.0;

                ucCM.Delta = 0.0;
                ucCM.Min = 0.0;
                ucCM.Max = 0.0;
            }));

            // Writing data to RabbitMQ
            Dictionary<string, double> data = new Dictionary<string, double>();
            data.Add("PlantDO.PLCB.Blower5.VanePositionDeltaMAX", 0.0);
            data.Add("PlantDO.PLCB.Blower5.VanePositionMIN", 0.0);
            data.Add("PlantDO.PLCB.Blower5.VanePositionMAX", 0.0);

            data.Add("PlantDO.PLCB.Blower6.VanePositionDeltaMAX", 0.0);
            data.Add("PlantDO.PLCB.Blower6.VanePositionMIN", 0.0);
            data.Add("PlantDO.PLCB.Blower6.VanePositionMAX", 0.0);

            data.Add("PlantDO.PLCB.Blower7.VanePositionDeltaMAX", 0.0);
            data.Add("PlantDO.PLCB.Blower7.VanePositionMIN", 0.0);
            data.Add("PlantDO.PLCB.Blower7.VanePositionMAX", 0.0);

            data.Add("PlantDO.PLCB.Blower8.VanePositionDeltaMAX", 0.0);
            data.Add("PlantDO.PLCB.Blower8.VanePositionMIN", 0.0);
            data.Add("PlantDO.PLCB.Blower8.VanePositionMAX", 0.0);

            data.Add("PlantDO.PLCB.Common.PressureDeltaMAX", 0.0);
            data.Add("PlantDO.PLCB.Common.PressureMIN", 0.0);
            data.Add("PlantDO.PLCB.Common.PressureMAX", 0.0);

            string jsonString = JsonConvert.SerializeObject(data);
            byte[] body = Encoding.UTF8.GetBytes(jsonString);

            await _channel.BasicPublishAsync(
                exchange: "",
                routingKey: _queueName,
                body: body);
        }
    }
}
