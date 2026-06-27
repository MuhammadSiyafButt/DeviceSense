using System;

namespace DeviceSense.Core.Models.Performance
{
    public class CpuInfo
    {
        public string Name { get; set; } = string.Empty;
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public double UsagePercent { get; set; }
        public double TemperatureCelsius { get; set; }
        public double ClockSpeedMHz { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}