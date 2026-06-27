using System;

namespace DeviceSense.Core.Models.Security
{
    public class SecurityStatus
    {
        public bool DefenderEnabled { get; set; }
        public bool RealTimeProtectionEnabled { get; set; }
        public bool FirewallEnabled { get; set; }
        public bool VirusDefinitionsUpToDate { get; set; }
        public DateTime? LastQuickScan { get; set; }
        public DateTime? LastFullScan { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}