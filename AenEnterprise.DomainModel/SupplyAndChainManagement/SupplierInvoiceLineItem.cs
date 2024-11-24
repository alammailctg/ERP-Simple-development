using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class SupplierInvoiceLineItem
    {
        public int LineItemId { get; set; } // Unique identifier for each line item

        public string ItemCode { get; set; } // Code or SKU of the item

        public string Description { get; set; } // Description of the item or service

        public int Quantity { get; set; } // Quantity billed

        public decimal UnitPrice { get; set; } // Unit price of the item

        public decimal TotalItemCost
        {
            get { return Quantity * UnitPrice; }
        } // Total cost for this line item based on quantity and unit price

        public string UOM { get; set; } // Unit of Measure (e.g., kg, pcs, liters)

        public string Remarks { get; set; } // Additional remarks or notes for the item

        // Method to display line item summary
        public string GetLineItemSummary()
        {
            return $"Item Code: {ItemCode}, Description: {Description}, Quantity: {Quantity}, " +
                   $"Unit Price: {UnitPrice:C}, Total Cost: {TotalItemCost:C}, UOM: {UOM}, Remarks: {Remarks}";
        }
    }
}
