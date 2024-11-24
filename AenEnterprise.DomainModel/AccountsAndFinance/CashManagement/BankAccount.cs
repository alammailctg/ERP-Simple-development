using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.CashManagement
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Currency { get; set; }

        // Navigation properties
        public List<CashReceipt> CashReceipts { get; set; }
        public List<CashDisbursement> CashDisbursements { get; set; }
        public List<BankReconciliation> BankReconciliations { get; set; }


        public BankAccount()
        {
            CashReceipts = new List<CashReceipt>();
            CashDisbursements = new List<CashDisbursement>();
            BankReconciliations = new List<BankReconciliation>();
        }
    }

}
