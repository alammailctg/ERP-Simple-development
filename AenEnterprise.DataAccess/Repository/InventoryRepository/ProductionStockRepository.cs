using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class ProductionStockRepository : GenericRepository<ProductionStock>, IProductionStockRepository
    {
        public ProductionStockRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
