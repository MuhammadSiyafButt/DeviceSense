using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using DeviceSense.Core.Helpers;
using DeviceSense.Core.Models.Peripherals;

namespace DeviceSense.Core.Services.Peripherals
{
    public class InstalledAppsService
    {
        private static readonly string[] UninstallPaths =
        {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

        public List<InstalledAppInfo> GetInstalledApps()
        {
            var apps = new List<InstalledAppInfo>();

            foreach (var path in UninstallPaths)
            {
                foreach (var subKeyName in RegistryHelper.GetSubKeyNames(RegistryHive.LocalMachine, path))
                {
                    string fullPath = $"{path}\\{subKeyName}";
                    string? displayName = RegistryHelper.GetStringValue(RegistryHive.LocalMachine, fullPath, "DisplayName");

                    if (string.IsNullOrWhiteSpace(displayName))
                        continue;

                    apps.Add(new InstalledAppInfo
                    {
                        Name = displayName,
                        Publisher = RegistryHelper.GetStringValue(RegistryHive.LocalMachine, fullPath, "Publisher") ?? "",
                        Version = RegistryHelper.GetStringValue(RegistryHive.LocalMachine, fullPath, "DisplayVersion") ?? "",
                        InstallLocation = RegistryHelper.GetStringValue(RegistryHive.LocalMachine, fullPath, "InstallLocation") ?? "",
                        SizeBytes = ParseEstimatedSizeKb(RegistryHelper.GetStringValue(RegistryHive.LocalMachine, fullPath, "EstimatedSize")),
                        InstallDate = ParseInstallDate(RegistryHelper.GetStringValue(RegistryHive.LocalMachine, fullPath, "InstallDate"))
                    });
                }
            }

            return apps.GroupBy(a => a.Name).Select(g => g.First()).OrderBy(a => a.Name).ToList();
        }

        private static long ParseEstimatedSizeKb(string? rawKb) =>
            long.TryParse(rawKb, out var kb) ? kb * 1024 : 0;

        private static DateTime? ParseInstallDate(string? raw)
        {
            if (!string.IsNullOrEmpty(raw) && raw.Length == 8 &&
                DateTime.TryParseExact(raw, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
            return null;
        }
    }
}