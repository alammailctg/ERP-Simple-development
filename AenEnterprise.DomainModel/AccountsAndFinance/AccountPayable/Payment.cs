using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int VendorInvoiceId { get; set; }

        // Foreign key to Invoice
        public VendorInvoice VendorInvoice { get; set; }

        // Foreign key to Reconciliation
        public int? ReconciliationId { get; set; }
        public Reconciliation Reconciliation { get; set; }
    }

}
