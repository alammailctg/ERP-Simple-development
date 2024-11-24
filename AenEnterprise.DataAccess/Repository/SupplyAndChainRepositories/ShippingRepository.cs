using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
    {
        public ShippingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }

}
