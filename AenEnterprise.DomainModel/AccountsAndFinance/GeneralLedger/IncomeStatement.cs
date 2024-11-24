using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class IncomeStatement
    {
        public DateTime PeriodEnding { get; set; }
        public List<IncomeStatementLine> IncomeStatementLines { get; set; } = new List<IncomeStatementLine>();

        // Method to generate the income statement from general ledger accounts
        public void GenerateFromGeneralLedger(List<GeneralLedgerAccount> generalLedgerAccounts)
        {
            foreach (var account in generalLedgerAccounts)
            {
                if (account.Type.TypeName == "Revenue")
                {
                    IncomeStatementLines.Add(new IncomeStatementLine(account.AccountName, account.Balance, isRevenue: true));
                }
                else if (account.Type.TypeName == "Expense")
                {
                    IncomeStatementLines.Add(new IncomeStatementLine(account.AccountName, account.Balance, isRevenue: false));
                }
            }
        }

        // Method to add an income statement line
        public void AddLine(IncomeStatementLine line)
        {
            IncomeStatementLines.Add(line);
        }

        public decimal TotalRevenue => IncomeStatementLines
            .Where(line => line.IsRevenue)
            .Sum(line => line.Amount);

        public decimal TotalExpenses => IncomeStatementLines
            .Where(line => !line.IsRevenue)
            .Sum(line => line.Amount);

        public decimal NetIncome => TotalRevenue - TotalExpenses;
    }


}
