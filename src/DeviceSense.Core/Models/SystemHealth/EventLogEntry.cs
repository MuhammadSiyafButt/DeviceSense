using System;

namespace DeviceSense.Core.Models.SystemHealth
{
    public enum EventLogLevel
    {
        Information,
        Warning,
        Error,
        Critical
    }

    public class EventLogEntry
    {
        public int EventId { get; set; }
        public string Source { get; set; } = string.Empty;
        public EventLogLevel Level { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}