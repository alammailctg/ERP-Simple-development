using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class PortalAccessRepository : GenericRepository<PortalAccess>, IPortalAccessRepository
    {
        public PortalAccessRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
    }
}
