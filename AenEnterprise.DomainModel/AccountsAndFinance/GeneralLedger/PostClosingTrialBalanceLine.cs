using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class PostClosingTrialBalanceLine
    {
        public string AccountName { get; set; } // Name of the account
        public decimal DebitAmount { get; set; } // Total debit amount for the account
        public decimal CreditAmount { get; set; } // Total credit amount for the account

        public PostClosingTrialBalanceLine(string accountName, decimal debitAmount, decimal creditAmount)
        {
            AccountName = accountName;
            DebitAmount = debitAmount;
            CreditAmount = creditAmount;
        }

        public decimal Balance => DebitAmount - CreditAmount; // Calculates the balance for the account
    }


}
