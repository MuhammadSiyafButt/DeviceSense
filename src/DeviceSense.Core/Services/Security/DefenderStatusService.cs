using System;
using System.Text.Json;
using System.Threading.Tasks;
using DeviceSense.Core.Helpers;
using DeviceSense.Core.Models.Security;

namespace DeviceSense.Core.Services.Security
{
    public class DefenderStatusService
    {
        public async Task<SecurityStatus> GetStatusAsync()
        {
            var status = new SecurityStatus();

            string output = await PowerShellRunner.RunScriptAsync(
                "Get-MpComputerStatus | Select-Object AntivirusEnabled,RealTimeProtectionEnabled,AntispywareSignatureLastUpdated | ConvertTo-Json");

            if (!string.IsNullOrWhiteSpace(output))
            {
                try
                {
                    using var doc = JsonDocument.Parse(output);
                    var root = doc.RootElement;

                    status.DefenderEnabled = TryGetBool(root, "AntivirusEnabled");
                    status.RealTimeProtectionEnabled = TryGetBool(root, "RealTimeProtectionEnabled");

                    if (root.TryGetProperty("AntispywareSignatureLastUpdated", out var sigDate) &&
                        DateTime.TryParse(sigDate.ToString(), out var parsedDate))
                    {
                        status.VirusDefinitionsUpToDate = (DateTime.Now - parsedDate).TotalDays < 7;
                    }
                }
                catch (JsonException)
                {
                    // Defender output couldn't be parsed; defaults remain
                }
            }

            status.FirewallEnabled = await CheckFirewallAsync();
            status.Timestamp = DateTime.Now;

            return status;
        }

        private static bool TryGetBool(JsonElement root, string propertyName) =>
            root.TryGetProperty(propertyName, out var prop) && prop.ValueKind == JsonValueKind.True;

        private static async Task<bool> CheckFirewallAsync()
        {
            string output = await PowerShellRunner.RunScriptAsync(
                "(Get-NetFirewallProfile -Profile Domain,Public,Private | Where-Object {$_.Enabled -eq 'True'}).Count");

            return int.TryParse(output.Trim(), out var enabledCount) && enabledCount > 0;
        }
    }
}