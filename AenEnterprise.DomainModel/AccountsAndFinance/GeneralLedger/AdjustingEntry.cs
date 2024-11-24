using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AdjustingEntry
    {
        public int Id { get; set; } // Primary Key
        public string AdjustmentType { get; set; } // Type of adjustment (e.g., Accrual, Deferral)
        public DateTime Date { get; set; } // Date of the adjustment
        public decimal Amount { get; set; } // Amount of the adjustment
        public List<AccountAdjustment> AccountsAffected { get; set; } // List of accounts affected
        public string Description { get; set; } // Description of the adjustment

        public AdjustingEntry()
        {
            AccountsAffected = new List<AccountAdjustment>();
        }

        // Method to add an account adjustment
        public void AddAccountAdjustment(AccountGroup account, decimal amount, bool isDebit)
        {
            AccountsAffected.Add(new AccountAdjustment
            {
                Account = account,
                Amount = amount,
                IsDebit = isDebit
            });
        }
    }

}
