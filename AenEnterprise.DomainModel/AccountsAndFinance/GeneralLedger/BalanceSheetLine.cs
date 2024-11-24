using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class BalanceSheetLine
    {
        public string Description { get; set; } // Description of the line item
        public decimal Amount { get; set; }      // Amount of the line item
        public bool IsAsset { get; set; }        // Indicates if this line is an asset
        public bool IsLiability { get; set; }    // Indicates if this line is a liability
        public bool IsEquity { get; set; }       // Indicates if this line is equity

        public BalanceSheetLine(string description, decimal amount, bool isAsset, bool isLiability, bool isEquity)
        {
            Description = description;
            Amount = amount;
            IsAsset = isAsset;
            IsLiability = isLiability;
            IsEquity = isEquity;
        }
    }

}
