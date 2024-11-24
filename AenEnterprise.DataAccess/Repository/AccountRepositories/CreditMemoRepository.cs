using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class CreditMemoRepository : GenericRepository<CreditMemo>, ICreditMemoRepository
    {
        public CreditMemoRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
