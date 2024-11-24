using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class AccountTypeRepository : GenericRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
