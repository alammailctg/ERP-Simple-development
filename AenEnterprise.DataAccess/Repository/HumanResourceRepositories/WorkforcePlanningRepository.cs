using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class WorkforcePlanningRepository : GenericRepository<WorkforcePlanning>, IWorkforcePlanningRepository
    {
        public WorkforcePlanningRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
