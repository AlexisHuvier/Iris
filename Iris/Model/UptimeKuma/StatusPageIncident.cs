using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class StatusPageIncident
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Style { get; set; } = "info";
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
        public DateTime LastUpdatedDate { get; set; } = DateTime.MinValue;
        public bool Pin { get; set; } = false;
    }
}
