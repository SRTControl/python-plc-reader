using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQMonitor
{
    public class PlantDataDiff
    {
        [JsonProperty("TimeStamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("PlantData")]
        public Dictionary<string, string> PlantData { get; set; } = new Dictionary<string, string>();
    }
}
