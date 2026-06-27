using System.Collections.Generic;
using System.Linq;
using DeviceSense.Core.Models;
using DeviceSense.Core.Models.Security;

namespace DeviceSense.Core.Services.Insights.Rules
{
    public class SecurityInsightRule : IInsightRule
    {
        public InsightCategory Category => InsightCategory.Security;

        public IEnumerable<Insight> Evaluate(SystemSnapshot snapshot)
        {
            var insights = new List<Insight>();
            var security = snapshot.Security;

            if (security == null)
                return insights;

            if (!security.DefenderEnabled)
            {
                insights.Add(new Insight
                {
                    Title = "Antivirus Disabled",
                    Description = "Windows Defender is currently disabled on this device.",
                    Category = InsightCategory.Security,
                    Severity = InsightSeverity.Critical,
                    RecommendedAction = "Enable Windows Defender or install another antivirus solution."
                });
            }

            if (!security.FirewallEnabled)
            {
                insights.Add(new Insight
                {
                    Title = "Firewall Disabled",
                    Description = "No active firewall profile was detected.",
                    Category = InsightCategory.Security,
                    Severity = InsightSeverity.Warning,
                    RecommendedAction = "Enable Windows Firewall for your active network profile."
                });
            }

            if (!security.VirusDefinitionsUpToDate)
            {
                insights.Add(new Insight
                {
                    Title = "Outdated Virus Definitions",
                    Description = "Antivirus signature definitions have not been updated recently.",
                    Category = InsightCategory.Security,
                    Severity = InsightSeverity.Warning,
                    RecommendedAction = "Run Windows Update or update virus definitions manually."
                });
            }

            int outdatedDrivers = snapshot.Drivers.Count(d => d.HealthState == DriverHealthState.Outdated);
            if (outdatedDrivers > 0)
            {
                insights.Add(new Insight
                {
                    Title = $"{outdatedDrivers} Outdated Driver(s)",
                    Description = $"{outdatedDrivers} installed driver(s) appear older than 3 years.",
                    Category = InsightCategory.Security,
                    Severity = InsightSeverity.Info,
                    RecommendedAction = "Check Windows Update or manufacturer site for newer drivers."
                });
            }

            return insights;
        }
    }
}