using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class ProcurementProcessReview
    {
        public int ReviewId { get; set; } // Unique identifier for the procurement process review

        public DateTime ReviewDate { get; set; } = DateTime.Now; // Date of the review

        public string ReviewedBy { get; set; } // Name of the individual conducting the review

        public string Department { get; set; } // Department involved in the procurement process

        public string ReviewSummary { get; set; } // Summary of the procurement process review

        public List<string> IdentifiedIssues { get; set; } = new List<string>(); // List of issues identified during the review

        public List<string> ImprovementSuggestions { get; set; } = new List<string>(); // Suggestions for improving the procurement process

        public string OverallAssessment { get; set; } // Overall assessment of the procurement process

        public decimal CostSavingsIdentified { get; set; } // Estimated cost savings identified during the review

        // Method to display a summary of the review
        public string GetReviewSummary()
        {
            var issues = string.Join("\n", IdentifiedIssues);
            var suggestions = string.Join("\n", ImprovementSuggestions);

            return $"Review ID: {ReviewId}\n" +
                   $"Review Date: {ReviewDate.ToShortDateString()}\n" +
                   $"Reviewed By: {ReviewedBy}\n" +
                   $"Department: {Department}\n" +
                   $"Summary: {ReviewSummary}\n" +
                   $"Identified Issues:\n{(IdentifiedIssues.Count > 0 ? issues : "None")}\n" +
                   $"Improvement Suggestions:\n{(ImprovementSuggestions.Count > 0 ? suggestions : "None")}\n" +
                   $"Overall Assessment: {OverallAssessment}\n" +
                   $"Estimated Cost Savings: {CostSavingsIdentified:C}\n";
        }
    }

}
