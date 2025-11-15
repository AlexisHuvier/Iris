using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class HeartBeat
    {
        public HeartBeatStatus Status { get; set; } = HeartBeatStatus.Pending;
        public DateTime Time { get; set; }
        public string Msg { get; set; } = string.Empty;
        public int? Ping { get; set; } = null;
    }

    public enum HeartBeatStatus
    {
        Down,
        Up,
        Pending,
        Maintenance
    }
}
