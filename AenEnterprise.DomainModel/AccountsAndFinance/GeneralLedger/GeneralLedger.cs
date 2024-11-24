using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class GeneralLedger
    {
        public List<GeneralLedgerAccount> GeneralLedgerAccounts { get; set; } = new List<GeneralLedgerAccount>();

        // Method to post journal entries to the general ledger
        public void PostJournalEntries(List<JournalEntry> journalEntries)
        {
            // Dictionary to track account totals by AccountName
            var accountTotals = new Dictionary<string, (decimal debit, decimal credit)>();

            // Aggregate totals from journal entries
            foreach (var entry in journalEntries)
            {
                foreach (var line in entry.JournalEntryLines)
                {
                    if (!accountTotals.ContainsKey(line.AccountGroup.AccountName))
                    {
                        accountTotals[line.AccountGroup.AccountName] = (0, 0);
                    }

                    // Update totals for the account
                    var currentTotals = accountTotals[line.AccountGroup.AccountName];
                    currentTotals.debit += line.DebitAmount;
                    currentTotals.credit += line.CreditAmount;
                    accountTotals[line.AccountGroup.AccountName] = currentTotals;
                }
            }

            // Convert dictionary totals into GeneralLedgerAccount instances
            foreach (var account in accountTotals)
            {
                GeneralLedgerAccounts.Add(new GeneralLedgerAccount
                {
                    AccountName = account.Key,
                    DebitTotal = account.Value.debit,
                    CreditTotal = account.Value.credit
                });
            }
        }
    }
}
