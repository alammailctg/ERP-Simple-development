using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class PurchaseItemRepository : GenericRepository<PurchaseItem>, IPurchaseItemRepository
    {
        public PurchaseItemRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
