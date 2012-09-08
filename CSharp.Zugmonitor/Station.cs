using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CSharp.Zugmonitor.Model
{
    public sealed class Station
    {
        /// <summary>
        /// The Latitude of the station
        /// </summary>
        [JsonProperty("lat")]        
        public double Latitude { get; set; }
        /// <summary>
        /// The Longitude of the station
        /// </summary>
        [JsonProperty("lon")]        
        public double Longitude { get; set; }
        /// <summary>
        /// The name of the station
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The Id of the station, used by a train to reference the station
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
