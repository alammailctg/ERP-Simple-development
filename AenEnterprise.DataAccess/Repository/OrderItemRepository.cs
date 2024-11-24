using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
