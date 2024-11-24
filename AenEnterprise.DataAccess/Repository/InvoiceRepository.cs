using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
        public async Task<Invoice> GetInvoiceByIncludeId(int invoiceId)
        {
            var invoice = await _context.Invoices
                .Include(so => so.InvoiceItems)
                .Include(so => so.SalesOrder)
                .ThenInclude(so => so.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .Include(so => so.SalesOrder)
                .ThenInclude(so => so.OrderItems)
                    .ThenInclude(oi => oi.Unit)
                    .Include(so => so.SalesOrder)
                .ThenInclude(so => so.Customer)         // Include Customer entity
                .FirstOrDefaultAsync(so => so.Id == invoiceId);

            if (invoice == null)
            {
                throw new KeyNotFoundException($"SalesOrder with Id {invoiceId} not found.");
            }

            return invoice;
        }

    }
}
