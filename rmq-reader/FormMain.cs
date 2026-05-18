using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;


namespace RMQReader
{
    public partial class FormMain : Form
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private RabbitMQ.Client.IChannel _channel;
        private string _consumerTag = string.Empty;

        private bool _isConnected = false;

        private Logger appLog;

        private AdvancedDataLogger _log = null;

        public FormMain()
        {
            InitializeComponent();

            appLog = NLog.LogManager.GetCurrentClassLogger();

            Blower5.Caption = "BLOWER 5";
            Blower6.Caption = "BLOWER 6";
            Blower7.Caption = "BLOWER 7";
            Blower8.Caption = "BLOWER 8";
            
            T3G3.Caption = "T3G3";
            T3G4.Caption = "T3G4";
            T3G5.Caption = "T3G5";
            T3G6.Caption = "T3G6";
            T3G7.Caption = "T3G7";

            T4G3.Caption = "T4G3";
            T4G4.Caption = "T4G4";
            T4G5.Caption = "T4G5";
            T4G6.Caption = "T4G6";
            T4G7.Caption = "T4G7";

            T5G3.Caption = "T5G3";
            T5G4.Caption = "T5G4";
            T5G5.Caption = "T5G5";
            T5G6.Caption = "T5G6";
            T5G7.Caption = "T5G7";

            _log = new AdvancedDataLogger();
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
                    var data = JsonConvert.DeserializeObject<PlantData>(jsonString);

                    double[] numbers = new double[15];
                    
                    numbers[0] = data.Blower5.VanePositionDeltaMAX; ;
                    numbers[1] = data.Blower5.VanePositionMIN;
                    numbers[2] = data.Blower5.VanePositionMAX;

                    numbers[3] = data.Blower6.VanePositionDeltaMAX; ;
                    numbers[4] = data.Blower6.VanePositionMIN;
                    numbers[5] = data.Blower6.VanePositionMAX;

                    numbers[6] = data.Blower7.VanePositionDeltaMAX; ;
                    numbers[7] = data.Blower7.VanePositionMIN;
                    numbers[8] = data.Blower7.VanePositionMAX;

                    numbers[9] = data.Blower8.VanePositionDeltaMAX;
                    numbers[10] = data.Blower8.VanePositionMIN;
                    numbers[11] = data.Blower8.VanePositionMAX;

                    numbers[12] = data.Common.PressureDeltaMAX;
                    numbers[13] = data.Common.PressureMIN;
                    numbers[14] = data.Common.PressureMAX;

                    // Write log data
                    if (cbLogger.Checked)
                        _log.AppendData(numbers);

                    if (data != null)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            #region COMMON
                            textBoxTimeStamp.Text = UnixTimeStampToDateTime((double)data.TimeStamp).ToLongTimeString();
                            textBoxPressure.Text = $"{data.Common.PressureReadings:F2}";
                            textBoxAirTemperature.Text = $"{data.Common.AirTemperatureReadings:F2}";
                            textBoxRainGauge.Text = $"{data.Common.RainGaugeReadings:F2}";
                            cbDOMasterInOperation.Checked = (data.Common.IsDOmasterInOperation == 1);
                            textBoxPH1.Text = $"{data.Common.pHReadings_1:F2}";
                            textBoxPH2.Text = $"{data.Common.pHReadings_2:F2}";
                            textBoxPH3.Text = $"{data.Common.pHReadings_3:F2}";
                            textBoxPressureDeltaMAX.Text = $"{data.Common.PressureDeltaMAX:F2}";
                            textBoxPressureMIN.Text = $"{data.Common.PressureMIN:F2}";
                            textBoxPressureMAX.Text = $"{data.Common.PressureMAX:F2}";
                            #endregion

                            #region BLOWER 5
                            Blower5.VaneMR = $"{data.Blower5.VanePositionReadings:F2}";
                            Blower5.VaneSP = $"{data.Blower5.VanePositionSetPoint:F2}";
                            Blower5.Power = $"{data.Blower5.Power:F2}";
                            Blower5.InOperation = (data.Blower5.InOperation == 1);
                            Blower5.StartStop = (data.Blower5.StartStopSignal == 1);
                            Blower5.VanePositionDeltaMAX = $"{data.Blower5.VanePositionDeltaMAX:F2}";
                            Blower5.VanePositionMIN = $"{data.Blower5.VanePositionMIN:F2}";
                            Blower5.VanePositionMAX = $"{data.Blower5.VanePositionMAX:F2}";
                            #endregion

                            #region BLOWER 6
                            Blower6.VaneMR = $"{data.Blower6.VanePositionReadings:F2}";
                            Blower6.VaneSP = $"{data.Blower6.VanePositionSetPoint:F2}";
                            Blower6.Power = $"{data.Blower6.Power:F2}";
                            Blower6.InOperation = (data.Blower6.InOperation == 1);
                            Blower6.StartStop = (data.Blower6.StartStopSignal == 1);
                            Blower6.VanePositionDeltaMAX = $"{data.Blower6.VanePositionDeltaMAX:F2}";
                            Blower6.VanePositionMIN = $"{data.Blower6.VanePositionMIN:F2}";
                            Blower6.VanePositionMAX = $"{data.Blower6.VanePositionMAX:F2}";
                            #endregion

                            #region BLOWER 7
                            Blower7.VaneMR = $"{data.Blower7.VanePositionReadings:F2}";
                            Blower7.VaneSP = $"{data.Blower7.VanePositionSetPoint:F2}";
                            Blower7.Power = $"{data.Blower7.Power:F2}";
                            Blower7.InOperation = (data.Blower7.InOperation == 1);
                            Blower7.StartStop = (data.Blower7.StartStopSignal == 1);
                            Blower7.VanePositionDeltaMAX = $"{data.Blower7.VanePositionDeltaMAX:F2}";
                            Blower7.VanePositionMIN = $"{data.Blower7.VanePositionMIN:F2}";
                            Blower7.VanePositionMAX = $"{data.Blower7.VanePositionMAX:F2}";
                            #endregion

                            #region BLOWER 8
                            Blower8.VaneMR = $"{data.Blower8.VanePositionReadings:F2}";
                            Blower8.VaneSP = $"{data.Blower8.VanePositionSetPoint:F2}";
                            Blower8.Power = $"{data.Blower8.Power:F2}";
                            Blower8.InOperation = (data.Blower8.InOperation == 1);
                            Blower8.StartStop = (data.Blower8.StartStopSignal == 1);
                            Blower8.VanePositionDeltaMAX = $"{data.Blower8.VanePositionDeltaMAX:F2}";
                            Blower8.VanePositionMIN = $"{data.Blower8.VanePositionMIN:F2}";
                            Blower8.VanePositionMAX = $"{data.Blower8.VanePositionMAX:F2}";
                            #endregion

                            #region TANK 3
                            T3G3.ValveMR = $"{data.Tank3.Grid3.Airflow.ValvePositionReadings:F2}";
                            T3G3.ValveSP = $"{data.Tank3.Grid3.Airflow.ValvePositionSetPoint:F2}";
                            T3G3.AirflowMR = $"{data.Tank3.Grid3.Airflow.MeterReadings:F2}";
                            T3G3.AirflowSP = $"{data.Tank3.Grid3.Airflow.SetPoint:F2}";
                            T3G3.DOMR = $"{data.Tank3.Grid3.DO.MeterReadings:F2}";
                            T3G3.DOSP = $"{data.Tank3.Grid3.DO.SetPoint:F2}";
                            T3G3.NH3MR = $"{data.Tank3.Grid3.NH3.MeterReadings:F2}";
                            T3G3.NH3SP = $"{data.Tank3.Grid3.NH3.SetPoint:F2}";

                            T3G4.ValveMR = $"{data.Tank3.Grid4.Airflow.ValvePositionReadings:F2}";
                            T3G4.ValveSP = $"{data.Tank3.Grid4.Airflow.ValvePositionSetPoint:F2}";
                            T3G4.AirflowMR = $"{data.Tank3.Grid4.Airflow.MeterReadings:F2}";
                            T3G4.AirflowSP = $"{data.Tank3.Grid4.Airflow.SetPoint:F2}";
                            T3G4.DOMR = $"{data.Tank3.Grid4.DO.MeterReadings:F2}";
                            T3G4.DOSP = $"{data.Tank3.Grid4.DO.SetPoint:F2}";
                            T3G4.NH3MR = $"{data.Tank3.Grid4.NH3.MeterReadings:F2}";
                            T3G4.NH3SP = $"{data.Tank3.Grid4.NH3.SetPoint:F2}";

                            T3G5.ValveMR = $"{data.Tank3.Grid5.Airflow.ValvePositionReadings:F2}";
                            T3G5.ValveSP = $"{data.Tank3.Grid5.Airflow.ValvePositionSetPoint:F2}";
                            T3G5.AirflowMR = $"{data.Tank3.Grid5.Airflow.MeterReadings:F2}";
                            T3G5.AirflowSP = $"{data.Tank3.Grid5.Airflow.SetPoint:F2}";
                            T3G5.DOMR = $"{data.Tank3.Grid5.DO.MeterReadings:F2}";
                            T3G5.DOSP = $"{data.Tank3.Grid5.DO.SetPoint:F2}";
                            T3G5.NH3MR = $"{data.Tank3.Grid5.NH3.MeterReadings:F2}";
                            T3G5.NH3SP = $"{data.Tank3.Grid5.NH3.SetPoint:F2}";

                            T3G6.ValveMR = $"{data.Tank3.Grid6.Airflow.ValvePositionReadings:F2}";
                            T3G6.ValveSP = $"{data.Tank3.Grid6.Airflow.ValvePositionSetPoint:F2}";
                            T3G6.AirflowMR = $"{data.Tank3.Grid6.Airflow.MeterReadings:F2}";
                            T3G6.AirflowSP = $"{data.Tank3.Grid6.Airflow.SetPoint:F2}";
                            T3G6.DOMR = $"{data.Tank3.Grid6.DO.MeterReadings:F2}";
                            T3G6.DOSP = $"{data.Tank3.Grid6.DO.SetPoint:F2}";
                            T3G6.NH3MR = $"{data.Tank3.Grid6.NH3.MeterReadings:F2}";
                            T3G6.NH3SP = $"{data.Tank3.Grid6.NH3.SetPoint:F2}";

                            T3G7.ValveMR = $"{data.Tank3.Grid7.Airflow.ValvePositionReadings:F2}";
                            T3G7.ValveSP = $"{data.Tank3.Grid7.Airflow.ValvePositionSetPoint:F2}";
                            T3G7.AirflowMR = $"{data.Tank3.Grid7.Airflow.MeterReadings:F2}";
                            T3G7.AirflowSP = $"{data.Tank3.Grid7.Airflow.SetPoint:F2}";
                            T3G7.DOMR = $"{data.Tank3.Grid7.DO.MeterReadings:F2}";
                            T3G7.DOSP = $"{data.Tank3.Grid7.DO.SetPoint:F2}";
                            T3G7.NH3MR = $"{data.Tank3.Grid7.NH3.MeterReadings:F2}";
                            T3G7.NH3SP = $"{data.Tank3.Grid7.NH3.SetPoint:F2}";
                            #endregion

                            #region TANK 4
                            T4G3.ValveMR = $"{data.Tank4.Grid3.Airflow.ValvePositionReadings:F2}";
                            T4G3.ValveSP = $"{data.Tank4.Grid3.Airflow.ValvePositionSetPoint:F2}";
                            T4G3.AirflowMR = $"{data.Tank4.Grid3.Airflow.MeterReadings:F2}";
                            T4G3.AirflowSP = $"{data.Tank4.Grid3.Airflow.SetPoint:F2}";
                            T4G3.DOMR = $"{data.Tank4.Grid3.DO.MeterReadings:F2}";
                            T4G3.DOSP = $"{data.Tank4.Grid3.DO.SetPoint:F2}";
                            T4G3.NH3MR = $"{data.Tank4.Grid3.NH3.MeterReadings:F2}";
                            T4G3.NH3SP = $"{data.Tank4.Grid3.NH3.SetPoint:F2}";

                            T4G4.ValveMR = $"{data.Tank4.Grid4.Airflow.ValvePositionReadings:F2}";
                            T4G4.ValveSP = $"{data.Tank4.Grid4.Airflow.ValvePositionSetPoint:F2}";
                            T4G4.AirflowMR = $"{data.Tank4.Grid4.Airflow.MeterReadings:F2}";
                            T4G4.AirflowSP = $"{data.Tank4.Grid4.Airflow.SetPoint:F2}";
                            T4G4.DOMR = $"{data.Tank4.Grid4.DO.MeterReadings:F2}";
                            T4G4.DOSP = $"{data.Tank4.Grid4.DO.SetPoint:F2}";
                            T4G4.NH3MR = $"{data.Tank4.Grid4.NH3.MeterReadings:F2}";
                            T4G4.NH3SP = $"{data.Tank4.Grid4.NH3.SetPoint:F2}";

                            T4G5.ValveMR = $"{data.Tank4.Grid5.Airflow.ValvePositionReadings:F2}";
                            T4G5.ValveSP = $"{data.Tank4.Grid5.Airflow.ValvePositionSetPoint:F2}";
                            T4G5.AirflowMR = $"{data.Tank4.Grid5.Airflow.MeterReadings:F2}";
                            T4G5.AirflowSP = $"{data.Tank4.Grid5.Airflow.SetPoint:F2}";
                            T4G5.DOMR = $"{data.Tank4.Grid5.DO.MeterReadings:F2}";
                            T4G5.DOSP = $"{data.Tank4.Grid5.DO.SetPoint:F2}";
                            T4G5.NH3MR = $"{data.Tank4.Grid5.NH3.MeterReadings:F2}";
                            T4G5.NH3SP = $"{data.Tank4.Grid5.NH3.SetPoint:F2}";

                            T4G6.ValveMR = $"{data.Tank4.Grid6.Airflow.ValvePositionReadings:F2}";
                            T4G6.ValveSP = $"{data.Tank4.Grid6.Airflow.ValvePositionSetPoint:F2}";
                            T4G6.AirflowMR = $"{data.Tank4.Grid6.Airflow.MeterReadings:F2}";
                            T4G6.AirflowSP = $"{data.Tank4.Grid6.Airflow.SetPoint:F2}";
                            T4G6.DOMR = $"{data.Tank4.Grid6.DO.MeterReadings:F2}";
                            T4G6.DOSP = $"{data.Tank4.Grid6.DO.SetPoint:F2}";
                            T4G6.NH3MR = $"{data.Tank4.Grid6.NH3.MeterReadings:F2}";
                            T4G6.NH3SP = $"{data.Tank4.Grid6.NH3.SetPoint:F2}";

                            T4G7.ValveMR = $"{data.Tank4.Grid7.Airflow.ValvePositionReadings:F2}";
                            T4G7.ValveSP = $"{data.Tank4.Grid7.Airflow.ValvePositionSetPoint:F2}";
                            T4G7.AirflowMR = $"{data.Tank4.Grid7.Airflow.MeterReadings:F2}";
                            T4G7.AirflowSP = $"{data.Tank4.Grid7.Airflow.SetPoint:F2}";
                            T4G7.DOMR = $"{data.Tank4.Grid7.DO.MeterReadings:F2}";
                            T4G7.DOSP = $"{data.Tank4.Grid7.DO.SetPoint:F2}";
                            T4G7.NH3MR = $"{data.Tank4.Grid7.NH3.MeterReadings:F2}";
                            T4G7.NH3SP = $"{data.Tank4.Grid7.NH3.SetPoint:F2}";
                            #endregion

                            #region TANK 5
                            T5G3.ValveMR = $"{data.Tank5.Grid3.Airflow.ValvePositionReadings:F2}";
                            T5G3.ValveSP = $"{data.Tank5.Grid3.Airflow.ValvePositionSetPoint:F2}";
                            T5G3.AirflowMR = $"{data.Tank5.Grid3.Airflow.MeterReadings:F2}";
                            T5G3.AirflowSP = $"{data.Tank5.Grid3.Airflow.SetPoint:F2}";
                            T5G3.DOMR = $"{data.Tank5.Grid3.DO.MeterReadings:F2}";
                            T5G3.DOSP = $"{data.Tank5.Grid3.DO.SetPoint:F2}";
                            T5G3.NH3MR = $"{data.Tank5.Grid3.NH3.MeterReadings:F2}";
                            T5G3.NH3SP = $"{data.Tank5.Grid3.NH3.SetPoint:F2}";

                            T5G4.ValveMR = $"{data.Tank5.Grid4.Airflow.ValvePositionReadings:F2}";
                            T5G4.ValveSP = $"{data.Tank5.Grid4.Airflow.ValvePositionSetPoint:F2}";
                            T5G4.AirflowMR = $"{data.Tank5.Grid4.Airflow.MeterReadings:F2}";
                            T5G4.AirflowSP = $"{data.Tank5.Grid4.Airflow.SetPoint:F2}";
                            T5G4.DOMR = $"{data.Tank5.Grid4.DO.MeterReadings:F2}";
                            T5G4.DOSP = $"{data.Tank5.Grid4.DO.SetPoint:F2}";
                            T5G4.NH3MR = $"{data.Tank5.Grid4.NH3.MeterReadings:F2}";
                            T5G4.NH3SP = $"{data.Tank5.Grid4.NH3.SetPoint:F2}";

                            T5G5.ValveMR = $"{data.Tank5.Grid5.Airflow.ValvePositionReadings:F2}";
                            T5G5.ValveSP = $"{data.Tank5.Grid5.Airflow.ValvePositionSetPoint:F2}";
                            T5G5.AirflowMR = $"{data.Tank5.Grid5.Airflow.MeterReadings:F2}";
                            T5G5.AirflowSP = $"{data.Tank5.Grid5.Airflow.SetPoint:F2}";
                            T5G5.DOMR = $"{data.Tank5.Grid5.DO.MeterReadings:F2}";
                            T5G5.DOSP = $"{data.Tank5.Grid5.DO.SetPoint:F2}";
                            T5G5.NH3MR = $"{data.Tank5.Grid5.NH3.MeterReadings:F2}";
                            T5G5.NH3SP = $"{data.Tank5.Grid5.NH3.SetPoint:F2}";

                            T5G6.ValveMR = $"{data.Tank5.Grid6.Airflow.ValvePositionReadings:F2}";
                            T5G6.ValveSP = $"{data.Tank5.Grid6.Airflow.ValvePositionSetPoint:F2}";
                            T5G6.AirflowMR = $"{data.Tank5.Grid6.Airflow.MeterReadings:F2}";
                            T5G6.AirflowSP = $"{data.Tank5.Grid6.Airflow.SetPoint:F2}";
                            T5G6.DOMR = $"{data.Tank5.Grid6.DO.MeterReadings:F2}";
                            T5G6.DOSP = $"{data.Tank5.Grid6.DO.SetPoint:F2}";
                            T5G6.NH3MR = $"{data.Tank5.Grid6.NH3.MeterReadings:F2}";
                            T5G6.NH3SP = $"{data.Tank5.Grid6.NH3.SetPoint:F2}";

                            T5G7.ValveMR = $"{data.Tank5.Grid7.Airflow.ValvePositionReadings:F2}";
                            T5G7.ValveSP = $"{data.Tank5.Grid7.Airflow.ValvePositionSetPoint:F2}";
                            T5G7.AirflowMR = $"{data.Tank5.Grid7.Airflow.MeterReadings:F2}";
                            T5G7.AirflowSP = $"{data.Tank5.Grid7.Airflow.SetPoint:F2}";
                            T5G7.DOMR = $"{data.Tank5.Grid7.DO.MeterReadings:F2}";
                            T5G7.DOSP = $"{data.Tank5.Grid7.DO.SetPoint:F2}";
                            T5G7.NH3MR = $"{data.Tank5.Grid7.NH3.MeterReadings:F2}";
                            T5G7.NH3SP = $"{data.Tank5.Grid7.NH3.SetPoint:F2}";
                            #endregion

                        }));
                    }
                }
                catch (Exception ex)
                {
                    appLog.Error(ex.ToString());
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
#if DEBUG
            string jsonString = "{\"TimeStamp\": 1765731634, \"Common\": {\"AirTemperatureReadings\": \"12.00\", \"IsDOmasterInOperation\": 0, \"PressureReadings\": \"8.66\", \"RainGaugeReadings\": \"0.00\", \"WaterTemperatureReadings\": \"0.00\", \"pHReadings_1\": \"7.07\", \"pHReadings_2\": \"2.00\", \"pHReadings_3\": \"2.00\"}, \"Blower7\": {\"InOperation\": 0, \"Power\": \"0.00\", \"StartStopSignal\": 1, \"VanePositionReadings\": \"0.00\", \"VanePositionSetPoint\": \"133.41\"}, \"Blower8\": {\"InOperation\": 0, \"Power\": \"0.00\", \"StartStopSignal\": 1, \"VanePositionReadings\": \"0.00\", \"VanePositionSetPoint\": \"133.41\"}, \"Tank3\": {\"HydraulicFlow\": {\"MeterReadings\": \"3.64\"}, \"Airflow\": {\"MeterReadings\": \"1781.00\", \"SetPoint\": \"0.00\", \"ValvePositionReadings\": \"42.20\", \"ValvePositionSetPoint\": \"100.00\"}, \"Grid3\": {\"Airflow\": {\"MeterReadings\": \"403.80\", \"SetPoint\": \"565.44\", \"ValvePositionReadings\": \"55.92\", \"ValvePositionSetPoint\": \"50.00\"}, \"DO\": {\"MeterReadings\": \"1.43\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid4\": {\"Airflow\": {\"MeterReadings\": \"403.80\", \"SetPoint\": \"565.44\", \"ValvePositionReadings\": \"55.92\", \"ValvePositionSetPoint\": \"50.00\"}, \"DO\": {\"MeterReadings\": \"1.43\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid5\": {\"Airflow\": {\"MeterReadings\": \"403.80\", \"SetPoint\": \"565.44\", \"ValvePositionReadings\": \"55.92\", \"ValvePositionSetPoint\": \"50.00\"}, \"DO\": {\"MeterReadings\": \"1.43\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid6\": {\"Airflow\": {\"MeterReadings\": \"403.80\", \"SetPoint\": \"565.44\", \"ValvePositionReadings\": \"55.92\", \"ValvePositionSetPoint\": \"50.00\"}, \"DO\": {\"MeterReadings\": \"1.43\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid7\": {\"Airflow\": {\"MeterReadings\": \"403.80\", \"SetPoint\": \"565.44\", \"ValvePositionReadings\": \"55.92\", \"ValvePositionSetPoint\": \"50.00\"}, \"DO\": {\"MeterReadings\": \"1.43\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}}, \"Tank4\": {\"HydraulicFlow\": {\"MeterReadings\": \"3.64\"}, \"Airflow\": {\"MeterReadings\": \"1889.00\", \"SetPoint\": \"0.00\", \"ValvePositionReadings\": \"100.00\", \"ValvePositionSetPoint\": \"100.00\"}, \"Grid3\": {\"Airflow\": {\"MeterReadings\": \"475.63\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.58\", \"ValvePositionSetPoint\": \"5.00\"}, \"DO\": {\"MeterReadings\": \"1.15\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"28.62\", \"SetPoint\": \"0.00\"}}, \"Grid4\": {\"Airflow\": {\"MeterReadings\": \"475.63\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.58\", \"ValvePositionSetPoint\": \"5.00\"}, \"DO\": {\"MeterReadings\": \"1.15\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"28.62\", \"SetPoint\": \"0.00\"}}, \"Grid5\": {\"Airflow\": {\"MeterReadings\": \"475.63\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.58\", \"ValvePositionSetPoint\": \"5.00\"}, \"DO\": {\"MeterReadings\": \"1.15\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"28.62\", \"SetPoint\": \"0.00\"}}, \"Grid6\": {\"Airflow\": {\"MeterReadings\": \"475.63\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.58\", \"ValvePositionSetPoint\": \"5.00\"}, \"DO\": {\"MeterReadings\": \"1.15\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"28.62\", \"SetPoint\": \"0.00\"}}, \"Grid7\": {\"Airflow\": {\"MeterReadings\": \"475.63\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.58\", \"ValvePositionSetPoint\": \"5.00\"}, \"DO\": {\"MeterReadings\": \"1.15\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"28.62\", \"SetPoint\": \"0.00\"}}}, \"Tank5\": {\"HydraulicFlow\": {\"MeterReadings\": \"3.64\"}, \"Airflow\": {\"MeterReadings\": \"960.41\", \"SetPoint\": \"0.00\", \"ValvePositionReadings\": \"26.51\", \"ValvePositionSetPoint\": \"100.00\"}, \"Grid3\": {\"Airflow\": {\"MeterReadings\": \"296.17\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.99\", \"ValvePositionSetPoint\": \"44.08\"}, \"DO\": {\"MeterReadings\": \"1.74\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid4\": {\"Airflow\": {\"MeterReadings\": \"296.17\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.99\", \"ValvePositionSetPoint\": \"44.08\"}, \"DO\": {\"MeterReadings\": \"1.74\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid5\": {\"Airflow\": {\"MeterReadings\": \"296.17\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.99\", \"ValvePositionSetPoint\": \"44.08\"}, \"DO\": {\"MeterReadings\": \"1.74\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid6\": {\"Airflow\": {\"MeterReadings\": \"296.17\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.99\", \"ValvePositionSetPoint\": \"44.08\"}, \"DO\": {\"MeterReadings\": \"1.74\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}, \"Grid7\": {\"Airflow\": {\"MeterReadings\": \"296.17\", \"SetPoint\": \"200.00\", \"ValvePositionReadings\": \"50.99\", \"ValvePositionSetPoint\": \"44.08\"}, \"DO\": {\"MeterReadings\": \"1.74\", \"SetPoint\": \"0.50\"}, \"NH3\": {\"MeterReadings\": \"0.00\", \"SetPoint\": \"0.00\"}}}}";
            var data = JsonConvert.DeserializeObject<PlantData>(jsonString);
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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
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
        private System.Timers.Timer _dayCheckTimer;

        public AdvancedDataLogger()
        {
            // Timer to check for day change (every minute)
            _dayCheckTimer = new System.Timers.Timer(60000);
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
            return $"rmqreader-{date:ddMMyy}.csv";
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
