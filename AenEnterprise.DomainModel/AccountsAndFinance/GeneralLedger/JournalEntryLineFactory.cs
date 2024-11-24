using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class JournalEntryLineFactory
    {
        public static JournalEntryLine CreateJournalEntryLine(decimal debitAmount, decimal creditAmount, 
            string description, JournalEntry journalEntry, AccountGroup account)
        {
            return new JournalEntryLine(debitAmount,creditAmount,description, journalEntry,account);
        }
    }

}
