using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChangeBackground.Util
{
    class ApodResult
    {
        public string date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }

    class Apod
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Apod));

        private static readonly Uri apodEndpointUri = new Uri("https://api.nasa.gov/planetary/apod");

        public static ApodResult GetDailyData()
        {
            WebClient client = new WebClient();
            client.QueryString.Add("api_key", "DEMO_KEY");

            logger.Debug("Starting image download.");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            String apodString = client.DownloadString(apodEndpointUri);
            logger.Debug($"Image downloaded in {watch.ElapsedMilliseconds} millis");

            return JsonConvert.DeserializeObject<ApodResult>(apodString);
        }
    }
}
