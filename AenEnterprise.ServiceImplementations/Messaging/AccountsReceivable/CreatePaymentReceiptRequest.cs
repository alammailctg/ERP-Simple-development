using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable
{
    public class CreatePaymentReceiptRequest
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Foreign Key to Invoice
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public DateTime EntryDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string JournalLineDescription { get; set; }
        public string IsDebit { get; set; }
        public string Description { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public int PartnerId { get; set; }
        public string JournalName { get; set; }

    }
}
