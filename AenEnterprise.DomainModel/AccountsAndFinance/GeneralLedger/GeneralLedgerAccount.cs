using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class GeneralLedgerAccount
    {
        public string AccountName { get; set; }
        public decimal DebitTotal { get; set; }
        public decimal CreditTotal { get; set; }
        public AccountType Type { get; set; } // Add AccountType to indicate if it's an asset, liability, or equity

        // Property to calculate the net balance (debit - credit) for each account
        public decimal Balance => DebitTotal - CreditTotal;
    }

}
