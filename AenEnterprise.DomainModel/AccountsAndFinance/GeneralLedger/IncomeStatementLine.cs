using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class IncomeStatementLine
    {
        public string Description { get; set; } // Description of the line item
        public decimal Amount { get; set; }      // Amount of the line item
        public bool IsRevenue { get; set; }      // Indicates if this line is a revenue or an expense

        public IncomeStatementLine(string description, decimal amount, bool isRevenue)
        {
            Description = description;
            Amount = amount;
            IsRevenue = isRevenue;
        }
    }

}
