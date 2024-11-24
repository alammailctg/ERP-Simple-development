using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class ReturnItemRepository : GenericRepository<ReturnItem>, IReturnItemRepository
    {
        public ReturnItemRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
