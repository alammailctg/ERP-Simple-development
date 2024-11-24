using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository
{
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        private readonly AenEnterpriseDbContext _context;

        public SalesOrderRepository(AenEnterpriseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SalesOrder> GetSalesOrderByIncludeId(int salesOrderId)
        {
            var salesOrder = await _context.SalesOrders
                .Include(so => so.OrderItems)
                    .ThenInclude(oi => oi.Product)
                     .Include(so => so.OrderItems)
                    .ThenInclude(oi => oi.Unit) // Eager load Product for all OrderItems
                .Include(so => so.Customer)         // Include Customer entity
                .FirstOrDefaultAsync(so => so.Id == salesOrderId);

            if (salesOrder == null)
            {
                throw new KeyNotFoundException($"SalesOrder with Id {salesOrderId} not found.");
            }

            // Optionally check if any products are null for the loaded OrderItems
            foreach (var item in salesOrder.OrderItems)
            {
                if (item.Product == null)
                {
                    // Handle the case where the Product is null if necessary
                    throw new KeyNotFoundException($"Warning: OrderItem {item.Id} has no associated Product.");
                }
            }

            return salesOrder;
        }




    }
}
