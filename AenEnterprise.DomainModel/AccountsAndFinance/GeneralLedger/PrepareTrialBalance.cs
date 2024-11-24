using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class TrialBalancePrepare
    {
        public TrialBalancePrepare() { }

        //public void PrepareTrialBalance(DateTime asOfDate, List<JournalEntry> journalEntries)
        //{
        //    TrialBalance trialBalance = new TrialBalance { AsOfDate = asOfDate };
        //    trialBalance.GenerateFromJournalEntries(journalEntries);

        //    // Display the trial balance or process further
        //    Console.WriteLine($"Trial Balance as of {asOfDate.ToShortDateString()}:");
        //    foreach (var line in trialBalance.TrialBalanceLines)
        //    {
        //        Console.WriteLine($"{line.AccountName}: Debit = {line.TotalDebit}, Credit = {line.TotalCredit}");
        //    }

        //    Console.WriteLine($"Total Debits: {trialBalance.TotalDebits}, Total Credits: {trialBalance.TotalCredits}");
        //}
    }

}
