using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class Quote
    {
        public Guid QuoteID { get; set; } // Unique identifier for each quote.
        public Guid SupplierID { get; set; } // Reference to the supplier providing the quote.
        public string SupplierName { get; set; } // Name of the supplier.
        public DateTime QuoteDate { get; set; } // Date the quote was submitted.
        public decimal TotalPrice { get; set; } // Total price for the items in the quote.

        // Quote breakdown and terms
        public List<QuoteItem> QuoteItems { get; set; } // Detailed breakdown of items in the quote.
        public string DeliveryTerms { get; set; } // Delivery terms offered by the supplier.
        public string PaymentTerms { get; set; } // Payment terms provided by the supplier.
        public string AdditionalTerms { get; set; } // Any additional terms or conditions.

        // Constructor
        public Quote()
        {
            QuoteID = Guid.NewGuid();
            QuoteItems = new List<QuoteItem>();
        }
    }
}
