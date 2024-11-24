using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class BalanceSheet
    {
        public DateTime AsOfDate { get; set; } // Date for which the balance sheet is prepared
        public List<BalanceSheetLine> BalanceSheetLines { get; set; } // List of assets, liabilities, and equity

        public BalanceSheet()
        {
            BalanceSheetLines = new List<BalanceSheetLine>();
        }

        public void AddLine(BalanceSheetLine line)
        {
            BalanceSheetLines.Add(line);
        }

        public decimal TotalAssets => BalanceSheetLines
            .Where(line => line.IsAsset)
            .Sum(line => line.Amount);

        public decimal TotalLiabilities => BalanceSheetLines
            .Where(line => line.IsLiability)
            .Sum(line => line.Amount);

        public decimal TotalEquity => BalanceSheetLines
            .Where(line => line.IsEquity)
            .Sum(line => line.Amount);

        public void GenerateBalanceSheet(List<GeneralLedgerAccount> generalLedgerAccounts)
        {
            foreach (var account in generalLedgerAccounts)
            {
                // Use the TypeName property from AccountType to determine the account type
                if (account.Type.TypeName == "Asset")
                {
                    AddLine(new BalanceSheetLine(account.AccountName, account.Balance, isAsset: true, isLiability: false, isEquity: false));
                }
                else if (account.Type.TypeName == "Liability")
                {
                    AddLine(new BalanceSheetLine(account.AccountName, account.Balance, isAsset: false, isLiability: true, isEquity: false));
                }
                else if (account.Type.TypeName == "Equity")
                {
                    AddLine(new BalanceSheetLine(account.AccountName, account.Balance, isAsset: false, isLiability: false, isEquity: true));
                }
            }
        }

    }

}
