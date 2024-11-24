using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.AccountsReceivable
{
    public class CreditMemoView
    {
        public int Id { get; set; }
        public decimal CreditAmount { get; set; }
        public DateTime IssueDate { get; set; }
        // Foreign Key to Customer
        public int CustomerId { get; set; }

        // Foreign Key to Invoice
        public int InvoiceId { get; set; }
    }
}
