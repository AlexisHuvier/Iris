using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class HeartBeats
    {
        public Dictionary<string, List<HeartBeat>> HeartbeatList { get; set; } = [];
        public Dictionary<string, float> UptimeList { get; set; } = [];
    }
}
