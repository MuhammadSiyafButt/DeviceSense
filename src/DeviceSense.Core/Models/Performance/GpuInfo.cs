using System;

namespace DeviceSense.Core.Models.Performance
{
    public class GpuInfo
    {
        public string Name { get; set; } = string.Empty;
        public double UsagePercent { get; set; }
        public double TemperatureCelsius { get; set; }
        public long DedicatedMemoryBytes { get; set; }
        public long UsedMemoryBytes { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public double MemoryUsagePercent =>
            DedicatedMemoryBytes > 0 ? (UsedMemoryBytes * 100.0 / DedicatedMemoryBytes) : 0;
    }
}