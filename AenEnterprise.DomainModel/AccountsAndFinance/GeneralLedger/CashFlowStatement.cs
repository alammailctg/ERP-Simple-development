using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class CashFlowStatement
    {
        public DateTime PeriodEnding { get; set; } // Date for which the cash flow statement is prepared
        public List<CashFlowStatementLine> CashFlowLines { get; set; } // List of cash inflows and outflows

        public CashFlowStatement()
        {
            CashFlowLines = new List<CashFlowStatementLine>();
        }

        public void AddLine(CashFlowStatementLine line)
        {
            CashFlowLines.Add(line);
        }

        public decimal TotalCashInflows => CashFlowLines
            .Where(line => line.IsCashInflow)
            .Sum(line => line.Amount);

        public decimal TotalCashOutflows => CashFlowLines
            .Where(line => !line.IsCashInflow)
            .Sum(line => line.Amount);

        public decimal NetCashFlow => TotalCashInflows - TotalCashOutflows;

        public void PrepareFinancialStatements()
        {
            // Income Statement
            IncomeStatement incomeStatement = new IncomeStatement { PeriodEnding = DateTime.Today };
            incomeStatement.AddLine(new IncomeStatementLine("Service Revenue", 50_000m, true));
            incomeStatement.AddLine(new IncomeStatementLine("Cost of Goods Sold", 20_000m, false));
            incomeStatement.AddLine(new IncomeStatementLine("Operating Expenses", 15_000m, false));

            Console.WriteLine($"Income Statement for period ending {incomeStatement.PeriodEnding.ToShortDateString()}:");
            Console.WriteLine($"Total Revenue: {incomeStatement.TotalRevenue}");
            Console.WriteLine($"Total Expenses: {incomeStatement.TotalExpenses}");
            Console.WriteLine($"Net Income: {incomeStatement.NetIncome}");

            // Balance Sheet
            BalanceSheet balanceSheet = new BalanceSheet { AsOfDate = DateTime.Today };
            balanceSheet.AddLine(new BalanceSheetLine("Cash", 30_000m, true, false, false));
            balanceSheet.AddLine(new BalanceSheetLine("Accounts Receivable", 10_000m, true, false, false));
            balanceSheet.AddLine(new BalanceSheetLine("Accounts Payable", 5_000m, false, true, false));
            balanceSheet.AddLine(new BalanceSheetLine("Owner's Equity", 35_000m, false, false, true));

            Console.WriteLine($"\nBalance Sheet as of {balanceSheet.AsOfDate.ToShortDateString()}:");
            Console.WriteLine($"Total Assets: {balanceSheet.TotalAssets}");
            Console.WriteLine($"Total Liabilities: {balanceSheet.TotalLiabilities}");
            Console.WriteLine($"Total Equity: {balanceSheet.TotalEquity}");

            // Cash Flow Statement
            CashFlowStatement cashFlowStatement = new CashFlowStatement { PeriodEnding = DateTime.Today };
            cashFlowStatement.AddLine(new CashFlowStatementLine("Cash Received from Customers", 40_000m, true));
            cashFlowStatement.AddLine(new CashFlowStatementLine("Cash Paid for Expenses", 15_000m, false));

            Console.WriteLine($"\nCash Flow Statement for period ending {cashFlowStatement.PeriodEnding.ToShortDateString()}:");
            Console.WriteLine($"Total Cash Inflows: {cashFlowStatement.TotalCashInflows}");
            Console.WriteLine($"Total Cash Outflows: {cashFlowStatement.TotalCashOutflows}");
            Console.WriteLine($"Net Cash Flow: {cashFlowStatement.NetCashFlow}");
        }
    }

  
}
