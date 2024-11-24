using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    using System;
    using System.Collections.Generic;

    public class Supplier
    {
        public Guid Id { get; set; } 
        public string SupplierName { get; set; } 
        public string? ContactName { get; set; } 
        public string? ContactEmail { get; set; }
        public string PhoneNumber { get; set; } 
        public string Address { get; set; } 
        public string? Country { get; set; } 
        public string? TaxID { get; set; } 
        public float SupplierRating { get; set; } // Rating of the supplier, e.g., out of 10.
        public List<string> ProductsSupplied { get; set; } // List of products the supplier provides.
        public string PaymentTerms { get; set; } // Payment terms, e.g., Net 30.
        public decimal AccountBalance { get; set; } // Current balance owed to or by the supplier.
        public DateTime? ContractStartDate { get; set; } // Start date of the contract.
        public DateTime? ContractEndDate { get; set; } // End date of the contract.
        public bool IsActive { get; set; } // Indicates if the supplier is active.
        public string? Notes { get; set; } // Additional notes about the supplier.

        // Constructor
        public Supplier()
        {
            Id = Guid.NewGuid();
            ProductsSupplied = new List<string>();
            IsActive = true;
        }
    }

}
