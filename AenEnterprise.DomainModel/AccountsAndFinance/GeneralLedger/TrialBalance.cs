using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class TrialBalance
    {
        
        private decimal _totalDebits, _totalCredits;
        public List<TrialBalanceLine> TrialBalanceLines { get; set; } // List of account balances
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public TrialBalance()
        {
            
        }
        public TrialBalance(DateTime asOfDate, List<TrialBalanceLine> trialBalanceLines)
        {
            AsOfDate = asOfDate;
            TrialBalanceLines = trialBalanceLines;
            TotalDebit = CalculateTotalDebits();
            TotalCredit = CalculateTotalCredits();
        }

        public DateTime AsOfDate { get; set; }
    
        public decimal CalculateTotalDebits()
        {
           return TrialBalanceLines.Sum(t => t.TotalDebit);
        }

        public decimal CalculateTotalCredits()
        {
            return TrialBalanceLines.Sum(t => t.TotalCredit);
        }

    }

}
