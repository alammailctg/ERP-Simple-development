using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;

namespace AenEnterprise.DataAccess.Repository.AccountRepositories
{
    public class VendorInvoiceRepository : GenericRepository<VendorInvoice>, IVendorInvoiceRepository
    {
        public VendorInvoiceRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
