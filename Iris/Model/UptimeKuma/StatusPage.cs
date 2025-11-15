using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class StatusPage
    {
        public StatusPageConfig Config { get; set; } = new();
        public StatusPageIncident? Incident { get; set; } = null;
        public List<StatusPageMonitorGroup> PublicGroupList { get; set; } = [];
        public List<StatusPageMaintenance> MaintenanceList { get; set; } = [];
    }
}
