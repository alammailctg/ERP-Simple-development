using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
