using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class ReportMetric
    {
        public string MetricName { get; set; } // Name of the metric
        public decimal Value { get; set; } // Value of the metric
        public string Description { get; set; } // Description of the metric

        public ReportMetric(string metricName, decimal value, string description)
        {
            MetricName = metricName;
            Value = value;
            Description = description;
        }
    }
}
