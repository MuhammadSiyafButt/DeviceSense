using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace DeviceSense.Core.Helpers
{
    public static class RegistryHelper
    {
        public static string? GetStringValue(RegistryHive hive, string subKeyPath, string valueName)
        {
            try
            {
                using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
                using var subKey = baseKey.OpenSubKey(subKeyPath);
                return subKey?.GetValue(valueName)?.ToString();
            }
            catch
            {
                return null;
            }
        }

        public static IEnumerable<string> GetSubKeyNames(RegistryHive hive, string subKeyPath)
        {
            try
            {
                using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
                using var subKey = baseKey.OpenSubKey(subKeyPath);
                return subKey?.GetSubKeyNames() ?? Array.Empty<string>();
            }
            catch
            {
                return Array.Empty<string>();
            }
        }
    }
}