using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
