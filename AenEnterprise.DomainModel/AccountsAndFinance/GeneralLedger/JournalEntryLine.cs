using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class JournalEntryLine
    {
        // Constructors
        public JournalEntryLine() 
        { 
        
        }

        public JournalEntryLine(decimal debitAmount, decimal creditAmount,  
            string description, JournalEntry journalEntry, AccountGroup account)
        {
            DebitAmount = debitAmount;
            CreditAmount = creditAmount;
            Description = description;
            JournalEntry = journalEntry;
            AccountGroup = account;
            CreatedDate = DateTime.Today;
        }

        // Properties
        public int JournalEntryLineId { get; set; }        // Primary Key
        public string Description { get; set; } = string.Empty;
        public int AccountGroupId { get; set; }
        public int JournalEntryId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Today;

        // Navigation Properties
        public JournalEntry JournalEntry { get; set; }
        public AccountGroup AccountGroup { get; set; }

        
        
    }

}
