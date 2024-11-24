using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable
{
    public class CreditMemo
    {
        public int Id { get; set; }
        public decimal CreditAmount { get; set; }
        public DateTime IssueDate { get; set; }

        // Foreign Key to Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Foreign Key to Invoice
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }

}
