using System;
using System.Collections.Generic;
using DeviceSense.Core.Helpers;
using DeviceSense.Core.Models.Security;

namespace DeviceSense.Core.Services.Security
{
    public class DriverHealthService
    {
        public List<DriverInfo> GetDrivers()
        {
            var drivers = new List<DriverInfo>();
            var rows = WmiHelper.Query(
                "Win32_PnPSignedDriver",
                properties: new[] { "DeviceName", "DriverVersion", "Manufacturer", "DriverDate" });

            foreach (var row in rows)
            {
                string name = WmiHelper.GetValue<string>(row, "DeviceName", "") ?? "";
                if (string.IsNullOrWhiteSpace(name))
                    continue;

                DateTime? driverDate = ParseWmiDate(WmiHelper.GetValue<string>(row, "DriverDate", null));

                drivers.Add(new DriverInfo
                {
                    DeviceName = name,
                    DriverVersion = WmiHelper.GetValue<string>(row, "DriverVersion", "") ?? "",
                    Manufacturer = WmiHelper.GetValue<string>(row, "Manufacturer", "") ?? "",
                    DriverDate = driverDate,
                    HealthState = EvaluateHealth(driverDate)
                });
            }

            return drivers;
        }

        private static DateTime? ParseWmiDate(string? wmiDate)
        {
            // WMI date format: yyyyMMddHHmmss.ffffff+UUU
            if (!string.IsNullOrEmpty(wmiDate) && wmiDate.Length >= 8 &&
                DateTime.TryParseExact(wmiDate[..8], "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
            return null;
        }

        private static DriverHealthState EvaluateHealth(DateTime? driverDate)
        {
            if (driverDate == null) return DriverHealthState.Missing;
            double ageYears = (DateTime.Now - driverDate.Value).TotalDays / 365;
            return ageYears > 3 ? DriverHealthState.Outdated : DriverHealthState.UpToDate;
        }
    }
}