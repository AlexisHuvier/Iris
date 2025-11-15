using Iris.Model.UptimeKuma;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Iris.Service
{
    public class UptimeKumaService
    {
        private static HttpClient httpClient = new();
        private static JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new HeartBeatDateTimeConverter()
            }
        };

        public static List<UptimeMonitorResponse> CallUptime(string pageName)
        {


            var statusPage = httpClient.GetFromJsonAsync<StatusPage>($"https://uptime.lavapower.fr/api/status-page/{pageName}", jsonSerializerOptions).GetAwaiter().GetResult();
            var heartBeats = httpClient.GetFromJsonAsync<HeartBeats>($"https://uptime.lavapower.fr/api/status-page/heartbeat/{pageName}", jsonSerializerOptions).GetAwaiter().GetResult();

            if(statusPage == null || heartBeats == null)
            {
                throw new Exception("Failed to retrieve data from Uptime Kuma API.");
            }

            return UptimeMonitorResponse.BuildResponse(statusPage, heartBeats);
        }
    }
}
