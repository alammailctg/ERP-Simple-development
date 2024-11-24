using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class SupplierInvoice
    {
        public int Id { get; set; } // Unique identifier for the invoice

        public int PurchaseOrderId { get; set; } // ID of the related purchase order

        public string InvoiceNumber { get; set; } // Unique invoice number provided by the supplier

        public DateTime InvoiceDate { get; set; } // Date on the invoice

        public DateTime ReceivedDate { get; set; } = DateTime.Now; // Date when the invoice was received

        public decimal TotalAmount
        {
            get { return LineItems.Sum(item => item.TotalItemCost); }
        } // Total amount of the invoice based on line items

        public List<SupplierInvoiceLineItem> LineItems { get; set; } = new List<SupplierInvoiceLineItem>(); // List of items on the invoice

        public string Status { get; set; } = "Pending Review"; // Status of the invoice (e.g., Pending Review, Approved, Paid)

        public DateTime? DueDate { get; set; } // Due date for payment

        public string Currency { get; set; } // Currency code (e.g., USD, EUR)

        public string Notes { get; set; } // Additional notes or comments
         
    }
}
