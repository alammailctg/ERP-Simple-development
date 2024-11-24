using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class InventoryTransferRepository : GenericRepository<InventoryTransfer>, IInventoryTransferRepository
    {
        public InventoryTransferRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
