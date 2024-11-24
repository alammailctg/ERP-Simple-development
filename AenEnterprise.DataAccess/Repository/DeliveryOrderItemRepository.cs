using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class DeliveryOrderItemRepository : GenericRepository<DeliveryOrderItem>, IDeliveryOrderItemRepository
    {
        public DeliveryOrderItemRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
