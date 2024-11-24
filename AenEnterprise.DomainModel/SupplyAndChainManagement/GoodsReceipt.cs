using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class GoodsReceipt
    {
        public int ReceiptId { get; set; } // Unique identifier for the goods receipt

        public int PurchaseOrderId { get; set; } // ID of the related purchase order

        public DateTime ReceiptDate { get; set; } = DateTime.Now; // Date when the goods/services were received

        public string ReceivedBy { get; set; } // Name of the individual receiving the goods/services

        public string SupplierName { get; set; } // Name of the supplier providing the goods/services

        public List<GoodsReceiptItem> Items { get; set; } = new List<GoodsReceiptItem>(); // List of items received

        public string Comments { get; set; } // Additional comments regarding the receipt

        public bool IsComplete { get; set; } = true; // Status indicating whether the receipt is complete

        // Method to calculate total quantity received for all items
        public int TotalQuantityReceived
        {
            get { return Items.Sum(item => item.QuantityReceived); }
        }

        // Method to display a summary of the goods receipt
        public string GetReceiptSummary()
        {
            var itemsSummary = string.Join("\n", Items.Select(item => item.GetItemSummary()));

            return $"Receipt ID: {ReceiptId}\n" +
                   $"Purchase Order ID: {PurchaseOrderId}\n" +
                   $"Receipt Date: {ReceiptDate.ToShortDateString()}\n" +
                   $"Received By: {ReceivedBy}\n" +
                   $"Supplier: {SupplierName}\n" +
                   $"Total Quantity Received: {TotalQuantityReceived}\n" +
                   $"Is Complete: {IsComplete}\n" +
                   $"Comments: {Comments}\n" +
                   $"Items:\n{itemsSummary}\n";
        }
    }
}
