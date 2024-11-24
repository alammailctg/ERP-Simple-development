using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.UserDomain;

namespace AenEnterprise.DataAccess.Repository
{
    public class OnlineUserRepository : GenericRepository<OnlineUser>, IOnlineUserRepository
    {
        public OnlineUserRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
    }
}
