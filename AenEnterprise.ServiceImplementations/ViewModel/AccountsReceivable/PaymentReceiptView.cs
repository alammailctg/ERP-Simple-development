using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.AccountsReceivable
{
    public class PaymentReceiptView
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Foreign Key to Invoice
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
