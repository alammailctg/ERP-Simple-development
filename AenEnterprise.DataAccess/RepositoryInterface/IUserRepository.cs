using AenEnterprise.DomainModel.UserDomain;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> IncludeOfUserForUserName(string userName);
        Task<User> GetUserByUsernameAsync(string username);


    }
}
