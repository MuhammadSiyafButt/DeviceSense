using System;

namespace DeviceSense.Core.Models.Security
{
    public enum DriverHealthState
    {
        UpToDate,
        Outdated,
        Missing,
        Faulty
    }

    public class DriverInfo
    {
        public string DeviceName { get; set; } = string.Empty;
        public string DriverVersion { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public DateTime? DriverDate { get; set; }
        public DriverHealthState HealthState { get; set; }
    }
}