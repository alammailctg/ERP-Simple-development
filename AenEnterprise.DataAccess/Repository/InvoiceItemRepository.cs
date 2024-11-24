using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
    {
        public InvoiceItemRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
