using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
