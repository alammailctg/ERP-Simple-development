using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories
{
    public class DemandPlanningRepository : GenericRepository<DemandPlanning>, IDemandPlanningRepository
    {
        public DemandPlanningRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
