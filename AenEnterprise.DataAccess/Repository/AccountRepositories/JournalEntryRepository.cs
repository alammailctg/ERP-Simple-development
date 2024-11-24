using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class JournalEntryRepository : GenericRepository<JournalEntry>, IJournalEntryRepository
    {
       
        public JournalEntryRepository(AenEnterpriseDbContext context) : base(context)
        {
            
        }

        public async Task<JournalEntry> GetJournalEntryByIncludeId(int journalEntryId)
        {
            var journalEntry = await _context.JournalEntries
                .Include(so => so.JournalEntryLines)
                .FirstOrDefaultAsync(je => je.JournalEntryId == journalEntryId);

            if (journalEntry == null)
            {
                throw new KeyNotFoundException($"journalEntry with Id {journalEntryId} not found.");
            }

            // Optionally check if any products are null for the loaded OrderItems
            //foreach (var item in journalEntry.JournalEntryLines)
            //{
            //    if (item.Product == null)
            //    {
            //        // Handle the case where the Product is null if necessary
            //        throw new KeyNotFoundException($"Warning: OrderItem {item.Id} has no associated Product.");
            //    }
            //}

            return journalEntry;
        }

        public async Task<List<JournalEntry>> GetJournalEntryByAsOfDate(DateTime asOfDate)
        {
            return _context.JournalEntries.Where(j=>j.CreatedDate==asOfDate).ToList();
        }

    }
}
