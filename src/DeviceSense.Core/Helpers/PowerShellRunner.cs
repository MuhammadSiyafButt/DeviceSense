using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSense.Core.Helpers
{
    public static class PowerShellRunner
    {
        public static async Task<string> RunScriptAsync(string script)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using var process = Process.Start(psi);
                if (process == null)
                    return string.Empty;

                var output = new StringBuilder();
                output.Append(await process.StandardOutput.ReadToEndAsync());

                await process.WaitForExitAsync();
                return output.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"PowerShell run failed: {ex.Message}");
                return string.Empty;
            }
        }

        public static async Task<string> RunCommandAsync(string fileName, string arguments)
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using var process = Process.Start(psi);
                if (process == null)
                    return string.Empty;

                string output = await process.StandardOutput.ReadToEndAsync();
                await process.WaitForExitAsync();
                return output;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Command run failed ({fileName}): {ex.Message}");
                return string.Empty;
            }
        }
    }
}