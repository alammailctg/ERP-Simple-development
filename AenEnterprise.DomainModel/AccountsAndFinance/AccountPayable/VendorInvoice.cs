using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable
{
    public class VendorInvoice
    {
        public int Id { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int PurchaseOrderId { get; set; }

        // Foreign key to PurchaseOrder
        public PurchaseOrder PurchaseOrder { get; set; }

        // One Invoice can have many Payments
        public List<Payment> Payments { get; set; }
    }
}
