using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class ProductionOrderRepository : GenericRepository<ProductionOrder>, IProductionOrderRepository
    {
        public ProductionOrderRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
