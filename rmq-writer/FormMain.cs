using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace RMQWriter
{
    using System;
    using System.IO;
    using System.Timers;
    using System.Collections.Generic;
    using System.Linq;

    public partial class FormMain : Form
    {
        private bool _isConnected = false;
        private string _queueName = string.Empty;

        private ConnectionFactory _factory;
        private IConnection _connection;
        private RabbitMQ.Client.IChannel _channel;
        private string _consumerTag = string.Empty;

        private AdvancedDataLogger _log = null;

        public FormMain()
        {
            InitializeComponent();

            _log = new AdvancedDataLogger();
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

                    // Write log data
                    if (cbLogger.Checked)
                        _log.AppendData(numbers);

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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_log != null)
            {
                _log.Dispose();
            }
        }
    }

    public class AdvancedDataLogger : IDisposable
    {
        private StreamWriter _writer;
        private string _currentFileName;
        private DateTime _currentDate;
        private readonly object _lockObj = new object();
        private Timer _dayCheckTimer;

        public AdvancedDataLogger()
        {
            // Timer to check for day change (every minute)
            _dayCheckTimer = new Timer(60000);
            _dayCheckTimer.Elapsed += OnTimerElapsed;
            _dayCheckTimer.Start();

            SetupLogger();
        }

        private void SetupLogger()
        {
            lock (_lockObj)
            {
                _currentDate = DateTime.Now.Date;
                _currentFileName = GetFileName(_currentDate);

                // Close old writer if it exists
                _writer?.Close();

                // Create new file or open existing for appending
                bool fileExists = File.Exists(_currentFileName);
                _writer = new StreamWriter(_currentFileName, append: true);

                if (!fileExists)
                {
                    // Optionally add header for new file
                    _writer.WriteLine("TS,BL5Delta,BL5Min,BL5Max,BL6Delta,BL6Min,BL6Max,BL7Delta,BL7Min,BL7Max,BL8Delta,BL8Min,BL8Max,CMDelta,CMMin,CMMax");
                }
                _writer.AutoFlush = true;
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            if (now.Date != _currentDate)
            {
                // New day has started - create new log file
                SetupLogger();
            }
        }

        public void AppendData(List<double> numbers)
        {
            ValidateNumbers(numbers, numbers?.Count ?? 0);
            WriteNumbers(numbers);
        }

        public void AppendData(double[] numbers)
        {
            ValidateNumbers(numbers, numbers?.Length ?? 0);
            WriteNumbers(numbers);
        }

        private void ValidateNumbers(object numbers, int count)
        {
            if (numbers == null)
                throw new ArgumentException("Collection cannot be null");
            //if (count != 15)
            //    throw new ArgumentException("Must contain exactly 6 numbers");
        }

        private void WriteNumbers(IEnumerable<double> numbers)
        {
            lock (_lockObj)
            {
                // Get Unix timestamp (integer number of seconds)
                long unixTime = GetUnixTimestamp();

                // Format string: TIME_STAMP,N1,N2,N3,N4,N5,N6
                string line = $"{unixTime},{string.Join(",", numbers)}";
                _writer.WriteLine(line);
            }
        }

        private long GetUnixTimestamp()
        {
            // Unix epoch: 1970-01-01 00:00:00 UTC
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        private string GetFileName(DateTime date)
        {
            return $"rmqwriter-{date:ddMMyy}.csv";
        }

        public void Dispose()
        {
            _dayCheckTimer?.Stop();
            _dayCheckTimer?.Dispose();
            _writer?.Close();
            _writer?.Dispose();
        }
    }
}
