namespace DeviceSense.Core.Models.Peripherals
{
    public enum DeviceStatus
    {
        Working,
        Error,
        Disabled,
        Unknown
    }

    public class DeviceInfo
    {
        public string Name { get; set; } = string.Empty;
        public string DeviceClass { get; set; } = string.Empty; // "USB", "HID", "Printer" waghera
        public string Manufacturer { get; set; } = string.Empty;
        public DeviceStatus Status { get; set; }
        public bool DriverInstalled { get; set; }
    }
}