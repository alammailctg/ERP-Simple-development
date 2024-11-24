using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class PerformanceReviewRepository : GenericRepository<PerformanceReview>, IPerformanceReviewRepository
    {
        public PerformanceReviewRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }

}
