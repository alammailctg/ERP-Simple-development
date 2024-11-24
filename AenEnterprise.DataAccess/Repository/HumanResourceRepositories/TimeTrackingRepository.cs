using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class TimeTrackingRepository : GenericRepository<TimeTracking>, ITimeTrackingRepository
    {
        public TimeTrackingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
