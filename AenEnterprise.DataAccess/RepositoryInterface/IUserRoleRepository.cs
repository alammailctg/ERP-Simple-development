using AenEnterprise.DomainModel.UserDomain;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<List<UserRole>> IncludeOfUserRole(int userId);
        Task<List<UserRole>> IncludeOfUserRoleForUserName(string userName);
        Task<List<UserRole>> IncludeOfUserRoleForAllUser();

    }
}
