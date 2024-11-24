using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AccountAdjustment
    {
        public AccountGroup Account { get; set; } // Reference to the Account object
        public decimal Amount { get; set; } // Amount of the adjustment
        public bool IsDebit { get; set; } // Indicates if the amount is a debit or a credit
    }

}
