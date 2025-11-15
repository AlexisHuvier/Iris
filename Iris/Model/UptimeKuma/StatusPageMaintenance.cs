using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class StatusPageMaintenance
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Stategy { get; set; } = "single";
        public int? IntervalDay { get; set; } = null;
        public bool Active { get; set; } = false;
        public List<DateTime> DateRange { get; set; } = [];
        public string Status { get; set; } = "scheduled";
    }
}
