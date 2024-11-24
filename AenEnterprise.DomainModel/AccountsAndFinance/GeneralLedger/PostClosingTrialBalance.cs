using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class PostClosingTrialBalance
    {
        public DateTime AsOfDate { get; set; } // Date for which the post-closing trial balance is prepared
        public List<PostClosingTrialBalanceLine> TrialBalanceLines { get; set; } // List of account balances

        public PostClosingTrialBalance()
        {
            TrialBalanceLines = new List<PostClosingTrialBalanceLine>();
            AsOfDate = DateTime.Today; // Default to today
        }

        // Method to add a line to the post-closing trial balance
        public void AddLine(PostClosingTrialBalanceLine line)
        {
            TrialBalanceLines.Add(line);
        }

        // Method to calculate total debits and credits
        public decimal TotalDebits => TrialBalanceLines.Sum(line => line.DebitAmount);
        public decimal TotalCredits => TrialBalanceLines.Sum(line => line.CreditAmount);

        // Method to check if the trial balance is balanced
        public bool IsBalanced => TotalDebits == TotalCredits;

        public void PreparePostClosingTrialBalance()
        {
            PostClosingTrialBalance postClosingTrialBalance = new PostClosingTrialBalance
            {
                AsOfDate = DateTime.Today
            };

            // Add example accounts
            postClosingTrialBalance.AddLine(new PostClosingTrialBalanceLine("Cash", 30_000m, 0m));
            postClosingTrialBalance.AddLine(new PostClosingTrialBalanceLine("Accounts Receivable", 15_000m, 0m));
            postClosingTrialBalance.AddLine(new PostClosingTrialBalanceLine("Equipment", 50_000m, 0m));
            postClosingTrialBalance.AddLine(new PostClosingTrialBalanceLine("Accounts Payable", 0m, 10_000m));
            postClosingTrialBalance.AddLine(new PostClosingTrialBalanceLine("Owner's Equity", 0m, 85_000m));

            // Display the post-closing trial balance
            Console.WriteLine($"Post-Closing Trial Balance as of {postClosingTrialBalance.AsOfDate.ToShortDateString()}:");
            foreach (var line in postClosingTrialBalance.TrialBalanceLines)
            {
                Console.WriteLine($"{line.AccountName}: Debit = {line.DebitAmount}, Credit = {line.CreditAmount}, Balance = {line.Balance}");
            }

            Console.WriteLine($"Total Debits: {postClosingTrialBalance.TotalDebits}, Total Credits: {postClosingTrialBalance.TotalCredits}");
            Console.WriteLine($"Is Balanced: {postClosingTrialBalance.IsBalanced}");
        }

    }
}
