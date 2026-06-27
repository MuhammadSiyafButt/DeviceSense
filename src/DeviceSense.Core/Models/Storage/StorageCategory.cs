using System;
using System.Collections.Generic;

namespace DeviceSense.Core.Models.Storage
{
    public enum StorageCategoryType
    {
        SystemFiles,
        Apps,
        Documents,
        Media,
        Downloads,
        JunkFiles,
        Other
    }

    public class StorageCategory
    {
        public StorageCategoryType Type { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public int FileCount { get; set; }
        public List<string> TopPaths { get; set; } = new();
    }
}