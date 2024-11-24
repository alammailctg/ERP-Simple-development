using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class ReconciliationRepository : GenericRepository<Reconciliation>, IReconciliationRepository
    {
        public ReconciliationRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
