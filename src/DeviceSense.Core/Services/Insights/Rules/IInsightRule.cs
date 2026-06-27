using System.Collections.Generic;
using DeviceSense.Core.Models;

namespace DeviceSense.Core.Services.Insights.Rules
{
    public interface IInsightRule
    {
        InsightCategory Category { get; }

        IEnumerable<Insight> Evaluate(SystemSnapshot snapshot);
    }
}