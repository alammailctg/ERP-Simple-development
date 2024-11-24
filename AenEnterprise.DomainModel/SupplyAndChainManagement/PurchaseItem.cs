using AenEnterprise.DomainModel.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class PurchaseItem
    {
        public PurchaseItem() { }

        public PurchaseItem(PurchaseOrder purchaseOrder, decimal quantity, decimal price, Product product, Unit unit)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
            Unit = unit;
            PurchaseOrder = purchaseOrder;
        }

        public int Id { get; set; }
        public string ItemCode { get; set; } // Code or SKU of the item
        public DateTime CreatedDate { get; set; }

        // Foreign key properties
        public int ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int UnitId { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public Unit Unit { get; set; }

        // Other properties
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ItemStatus { get; set; } = "Ordered";

        // Calculated property
        public decimal Amount
        {
            get => Quantity * Price;
            set { } // EF Core requires a setter
        }
    }

}
