using System.Diagnostics;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class JournalEntry
    {
        private DateTime _createdDate;
        private List<JournalEntryLine> _journalEntryLines;

        public JournalEntry()
        {
            _journalEntryLines = new List<JournalEntryLine>();
            _createdDate = DateTime.Today;
        }

        public int JournalEntryId { get; set; }         // Primary Key
        public string JournalEntryNo { get; set; }
        public DateTime EntryDate { get; set; }         // Date of the journal entry
        public string JournalName { get; set; }
        public int Partner { get; set; }
        public string ReferenceNumber { get; set; }     // Reference or document number
        public string Description { get; set; }         // Description of the journal entry
        public List<JournalEntryLine> JournalEntryLines { get => _journalEntryLines; set => _journalEntryLines = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }

        public void CreateJournalEntryLine(decimal debitAmount,decimal creditAmount, string description, AccountGroup account)
        {
            _journalEntryLines.Add(JournalEntryLineFactory.CreateJournalEntryLine(debitAmount,creditAmount, description,this,account));
        }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        private decimal _totalDebit;
        public decimal TotalDebit
        { 
            get =>_totalDebit != 0 ? _totalDebit : _journalEntryLines.Sum(line => line.DebitAmount);
            set => _totalDebit = value; 
        }
        private decimal _totalCredit;
        public decimal TotalCredit
        {
            get => _totalCredit != 0 ? _totalCredit : _journalEntryLines.Sum(line => line.CreditAmount);
            set => _totalCredit = value;
        }

        public decimal TotalAmount
        {
            get
            {
                decimal totalDebit = _journalEntryLines.Sum(line => line.DebitAmount);
                decimal totalCredit = _journalEntryLines.Sum(line => line.CreditAmount);
                return totalDebit + totalCredit;
            }
        }
    }
}
