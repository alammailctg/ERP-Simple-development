using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class ClosingEntry
    {
        public int ClosingEntryId { get; set; } // Unique identifier for the closing entry
        public DateTime ClosingDate { get; set; } // Date of the closing entry
        public List<ClosingEntryLine> ClosingEntryLines { get; set; } // List of lines for the closing entry

        public ClosingEntry()
        {
            ClosingEntryLines = new List<ClosingEntryLine>();
            ClosingDate = DateTime.Today; // Default to today
        }

        // Method to add a line to the closing entry
        public void AddLine(ClosingEntryLine line)
        {
            ClosingEntryLines.Add(line);
        }

        // Method to summarize total debits and credits for closing
        public decimal TotalDebits => ClosingEntryLines.Sum(line => line.DebitAmount);
        public decimal TotalCredits => ClosingEntryLines.Sum(line => line.CreditAmount);

        public void PrepareClosingEntries()
        {
            ClosingEntry closingEntry = new ClosingEntry();

            // Example closing entries for revenue and expense accounts
            closingEntry.AddLine(new ClosingEntryLine("Service Revenue", 0m, 50_000m, "Close service revenue to Income Summary"));
            closingEntry.AddLine(new ClosingEntryLine("Cost of Goods Sold", 25_000m, 0m, "Close COGS to Income Summary"));
            closingEntry.AddLine(new ClosingEntryLine("Operating Expenses", 15_000m, 0m, "Close operating expenses to Income Summary"));
            closingEntry.AddLine(new ClosingEntryLine("Income Summary", 0m, closingEntry.TotalCredits - closingEntry.TotalDebits, "Close Income Summary to Retained Earnings"));

            // Display closing entry details
            Console.WriteLine($"Closing Entry ID: {closingEntry.ClosingEntryId}");
            Console.WriteLine($"Closing Date: {closingEntry.ClosingDate.ToShortDateString()}");
            Console.WriteLine("Closing Entry Lines:");

            foreach (var line in closingEntry.ClosingEntryLines)
            {
                Console.WriteLine($"{line.Description}: Debit = {line.DebitAmount}, Credit = {line.CreditAmount} (Account: {line.AccountName})");
            }

            Console.WriteLine($"Total Debits: {closingEntry.TotalDebits}");
            Console.WriteLine($"Total Credits: {closingEntry.TotalCredits}");
        }

    }
}
