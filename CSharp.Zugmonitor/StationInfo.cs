using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CSharp.Zugmonitor.Model
{
    public sealed class StationInfo
    {
        /// <summary>
        /// Time of the arrival in minutes since midnight
        /// </summary>
        [JsonProperty("arrival")]
        public int Arrival { get; set; }
        /// <summary>
        /// Tinme of the departure in minutes since midnight
        /// </summary>
        [JsonProperty("departure")]
        public int Departure { get; set; }
        /// <summary>
        /// Indecates if the train was scraped between this an the last station
        /// </summary>
        [JsonProperty("scraped")]
        public bool Scraped { get; set; }
        /// <summary>
        /// Id of the station
        /// </summary>
        [JsonProperty("station_id")]
        public int StationId { get; set; }
        /// <summary>
        /// Delay in minutes. Normally behind the real delay. 
        /// If the real delay is smaller than 5 this will be 0, 
        /// if the real delay is smaller than 10 this will be 5 and so on.
        /// </summary>
        [JsonProperty("delay")]
        public int Delay { get; set; }
        /// <summary>
        /// Cause of the delay. Might be null even if there is a delay
        /// </summary>
        [JsonProperty("delay_cause")]
        public string DelayCause { get; set; }
    }
}
