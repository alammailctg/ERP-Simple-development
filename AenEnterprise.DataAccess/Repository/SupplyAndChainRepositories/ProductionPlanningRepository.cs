using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class ProductionPlanningRepository : GenericRepository<ProductionPlanning>, IProductionPlanningRepository
    {
        public ProductionPlanningRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
