using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class Analysis
    {
        public int AnalysisId { get; set; } // Unique identifier for the analysis
        public DateTime AnalysisDate { get; set; } // Date of the analysis
        public string Analyst { get; set; } // Name of the analyst
        public string Methodology { get; set; } // Method used for analysis (e.g., Statistical, Predictive)
        public List<AnalysisResult> Results { get; set; } // List of results from the analysis

        public Analysis()
        {
            Results = new List<AnalysisResult>();
            AnalysisDate = DateTime.Today; // Default to today
        }

        // Method to add a result to the analysis
        public void AddResult(AnalysisResult result)
        {
            Results.Add(result);
        }
        public void GenerateReportAndConductAnalysis()
        {
            // Create a new report
            Report report = new Report
            {
                Title = "Quarterly Financial Overview",
                Author = "Jane Smith",
                Description = "A comprehensive overview of financial performance for Q1.",
                Status = "Final"
            };

            // Add metrics to the report
            report.AddMetric(new ReportMetric("Total Revenue", 150000m, "Total revenue generated in Q1."));
            report.AddMetric(new ReportMetric("Net Profit", 50000m, "Net profit after expenses."));

            // Display the report details
            Console.WriteLine($"Report ID: {report.ReportId}, Title: {report.Title}, Created: {report.CreatedDate.ToShortDateString()}, Author: {report.Author}");
            foreach (var metric in report.Metrics)
            {
                Console.WriteLine($"Metric: {metric.MetricName}, Value: {metric.Value}, Description: {metric.Description}");
            }

            // Create a new analysis
            Analysis analysis = new Analysis
            {
                Analyst = "John Doe",
                Methodology = "Statistical",
            };

            // Add results to the analysis
            analysis.AddResult(new AnalysisResult("Growth Rate", 10.5m, "Year-over-year growth rate."));
            analysis.AddResult(new AnalysisResult("Expense Ratio", 33.3m, "Percentage of expenses relative to revenue."));

            // Display analysis details
            Console.WriteLine($"\nAnalysis ID: {analysis.AnalysisId}, Date: {analysis.AnalysisDate.ToShortDateString()}, Analyst: {analysis.Analyst}, Methodology: {analysis.Methodology}");
            foreach (var result in analysis.Results)
            {
                Console.WriteLine($"Result: {result.ResultName}, Value: {result.Value}, Interpretation: {result.Interpretation}");
            }
        }

    }
}
