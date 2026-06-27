using System;

namespace DeviceSense.Core.Models.SystemHealth
{
    public enum UpdateStatus
    {
        Installed,
        Pending,
        Failed,
        Unknown
    }

    public class UpdateInfo
    {
        public string Title { get; set; } = string.Empty;
        public string KbArticle { get; set; } = string.Empty;
        public UpdateStatus Status { get; set; }
        public DateTime? InstalledOn { get; set; }
        public bool RequiresRestart { get; set; }
    }
}