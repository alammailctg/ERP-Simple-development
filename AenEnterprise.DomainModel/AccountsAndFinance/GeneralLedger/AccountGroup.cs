using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AccountGroup
    {
        public int AccountGroupId { get; set; }             // Primary Key
        public string AccountName { get; set; }        // Name of the account (e.g., Cash in Hand, Inventory)
        public string AccountNumber { get; set; }      // Unique account number or code
        public decimal Balance { get; set; }           // Account balance
        public string AccountCode { get; set; }
        // Foreign Key
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        // Navigation properties
        public List<JournalEntryLine> JournalEntryLines { get; set; }
        public List<LedgerPosting> LedgerPostings { get; set; }
    }

}
