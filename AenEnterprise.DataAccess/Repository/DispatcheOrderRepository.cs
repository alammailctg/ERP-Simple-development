using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class DispatcheOrderRepository : GenericRepository<DispatcheOrder>, IDispatcheRepository
    {
        public DispatcheOrderRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
