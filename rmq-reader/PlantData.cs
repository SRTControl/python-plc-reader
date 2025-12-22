using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQReader
{
    public class CommonData
    {
        [JsonProperty("AirTemperatureReadings")]
        public double AirTemperatureReadings { get; set; }

        [JsonProperty("IsDOmasterInOperation")]
        public int IsDOmasterInOperation { get; set; }

        [JsonProperty("PressureReadings")]
        public double PressureReadings { get; set; }

        [JsonProperty("RainGaugeReadings")]
        public double RainGaugeReadings { get; set; }

        [JsonProperty("WaterTemperatureReadings")]
        public double WaterTemperatureReadings { get; set; }

        [JsonProperty("pHReadings_1")]
        public double pHReadings_1 { get; set; }

        [JsonProperty("pHReadings_2")]
        public double pHReadings_2 { get; set; }

        [JsonProperty("pHReadings_3")]
        public double pHReadings_3 { get; set; }
    }
    
    public class BlowerData
    {
        [JsonProperty("InOperation")]
        public int InOperation { get; set; }

        [JsonProperty("Power")]
        public double Power { get; set; }

        [JsonProperty("StartStopSignal")]
        public int StartStopSignal { get; set; }

        [JsonProperty("VanePositionReadings")]
        public double VanePositionReadings { get; set; }

        [JsonProperty("VanePositionSetPoint")]
        public double VanePositionSetPoint { get; set; }
    }

    public class HydraulicFlowData
    {
        [JsonProperty("MeterReadings")]
        public double MeterReadings { get; set; }
    }

    public class AirflowData
    {
        [JsonProperty("MeterReadings")]
        public double MeterReadings { get; set; }

        [JsonProperty("SetPoint")]
        public double SetPoint { get; set; }

        [JsonProperty("ValvePositionReadings")]
        public double ValvePositionReadings { get; set; }

        [JsonProperty("ValvePositionSetPoint")]
        public double ValvePositionSetPoint { get; set; }
    }

    public class DOData
    {
        [JsonProperty("MeterReadings")]
        public double MeterReadings { get; set; }

        [JsonProperty("SetPoint")]
        public double SetPoint { get; set; }
    }

    public class NH3Data
    {
        [JsonProperty("MeterReadings")]
        public double MeterReadings { get; set; }

        [JsonProperty("SetPoint")]
        public double SetPoint { get; set; }
    }

    public class GridData
    {
        [JsonProperty("Airflow")]
        public AirflowData Airflow { get; set; }

        [JsonProperty("DO")]
        public DOData DO { get; set; }

        [JsonProperty("NH3")]
        public NH3Data NH3 { get; set; }
    }

    public class TankData
    {
        [JsonProperty("HydraulicFlow")]
        public HydraulicFlowData HydraulicFlow { get; set; }

        [JsonProperty("Airflow")]
        public AirflowData Airflow { get; set; }

        [JsonProperty("Grid3")]
        public GridData Grid3 { get; set; }

        [JsonProperty("Grid4")]
        public GridData Grid4 { get; set; }

        [JsonProperty("Grid5")]
        public GridData Grid5 { get; set; }

        [JsonProperty("Grid6")]
        public GridData Grid6 { get; set; }

        [JsonProperty("Grid7")]
        public GridData Grid7 { get; set; }
    }

    public class PlantData
    {
        [JsonProperty("TimeStamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("Common")]
        public CommonData Common { get; set; }

        [JsonProperty("Blower7")]
        public BlowerData Blower7 { get; set; }

        [JsonProperty("Blower8")]
        public BlowerData Blower8 { get; set; }

        [JsonProperty("Tank3")]
        public TankData Tank3 { get; set; }

        [JsonProperty("Tank4")]
        public TankData Tank4 { get; set; }

        [JsonProperty("Tank5")]
        public TankData Tank5 { get; set; }
    }
}
