using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.InventoryRepository
{
    public class InventorySummaryRepository : GenericRepository<InventorySummary>, IInventorySummaryRepository
    {
        public InventorySummaryRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
