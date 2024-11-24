using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AdjustedTrialBalance
    {
        public DateTime AsOfDate { get; set; } // Date for which the trial balance is prepared
        public List<AdjustedTrialBalanceLine> TrialBalanceLines { get; set; } // List of account balances

        public AdjustedTrialBalance()
        {
            TrialBalanceLines = new List<AdjustedTrialBalanceLine>();
        }

        // Method to add a line to the adjusted trial balance
        public void AddLine(AdjustedTrialBalanceLine line)
        {
            TrialBalanceLines.Add(line);
        }

        // Method to calculate total debits and credits
        public decimal TotalDebits => TrialBalanceLines.Sum(line => line.TotalDebit);
        public decimal TotalCredits => TrialBalanceLines.Sum(line => line.TotalCredit);

        // Method to check if the trial balance is balanced
        public bool IsBalanced => TotalDebits == TotalCredits;
    }

}
