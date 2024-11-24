namespace AenEnterprise.ServiceImplementations.Implementation.AccountsService
{
    public class CreateJournalEntryRequest
    {
        public decimal PaymentAmount { get; set; }
        public DateTime EntryDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }
        public DateTime PaymentDate { get; set; }
        public int AccountId { get; set; }
        public string IsDebit { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public int PartnerId { get; set; }
    }
}