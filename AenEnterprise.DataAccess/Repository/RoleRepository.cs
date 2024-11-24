using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.UserDomain;

namespace AenEnterprise.DataAccess.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
