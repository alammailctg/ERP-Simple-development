using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class SupplierAcknowledgment
    {
        public Guid Id { get; set; }
        public Guid QuotationRequestId { get; set; } // Reference to the associated RFQ.
        public Guid SupplierId { get; set; } // Reference to the supplier providing the acknowledgment.

        // Acknowledgment Details
        public DateTime AcknowledgmentDate { get; set; }
        public bool IsAccepted { get; set; }
        public string AcceptedTerms { get; set; }
        public string Comments { get; set; }

        // Contact Information
        public string ContactName { get; set; } // Name of the contact person at the supplier's company.
        public string ContactEmail { get; set; } // Email of the contact person.
        public string ContactPhone { get; set; } // Phone number of the contact person.

        // Constructor
        public SupplierAcknowledgment()
        {
            Id = Guid.NewGuid();
            AcknowledgmentDate = DateTime.Now; // Sets the acknowledgment date to the current date and time.
        }
    }
}
