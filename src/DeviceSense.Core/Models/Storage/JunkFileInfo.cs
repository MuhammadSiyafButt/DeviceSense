using System;

namespace DeviceSense.Core.Models.Storage
{
    public enum JunkFileType
    {
        TempFile,
        CacheFile,
        LogFile,
        RecycleBin,
        BrowserCache,
        WindowsUpdateLeftover
    }

    public class JunkFileInfo
    {
        public string FilePath { get; set; } = string.Empty;
        public JunkFileType Type { get; set; }
        public long SizeBytes { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsSafeToDelete { get; set; }
    }
}