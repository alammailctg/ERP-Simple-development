using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable
{
    public class CreateCreditMemoRequest
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
