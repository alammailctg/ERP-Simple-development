using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class Report
    {
        public int ReportId { get; set; } // Unique identifier for the report
        public string Title { get; set; } // Title of the report
        public DateTime CreatedDate { get; set; } // Date the report was created
        public string Author { get; set; } // Author of the report
        public string Description { get; set; } // Description of the report
        public List<ReportMetric> Metrics { get; set; } // List of metrics included in the report
        public string Status { get; set; } // Status of the report (e.g., Draft, Final, Archived)

        public Report()
        {
            Metrics = new List<ReportMetric>();
            CreatedDate = DateTime.Today; // Default to today
        }

        // Method to add a metric to the report
        public void AddMetric(ReportMetric metric)
        {
            Metrics.Add(metric);
        }
    }
}
