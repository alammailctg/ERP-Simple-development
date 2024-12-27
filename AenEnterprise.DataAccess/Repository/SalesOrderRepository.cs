using AenEnterprise.DataAccess.Criterias;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AenEnterprise.DataAccess.Repository
{
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        private readonly AenEnterpriseDbContext _context;

        public SalesOrderRepository(AenEnterpriseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<SalesOrder>> GetSalesOrderQuery(SalesOrderCriteria request,int statusId, bool isPartiallyApproved)
        {
            // Get specific sales order
            IQueryable<SalesOrder> query = _context.SalesOrders
                .Include(so => so.Customer)
                .Include(so => so.OrderItems)
                .ThenInclude(so => so.Unit)
                .Include(so => so.OrderItems)
                .ThenInclude(so => so.Product)
                .Where(so => so.OrderItems != null && so.OrderItems.Count() > 0 &&
                             so.OrderItems.Any(oi => oi.StatusId == statusId && oi.IsPartiallyApproved == isPartiallyApproved));

            // Criteria
            query = query.Where(e =>
               EF.Functions.Like(e.Customer.Name, $"%{request.CriteriaName}%") ||
                   EF.Functions.Like(e.SalesOrderNo, $"%{request.CriteriaName}%") ||
               e.OrderItems.Any(oi =>
               EF.Functions.Like(oi.Product.Name, $"%{request.CriteriaName}%") ||
                       EF.Functions.Like(oi.Price.ToString(), $"%{request.CriteriaName}%")
               ) ||
                   EF.Functions.Like(e.Invoices.FirstOrDefault().InvoiceNo, $"%{request.CriteriaName}%") ||
                   EF.Functions.Like(e.DeliveryOrders.FirstOrDefault().DeliveryOrderNo, $"%{request.CriteriaName}%")
               );

            //Date search
            if (request.DateFrom != null && request.DateTo != null)
            {
                query = query.Where(so => so.OrderedDate.Date >= request.DateFrom.Date &&
                                           so.OrderedDate.Date <= request.DateTo.Date.AddDays(1));
            }


            return query;
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
