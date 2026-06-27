using System;

namespace DeviceSense.Core.Models.Battery
{
    public class BatteryInfo
    {
        public int ChargePercent { get; set; }
        public bool IsCharging { get; set; }
        public int DesignCapacityMWh { get; set; }
        public int FullChargeCapacityMWh { get; set; }

        public double HealthPercent =>
            DesignCapacityMWh > 0
                ? (FullChargeCapacityMWh * 100.0 / DesignCapacityMWh)
                : 0;

        public int CycleCount { get; set; }
        public TimeSpan? EstimatedTimeRemaining { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}