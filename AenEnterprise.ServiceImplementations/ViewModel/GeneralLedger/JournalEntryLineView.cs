using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger
{
    public class JournalEntryLineView
    {
        public int JournalEntryLineId { get; set; }  // Primary Key
        public string Description { get; set; } = string.Empty;
        public int AccountId { get; set; }
        public int JournalEntryId { get; set; }
        public decimal Amount { get; set; }  // Consolidated amount (Debit or Credit)
        public string IsDebit { get; set; } = string.Empty;  // Indicates if it's a Debit
        public DateTime CreatedDate { get; set; }
    }
}
