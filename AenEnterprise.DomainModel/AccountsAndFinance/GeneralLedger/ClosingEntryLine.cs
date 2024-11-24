using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class ClosingEntryLine
    {
        public string AccountName { get; set; } // Name of the account affected
        public decimal DebitAmount { get; set; } // Amount to be debited
        public decimal CreditAmount { get; set; } // Amount to be credited
        public string Description { get; set; } // Description of the closing entry line

        public ClosingEntryLine(string accountName, decimal debitAmount, decimal creditAmount, string description)
        {
            AccountName = accountName;
            DebitAmount = debitAmount;
            CreditAmount = creditAmount;
            Description = description;
        }
    }

}
