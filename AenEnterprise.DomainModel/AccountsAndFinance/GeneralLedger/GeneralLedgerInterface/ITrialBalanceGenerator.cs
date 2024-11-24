using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger.GeneralLedgerInterface
{
    public interface ITrialBalanceGenerator
    {
        
        TrialBalance GenerateTrialBalance(DateTime asOfDate, List<JournalEntry> journalEntries);
    }
}
