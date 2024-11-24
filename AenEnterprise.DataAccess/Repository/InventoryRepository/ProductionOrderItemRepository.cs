using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class ProductionOrderItemRepository : GenericRepository<ProductionOrderItem>, IProductionOrderItemRepository
    {
        public ProductionOrderItemRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
