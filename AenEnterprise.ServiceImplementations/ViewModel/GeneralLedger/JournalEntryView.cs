using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.ServiceImplementations.ViewModel.GeneralLedger
{
    public class JournalEntryView
    {
        public JournalEntryView()
        {
            JournalEntryLines = new List<JournalEntryLineView>();
        }
        public int JournalEntryId { get; set; }         // Primary Key
        public string CustomerName { get; set; }
        public DateTime EntryDate { get; set; }
        public string FormattedEntryDate
        {
            get
            {
                return EntryDate.ToString("dddd, dd MMMM yyyy");
            }
        }// Date of the journal entry
        public string ReferenceNumber { get; set; }     // Reference or document number
        public string Description { get; set; }         // Description of the journal entry
        public IEnumerable<JournalEntryLineView> JournalEntryLines { get; set; }

    }
}