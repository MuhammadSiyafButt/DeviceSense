using System;

namespace DeviceSense.Core.Models.Performance
{
    public enum SensorType
    {
        Temperature,
        Fan,
        Voltage,
        Power,
        Clock,
        Load
    }

    public class SensorReading
    {
        public string Name { get; set; } = string.Empty;
        public SensorType Type { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string HardwareSource { get; set; } = string.Empty; // e.g. "CPU", "GPU", "Motherboard"
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}