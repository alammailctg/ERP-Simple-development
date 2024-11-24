using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.UserDomain;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AenEnterpriseDbContext context) : base(context)
        {

        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<User>> IncludeOfUserForUserName(string userName)
        {
            return await _context.Users
                                 .Include(ur => ur.Username)
                                 .Where(ur => ur.Username == userName)
                                 .ToListAsync();

        }


    }
}
