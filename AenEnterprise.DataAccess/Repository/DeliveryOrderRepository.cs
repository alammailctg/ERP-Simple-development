using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class DeliveryOrderRepository : GenericRepository<DeliveryOrder>, IDeliveryOrderRepository
    {
        public DeliveryOrderRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
