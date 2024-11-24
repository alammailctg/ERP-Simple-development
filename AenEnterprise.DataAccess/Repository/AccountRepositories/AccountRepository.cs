using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class AccountRepository : GenericRepository<AccountGroup>, IAccountRepository
    {
        public AccountRepository(AenEnterpriseDbContext context) : base(context)
        {

        }


    }
}
