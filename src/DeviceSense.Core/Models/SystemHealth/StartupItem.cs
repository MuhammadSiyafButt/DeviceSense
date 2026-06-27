namespace DeviceSense.Core.Models.SystemHealth
{
    public enum StartupImpact
    {
        Low,
        Medium,
        High,
        Unknown
    }

    public class StartupItem
    {
        public string Name { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string ExecutablePath { get; set; } = string.Empty;
        public string RegistryOrLocation { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
        public StartupImpact Impact { get; set; }
    }
}