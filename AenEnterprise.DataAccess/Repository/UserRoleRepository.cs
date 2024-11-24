using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.UserDomain;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
        public async Task<List<UserRole>> IncludeOfUserRole(int userId)
        {
            return await _context.UserRoles
                                 .Include(ur => ur.User) // Eager load the User
                                 .Include(ur => ur.Role) // Eager load the Role
                                 .Where(ur => ur.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<List<UserRole>> IncludeOfUserRoleForAllUser()
        {
            return await _context.UserRoles
                                  .Include(ur => ur.User)
                                  .Include(ur => ur.Role)
                                  .ToListAsync();
        }

        public async Task<List<UserRole>> IncludeOfUserRoleForUserName(string userName)
        {
            return await _context.UserRoles
                                 .Include(ur => ur.User) // Eager load the User
                                 .Include(ur => ur.Role) // Eager load the Role
                                 .Where(ur => ur.User.Username == userName)
                                 .ToListAsync();

        }
    }
}
