using System;
using System.Collections.Generic;
using DeviceSense.Core.Models.Performance;
using DeviceSense.Core.Models.Battery;
using DeviceSense.Core.Models.Storage;
using DeviceSense.Core.Models.Network;
using DeviceSense.Core.Models.Security;
using DeviceSense.Core.Models.SystemHealth;
using DeviceSense.Core.Models.Peripherals;

namespace DeviceSense.Core.Models
{
    public class SystemSnapshot
    {
        public DateTime CapturedAt { get; set; } = DateTime.Now;

        // Performance
        public CpuInfo? Cpu { get; set; }
        public RamInfo? Ram { get; set; }
        public GpuInfo? Gpu { get; set; }
        public List<SensorReading> Sensors { get; set; } = new();

        // Battery
        public BatteryInfo? Battery { get; set; }

        // Storage
        public List<DiskHealthInfo> Disks { get; set; } = new();
        public List<StorageCategory> StorageBreakdown { get; set; } = new();
        public List<JunkFileInfo> JunkFiles { get; set; } = new();

        // Network
        public WifiInfo? Wifi { get; set; }
        public BandwidthInfo? Bandwidth { get; set; }

        // Security
        public SecurityStatus? Security { get; set; }
        public List<DriverInfo> Drivers { get; set; } = new();

        // System Health
        public List<StartupItem> StartupItems { get; set; } = new();
        // TODO: UpdateInfo aur EventLogEntry models banne ke baad yahan add karna:
         public List<UpdateInfo> PendingUpdates { get; set; } = new();
         public List<EventLogEntry> RecentEvents { get; set; } = new();

        // Peripherals
        public List<DeviceInfo> Devices { get; set; } = new();
        // TODO: public List<InstalledAppInfo> InstalledApps { get; set; } = new();

        // Insights (rule engine output)
        public List<Insight> Insights { get; set; } = new();
    }
}