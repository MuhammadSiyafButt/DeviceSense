using System;

namespace DeviceSense.Core.Models
{
    public enum InsightSeverity
    {
        Info,
        Warning,
        Critical
    }

    public enum InsightCategory
    {
        Performance,
        Storage,
        Battery,
        Network,
        Security,
        SystemHealth,
        Peripherals
    }

    public class Insight
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public InsightCategory Category { get; set; }
        public InsightSeverity Severity { get; set; }
        public string? RecommendedAction { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
}