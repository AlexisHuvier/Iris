using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{

    public class StatusPageMonitor
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int SendUrl { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        public string? Url { get; set; } = null;
    }

    public class StatusPageMonitorGroup
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Weight { get; set; } = 0;
        public List<StatusPageMonitor> MonitorList { get; set; } = [];
    }
}
