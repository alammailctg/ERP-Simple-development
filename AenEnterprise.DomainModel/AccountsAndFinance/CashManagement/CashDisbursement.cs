using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.CashManagement
{
    public class CashDisbursement
    {
        public int CashDisbursementId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }

        // Foreign key to BankAccount
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }

}
