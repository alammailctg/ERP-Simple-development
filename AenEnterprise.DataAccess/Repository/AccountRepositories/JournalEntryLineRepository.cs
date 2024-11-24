using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class JournalEntryLineRepository : GenericRepository<JournalEntryLine>, IJournalEntryLineRepository
    {
        public JournalEntryLineRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
