using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AdjustedTrialBalanceLine
    {
        public string AccountName { get; set; } // Name of the account
        public decimal TotalDebit { get; set; }  // Total debit amount for the account
        public decimal TotalCredit { get; set; } // Total credit amount for the account

        public AdjustedTrialBalanceLine(string accountName, decimal totalDebit, decimal totalCredit)
        {
            AccountName = accountName;
            TotalDebit = totalDebit;
            TotalCredit = totalCredit;
        }

        public decimal Balance => TotalDebit - TotalCredit; // Calculates the balance for the account
    }
}
