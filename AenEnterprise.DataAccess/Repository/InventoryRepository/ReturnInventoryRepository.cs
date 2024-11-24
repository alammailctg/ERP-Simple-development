using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class ReturnInventoryRepository : GenericRepository<ReturnInventory>, IReturnInventoryRepository
    {
        public ReturnInventoryRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
