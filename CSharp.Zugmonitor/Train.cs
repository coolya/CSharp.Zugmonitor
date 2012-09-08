using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CSharp.Zugmonitor.Model
{
    public sealed class Train
    {
        /// <summary>
        /// Number of the train, e.g. IC 2061
        /// </summary>
        [JsonProperty("train_nr")]
        public string TrainId { get; set; }
        /// <summary>
        /// Status of the train monitoring.
        /// </summary>
        [JsonProperty("status")]
        public TrainStatus Status { get; set; }
        /// <summary>
        /// Information about every station the train arrives.
        /// </summary>
        [JsonProperty("stations")]
        public IList<StationInfo> Stations { get; set; }
        /// <summary>
        /// DateTime when monitoring of this train started.
        /// </summary>
        [JsonProperty("started")]
        public DateTime? Started { get; set; }
        /// <summary>
        /// The next DateTime the trainmonitor will visit this train.
        /// </summary>
        [JsonProperty("nextrun")]
        public DateTime? Nextrun { get; set; }

        /// <summary>
        /// The DateTime monitoring of this train finished. 
        /// </summary>
        [JsonProperty("finished")]
        public DateTime? Finished { get; set; }
            
    }

    /// <summary>
    /// Status of the trainmonitor
    /// </summary>
    public enum TrainStatus
    {
        /// <summary>
        /// Error, something went wrong while monitoring the train. The data might not be accurate.
        /// </summary>
        E ,
        /// <summary>
        /// Finished, the train monitor has ended, normally because a train reached the target destination.
        /// </summary>
        F ,
        /// <summary>
        /// Sleeping, the monitoring for this train is waiting for revisiting the train.
        /// </summary>
        S,
        /// <summary>
        /// The trainmonitor is currently visiting the train.
        /// </summary>
        X, 
        N
    }
}
