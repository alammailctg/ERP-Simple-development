using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable.FactoryPattern;
using AenEnterprise.DomainModel.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class PurchaseOrder
    {
        private IList<PurchaseItem> _purchaseItems;
        public PurchaseOrder()
        {
            CreateDate = DateTime.Today;
            _purchaseItems = new List<PurchaseItem>();
        }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now; // Date the PO was created
        public string Status { get; set; } = "Pending"; // Status of the PO (e.g., Pending, Approved, Shipped, Received)
        public DateTime ExpectedDeliveryDate { get; set; } // Expected delivery date for the items
        public DateTime PurchaseDate { get; set; }
        public string PurchaseOrderNo { get; set; }
        private decimal _totalOrderCost;

        public decimal TotalCostAmount { get; set; }


        public string DeliveryInstructions { get; set; } // Specific delivery or packaging instructions

        public string PaymentTerms { get; set; } // Payment terms agreed with the supplier

        public string ShippingMethod { get; set; } // Shipping method (e.g., Air, Ground, Sea)

        // Optional fields for tracking additional details
        public string ApprovedBy { get; set; } // Name of the person who approved the PO

        public DateTime? ApprovalDate { get; set; } // Date when the PO was approved

        public string Notes { get; set; } // Additional notes or instructions for the PO
        public IEnumerable<PurchaseItem> PurchaseItems { get => _purchaseItems; }
        public List<VendorInvoice> VendorInvoices { get; set; }
        public void CreatePurchaseItem(Product product,
            decimal quantity, Unit unit, decimal price)
        {
            _purchaseItems.Add(PurchaseItemFactory.CreatePurchaseItemFactory(this, product, quantity, unit, price));
        }

    }

     
   

}
