using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Zugmonitor.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace CSharp.Zugmonitor
{
    public sealed class  ServiceProvier
    {
        private Func<Uri, string> _getHandler;

        /// <summary>
        /// Creates a new instance of the ServiceProvider that handles access to the Zugmonitor API
        /// </summary>
        /// <param name="getHandler">A request handler that performs the transition from URI to response string</param>
        public ServiceProvier(Func<Uri, string> getHandler)
        {
            _getHandler = getHandler;
        }

        /// <summary>
        /// Creates a new instance of the ServiceProvider that handles access to the Zugmonitor API using the default gethandler.
        /// </summary>
        public ServiceProvier() : this(DefaultGetter) { }

        private static string DefaultGetter(Uri uri)
        {
            var req = WebRequest.Create(uri);
            var task = Task.Factory.FromAsync<WebResponse>(req.BeginGetResponse, req.EndGetResponse, (object)null);
            var res = task.Result;
            var stream = res.GetResponseStream();
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Gets all stations from the server
        /// </summary>
        /// <returns>a List of all stations</returns>
        public IList<Station> GetStations()
        {
            const string Uri = @"http://zugmonitor.sueddeutsche.de/api/stations";
            var data = _getHandler(new Uri(Uri));

            return GetStationsFromJson(data);
        }

        /// <summary>
        /// Get a list of all trains for a specific date
        /// </summary>
        /// <param name="date">The date of the train data, the time is ignored and only the yyyy-MM-dd part is used. 
        /// Supply the date of the current day to get realtime data.</param>
        /// <returns>A list of trains representing the state of the given date</returns>
        public IList<Train> GetTrains(DateTime date)
        {
            const string Uri = @"http://zugmonitor.sueddeutsche.de/api/trains/{0}";
            var data = _getHandler(new Uri(string.Format(Uri, date.ToString("yyyy-MM-dd"))));

            return GetTrainsFromJson(data);
        }

        private IList<Train> GetTrainsFromJson(string data)
        {
            var result = new List<Train>();
            var obj = JObject.Parse(data);

            var children = obj.Children().Select(item => item.Children());

            children.Aggregate(result, (list, item) =>
            {
                list.Add(JsonConvert.DeserializeObject<Train>(item.ToList()[0].ToString()));
                return list;
            });
            return result;
        }

        private IList<Station> GetStationsFromJson(string data)
        {
            var result = new List<Station>();
            var obj = JObject.Parse(data);
            var children = obj.Children().Select(item => item.Children());

            children.Aggregate(result, (list, item) => 
                {
                    list.Add(JsonConvert.DeserializeObject<Station>(item.ToList()[0].ToString()));
                    return list;
                });

            return result;
        }
    }
}
