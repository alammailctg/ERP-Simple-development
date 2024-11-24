using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.CashManagement;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class BankReconciliationRepository : GenericRepository<BankReconciliation>, IBankReconciliationRepository
    {
        public BankReconciliationRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
