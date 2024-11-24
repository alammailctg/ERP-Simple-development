using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class LedgerPostingRepository : GenericRepository<LedgerPosting>, ILedgerPostingRepository
    {
        public LedgerPostingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }

}
