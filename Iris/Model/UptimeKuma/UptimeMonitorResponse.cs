using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class UptimeMonitorResponse
    {
        public StatusPageMonitor Monitor { get; set; } = new StatusPageMonitor();
        public List<HeartBeat> Heartbeats { get; set; } = [];
        public float Uptime { get; set; } = 0.0f;

        public static List<UptimeMonitorResponse> BuildResponse(StatusPage page, HeartBeats heartBeats)
        {
            List<UptimeMonitorResponse> response = [];
            foreach (var group in page.PublicGroupList)
            {
                foreach (var monitor in group.MonitorList)
                {
                    response.Add(new UptimeMonitorResponse()
                    {
                        Monitor = monitor,
                        Heartbeats = heartBeats.HeartbeatList.TryGetValue(monitor.Id.ToString(), out var beats) ? beats : [],
                        Uptime = heartBeats.UptimeList.TryGetValue($"{monitor.Id}_24", out var uptime) ? uptime : -1f
                    });
                }
            }
            return response;
        }
    }

}
