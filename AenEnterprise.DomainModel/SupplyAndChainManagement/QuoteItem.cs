using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class QuoteItem
    {
        public Guid QuoteItemID { get; set; } // Unique identifier for each quote item.
        public Guid RFQItemID { get; set; } // Reference to the RFQ item this quote is for.
        public string ItemDescription { get; set; } // Description of the item.
        public int Quantity { get; set; } // Quantity quoted by the supplier.
        public decimal UnitPrice { get; set; } // Price per unit.
        public decimal TotalPrice => Quantity * UnitPrice; // Total price for the item.

        // Constructor
        public QuoteItem()
        {
            QuoteItemID = Guid.NewGuid();
        }
    }
}
