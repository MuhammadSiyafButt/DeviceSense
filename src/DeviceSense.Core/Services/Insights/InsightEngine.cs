using System.Collections.Generic;
using System.Linq;
using DeviceSense.Core.Models;
using DeviceSense.Core.Services.Insights.Rules;

namespace DeviceSense.Core.Services.Insights
{
    public class InsightEngine
    {
        private readonly List<IInsightRule> _rules;

        public InsightEngine(IEnumerable<IInsightRule> rules)
        {
            _rules = rules.ToList();
        }

        public List<Insight> GenerateInsights(SystemSnapshot snapshot)
        {
            var insights = new List<Insight>();

            foreach (var rule in _rules)
            {
                try
                {
                    insights.AddRange(rule.Evaluate(snapshot));
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Insight rule '{rule.GetType().Name}' failed: {ex.Message}");
                }
            }

            snapshot.Insights = insights;
            return insights;
        }
    }
}