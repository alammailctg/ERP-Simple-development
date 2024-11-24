using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class TalentAcquisitionRepository : GenericRepository<TalentAcquisition>, ITalentAcquisitionRepository
    {
        public TalentAcquisitionRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
