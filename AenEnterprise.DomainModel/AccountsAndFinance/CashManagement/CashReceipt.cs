using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.CashManagement
{
    public class CashReceipt
    {
        public int CashReceiptId { get; set; }
        public decimal AmountReceived { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string Description { get; set; }

        // Foreign key to BankAccount
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }

}
