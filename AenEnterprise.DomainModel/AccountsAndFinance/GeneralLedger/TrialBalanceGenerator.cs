using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger.GeneralLedgerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class TrialBalanceGenerator : ITrialBalanceGenerator
    {
        public TrialBalance GenerateTrialBalance(DateTime asOfDate, List<JournalEntry> journalEntries)
        {
            var accountBalance = new Dictionary<string, TrialBalanceLine>();
            foreach (var entry in journalEntries)
            {
                foreach (var line in entry.JournalEntryLines)
                {
                    string accountKey = line.AccountGroup?.AccountName ?? "Unknown Account";
                    if (!accountBalance.ContainsKey(accountKey))
                    {
                        accountBalance[accountKey] = new TrialBalanceLine()
                        {
                            AccountName = accountKey,
                            TotalDebit = line.DebitAmount,
                            TotalCredit = line.CreditAmount
                        };
                    }
                    accountBalance[accountKey].TotalDebit += line.DebitAmount;
                    accountBalance[accountKey].TotalCredit += line.CreditAmount;
                }
            }
            return new TrialBalance(asOfDate, accountBalance.Values.ToList());
        }
    }
}
