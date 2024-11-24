using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable
{
    public class PaymentReceipt
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Foreign Key to Invoice
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; }
    }

}
