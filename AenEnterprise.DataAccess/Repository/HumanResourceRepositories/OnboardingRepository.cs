using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class OnboardingRepository : GenericRepository<Onboarding>, IOnboardingRepository
    {
        public OnboardingRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
