using System;

namespace DeviceSense.Core.Models.Performance
{
    public class RamInfo
    {
        public long TotalCapacityBytes { get; set; }
        public long UsedBytes { get; set; }
        public long AvailableBytes { get; set; }
        public int SpeedMHz { get; set; }
        public int SlotsUsed { get; set; }
        public int SlotsTotal { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public double UsagePercent =>
            TotalCapacityBytes > 0 ? (UsedBytes * 100.0 / TotalCapacityBytes) : 0;
    }
}