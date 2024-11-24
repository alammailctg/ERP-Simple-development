using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class AccountGroupRepository : GenericRepository<AccountGroup>, IAccountGroupRepository
    {
        public AccountGroupRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
