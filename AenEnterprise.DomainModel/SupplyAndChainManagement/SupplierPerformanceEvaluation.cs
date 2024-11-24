using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class SupplierPerformanceEvaluation
    {
        public int EvaluationId { get; set; } // Unique identifier for the evaluation

        public int SupplierId { get; set; } // Unique identifier for the supplier being evaluated

        public DateTime EvaluationDate { get; set; } = DateTime.Now; // Date when the evaluation is conducted

        public int Rating { get; set; } // Rating score for the supplier (e.g., 1 to 5 scale)

        public string Evaluator { get; set; } // Name of the person conducting the evaluation

        public string Comments { get; set; } // Additional comments regarding the supplier's performance

        // Performance Metrics
        public decimal QualityScore { get; set; } // Score for product/service quality

        public decimal TimelinessScore { get; set; } // Score for delivery timeliness

        public decimal CommunicationScore { get; set; } // Score for communication effectiveness

        public decimal ResponsivenessScore { get; set; } // Score for responsiveness to inquiries/issues

        // Overall performance assessment
        public string OverallAssessment { get; set; } // General assessment of the supplier's performance

        // Method to calculate average score
        public decimal AverageScore
        {
            get
            {
                var scores = new List<decimal>
            {
                QualityScore,
                TimelinessScore,
                CommunicationScore,
                ResponsivenessScore
            };

                return scores.Count > 0 ? scores.Average() : 0;
            }
        }

        // Method to display the evaluation summary
        public string GetEvaluationSummary()
        {
            return $"Evaluation ID: {EvaluationId}\n" +
                   $"Supplier ID: {SupplierId}\n" +
                   $"Evaluation Date: {EvaluationDate.ToShortDateString()}\n" +
                   $"Evaluator: {Evaluator}\n" +
                   $"Quality Score: {QualityScore}\n" +
                   $"Timeliness Score: {TimelinessScore}\n" +
                   $"Communication Score: {CommunicationScore}\n" +
                   $"Responsiveness Score: {ResponsivenessScore}\n" +
                   $"Average Score: {AverageScore:F2}\n" +
                   $"Overall Assessment: {OverallAssessment}\n" +
                   $"Comments: {Comments}\n";
        }
    }

}
