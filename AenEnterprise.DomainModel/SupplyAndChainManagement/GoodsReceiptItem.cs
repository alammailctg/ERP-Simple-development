using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class GoodsReceiptItem
    {
        public int ItemId { get; set; } // Unique identifier for each item in the receipt

        public string ItemCode { get; set; } // Code or SKU of the item

        public string ItemDescription { get; set; } // Description of the item received

        public int QuantityOrdered { get; set; } // Quantity that was ordered

        public int QuantityReceived { get; set; } // Quantity that was actually received

        public string UOM { get; set; } // Unit of Measure (e.g., pcs, kg)

        public string Condition { get; set; } // Condition of the item upon receipt (e.g., New, Damaged)

        public string Remarks { get; set; } // Additional remarks or notes regarding the item

        // Method to display item summary
        public string GetItemSummary()
        {
            return $"Item Code: {ItemCode}, Description: {ItemDescription}, " +
                   $"Quantity Ordered: {QuantityOrdered}, Quantity Received: {QuantityReceived}, " +
                   $"UOM: {UOM}, Condition: {Condition}, Remarks: {Remarks}";
        }
    }
}
