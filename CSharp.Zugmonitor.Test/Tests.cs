//#define local_test
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Zugmonitor;
using System.IO;

namespace CSharp.Zugmonitor.Test
{
    [TestClass]
    public class Tests
    {

#if local_test
        [TestMethod]
        public void StationTest()
        {
            var provider = new ServiceProvier(Getter);
            var result = provider.GetStations();
        }

        [TestMethod]
        public void TrainTest()
        {
            var provider = new ServiceProvier(Getter);
            var result = provider.GetTrains(DateTime.MaxValue);
        }

        private string Getter(Uri arg)
        {
            if (arg.ToString().Equals(@"http://zugmonitor.sueddeutsche.de/api/stations", StringComparison.Ordinal))
            {
                return File.ReadAllText("stations.txt");
            }

            if(arg.ToString().StartsWith(@"http://zugmonitor.sueddeutsche.de/api/trains/", StringComparison.Ordinal))
            {
                return File.ReadAllText("trains.txt");
            }

            return string.Empty;
        }
#else
        [TestMethod]
        public void StationTest()
        {
            var provider = new ServiceProvier();
            var result = provider.GetStations();
        }

        [TestMethod]
        public void TrainTest()
        {
            var provider = new ServiceProvier();
            var result = provider.GetTrains(DateTime.Now);
        }
#endif
    }
}