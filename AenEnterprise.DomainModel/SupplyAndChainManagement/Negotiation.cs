using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class Negotiation
    {
        public Guid NegotiationID { get; set; }
        public Guid RFQID { get; set; } // Reference to the associated RFQ.
        public Guid SupplierID { get; set; }

        // Initial Terms
        public decimal InitialPrice { get; set; } // Initial price quoted by the supplier.
        public string InitialPaymentTerms { get; set; } // Initial payment terms offered.
        public string InitialDeliveryTerms { get; set; } // Initial delivery terms proposed.
        public string InitialWarrantyTerms { get; set; } // Initial warranty terms offered.

        // Revised Terms (after negotiation)
        public decimal RevisedPrice { get; set; } // Revised price after negotiation.
        public string RevisedPaymentTerms { get; set; } // Revised payment terms.
        public string RevisedDeliveryTerms { get; set; } // Revised delivery terms.
        public string RevisedWarrantyTerms { get; set; } // Revised warranty terms.

        // Negotiation Details
        public DateTime NegotiationStartDate { get; set; } // Date when negotiation started.
        public DateTime NegotiationEndDate { get; set; } // Date when negotiation concluded.
        public string NegotiationStatus { get; set; } // Status of negotiation (e.g., "In Progress", "Completed", "Cancelled").
        public string Outcome { get; set; } // Summary of the negotiation outcome (e.g., "Terms Agreed", "No Agreement").
        public string AdditionalConditions { get; set; } // Any additional conditions agreed upon during negotiation.
        public string Notes { get; set; } // Additional notes about the negotiation process.

        // Constructor
        public Negotiation()
        {
            NegotiationID = Guid.NewGuid();
            NegotiationStartDate = DateTime.Now;
        }
    }
}
