using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class BenefitsAdministrationRepository : GenericRepository<BenefitsAdministration>, IBenefitsAdministrationRepository
    {
        public BenefitsAdministrationRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
