using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class QuotationRequest
    {
        public Guid RFQID { get; set; } // Unique identifier for the RFQ.
        public string RFQNumber { get; set; } // RFQ number for easy reference.
        public DateTime DateIssued { get; set; } // Date when the RFQ was issued.
        public DateTime SubmissionDeadline { get; set; } // Deadline for suppliers to submit quotations.
        public string? IssuingCompanyName { get; set; } // Name of the company issuing the RFQ.
        public string? IssuingCompanyAddress { get; set; } // Address of the issuing company.
        public string? ProcurementContactName { get; set; } // Name of the procurement contact.
        public string? ProcurementContactEmail { get; set; } // Email of the procurement contact.
        public string? ProcurementContactPhone { get; set; } // Phone number of the procurement contact.

        // List of required products or services with specifications
        public List<QuotationRequestItem> Items { get; set; }

        public string PaymentTerms { get; set; } // Terms for payment (e.g., Net 30).
        public string DeliveryRequirements { get; set; } // Delivery location and deadline.
        public string WarrantyRequirements { get; set; } // Details about any required warranties.
        public string LegalAndComplianceTerms { get; set; } // Compliance requirements.

        // Evaluation criteria for quotations
        public string EvaluationCriteria { get; set; } // Explanation of evaluation criteria.
        public string PricingStructure { get; set; } // Instructions on how suppliers should structure pricing.
        public string SubmissionFormat { get; set; } // Format for submitting the quotation.
        public List<string> RequiredDocuments { get; set; } // Documents required for submission.

        // Confidentiality and NDA terms
        public bool IsConfidential { get; set; } // Whether this RFQ requires an NDA.
        public string ConfidentialityClause { get; set; } // Confidentiality terms.
    }
}
