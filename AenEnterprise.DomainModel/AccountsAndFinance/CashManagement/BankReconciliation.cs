using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.CashManagement
{
    public class BankReconciliation
    {
        public int BankReconciliationId { get; set; }
        public DateTime ReconciliationDate { get; set; }
        public decimal StatementBalance { get; set; }
        public decimal SystemBalance { get; set; }
        public decimal Difference { get; set; }

        // Foreign key to BankAccount
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }

}
