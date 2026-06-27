using System;

namespace DeviceSense.Core.Models.Peripherals
{
    public class InstalledAppInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public DateTime? InstallDate { get; set; }
        public string InstallLocation { get; set; } = string.Empty;
    }
}