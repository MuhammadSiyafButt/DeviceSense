using System;
using System.Collections.Generic;
using System.Management;

namespace DeviceSense.Core.Helpers
{
    public static class WmiHelper
    {
        public static List<Dictionary<string, object?>> Query(
            string wmiClass,
            string scope = @"root\cimv2",
            IEnumerable<string>? properties = null)
        {
            var results = new List<Dictionary<string, object?>>();

            try
            {
                string selectClause = properties != null ? string.Join(", ", properties) : "*";
                using var searcher = new ManagementObjectSearcher(scope, $"SELECT {selectClause} FROM {wmiClass}");

                foreach (ManagementObject obj in searcher.Get())
                {
                    var row = new Dictionary<string, object?>();
                    foreach (var prop in obj.Properties)
                    {
                        row[prop.Name] = prop.Value;
                    }
                    results.Add(row);
                    obj.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"WMI query failed for {wmiClass}: {ex.Message}");
            }

            return results;
        }

        public static T? GetValue<T>(Dictionary<string, object?> row, string key, T? defaultValue = default)
        {
            if (row.TryGetValue(key, out var value) && value != null)
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
            return defaultValue;
        }
    }
}