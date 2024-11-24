using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class CashFlowStatementLine
    {
        public string Description { get; set; } // Description of the cash flow item
        public decimal Amount { get; set; }      // Amount of the cash flow item
        public bool IsCashInflow { get; set; }   // Indicates if this line is a cash inflow

        public CashFlowStatementLine(string description, decimal amount, bool isCashInflow)
        {
            Description = description;
            Amount = amount;
            IsCashInflow = isCashInflow;
        }
    }

}
