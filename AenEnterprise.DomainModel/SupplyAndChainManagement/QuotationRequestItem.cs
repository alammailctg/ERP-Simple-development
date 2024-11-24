using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class QuotationRequestItem
    {
        public QuotationRequestItem()
        {
            ItemID = Guid.NewGuid();
        }
        public Guid ItemID { get; set; } // Unique identifier for each item.
        public string Description { get; set; } // Description of the item or service.
        public string Specifications { get; set; } // Technical specifications for the item.
        public int Quantity { get; set; } // Quantity required.
        public string QualityStandards { get; set; } // Quality or industry standards.
    }
}
