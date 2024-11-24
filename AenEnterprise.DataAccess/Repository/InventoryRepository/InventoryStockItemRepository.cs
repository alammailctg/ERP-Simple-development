using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class InventoryStockItemRepository : GenericRepository<InventoryStockItem>, IInventoryStockItemRepository
    {
        public InventoryStockItemRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
