using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface
{
    public interface IJournalEntryRepository : IGenericRepository<JournalEntry>
    {
        Task<JournalEntry> GetJournalEntryByIncludeId(int journalEntryId);
        Task<List<JournalEntry>> GetJournalEntryByAsOfDate(DateTime asOfDate);
    }
}
