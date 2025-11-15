using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Model.UptimeKuma
{
    public class StatusPageConfig
    {
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int AutoRefreshInterval { get; set; } = 0;
        public string Theme { get; set; } = "light";
        public bool Published { get; set; } = false;
        public bool ShowTags { get; set; } = true;
        public string CustomCSS { get; set; } = string.Empty;
        public string FooterText { get; set; } = string.Empty;
        public bool ShowPoweredBy { get; set; } = true;
        public int? GoogleAnalyticsId { get; set; } = null;
        public bool ShowCertificateExpiry { get; set; } = false;
    }
}
