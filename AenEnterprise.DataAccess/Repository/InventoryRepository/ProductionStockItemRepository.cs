using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class ProductionStockItemRepository : GenericRepository<ProductionStockItem>, IProductionStockItemRepository
    {
        public ProductionStockItemRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
