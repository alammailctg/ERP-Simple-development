using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public List<SalesOrder> SalesOrders { get; set; }
        public List<CreditMemo> CreditMemos { get; set; }
        public decimal Balance { get; set; }
        public void DipositToPayment(decimal paymentAmount)
        {
            Balance += paymentAmount;
        }

        public void ApplyBalanceToOutstandingAmount(Invoice invoice)
        {
            if (invoice.OutstandingAmount <= 0)
            {
                return;
            }

            if (Balance >= invoice.OutstandingAmount)
            {
                Balance -= invoice.OutstandingAmount;
            }
            else
            {
                Balance = 0; 
            }
        }
    }
}
