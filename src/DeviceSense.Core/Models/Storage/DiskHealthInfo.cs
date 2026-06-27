using System;

namespace DeviceSense.Core.Models.Storage
{
    public enum DiskHealthState
    {
        Healthy,
        Warning,
        Critical,
        Unknown
    }

    public class DiskHealthInfo
    {
        public string DriveLetter { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public long TotalSizeBytes { get; set; }
        public long UsedSpaceBytes { get; set; }
        public long FreeSpaceBytes { get; set; }
        public double TemperatureCelsius { get; set; }
        public int PowerOnHours { get; set; }
        public bool IsSsd { get; set; }
        public DiskHealthState HealthState { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public double UsedPercent =>
            TotalSizeBytes > 0 ? (UsedSpaceBytes * 100.0 / TotalSizeBytes) : 0;
    }
}