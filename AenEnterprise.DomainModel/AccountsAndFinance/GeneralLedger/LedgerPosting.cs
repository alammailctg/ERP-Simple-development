using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class LedgerPosting
    {
        public int LedgerPostingId { get; set; }         // Primary Key
        public DateTime PostingDate { get; set; }        // Date of the ledger posting
        public string Description { get; set; }          // Description of the ledger posting
        public decimal Amount { get; set; }              // Posted amount
        public bool IsDebit { get; set; }                // True for debit, false for credit

        // Foreign Key
        public int AccountGroupId { get; set; }               // Foreign key to Account
        public AccountGroup AccountGroup { get; set; }             // Navigation property
    }


}
