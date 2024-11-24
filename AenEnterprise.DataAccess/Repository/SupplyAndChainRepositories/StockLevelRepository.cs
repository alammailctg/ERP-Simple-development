using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class StockLevelRepository : GenericRepository<StockLevel>, IStockLevelRepository
    {
        public StockLevelRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
