using System;
using System.Collections.Generic;
using DeviceSense.Core.Helpers;
using DeviceSense.Core.Models.Peripherals;

namespace DeviceSense.Core.Services.Peripherals
{
    public class DeviceListService
    {
        public List<DeviceInfo> GetDevices()
        {
            var devices = new List<DeviceInfo>();
            var rows = WmiHelper.Query(
                "Win32_PnPEntity",
                properties: new[] { "Name", "Manufacturer", "Status", "PNPClass", "ConfigManagerErrorCode" });

            foreach (var row in rows)
            {
                string name = WmiHelper.GetValue<string>(row, "Name", "Unknown") ?? "Unknown";
                int errorCode = WmiHelper.GetValue<int>(row, "ConfigManagerErrorCode", 0);
                string status = WmiHelper.GetValue<string>(row, "Status", "") ?? "";

                devices.Add(new DeviceInfo
                {
                    Name = name,
                    Manufacturer = WmiHelper.GetValue<string>(row, "Manufacturer", "") ?? "",
                    DeviceClass = WmiHelper.GetValue<string>(row, "PNPClass", "") ?? "",
                    DriverInstalled = errorCode != 28, // 28 = driver not installed
                    Status = MapStatus(status, errorCode)
                });
            }

            return devices;
        }

        private static DeviceStatus MapStatus(string status, int errorCode)
        {
            if (errorCode == 22) return DeviceStatus.Disabled;
            if (errorCode != 0) return DeviceStatus.Error;
            if (string.Equals(status, "OK", StringComparison.OrdinalIgnoreCase)) return DeviceStatus.Working;
            return DeviceStatus.Unknown;
        }
    }
}