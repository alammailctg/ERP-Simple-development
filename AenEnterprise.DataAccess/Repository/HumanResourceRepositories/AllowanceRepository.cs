using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess;
using AenEnterprise.DataAccess.Repository;
using AenEnterprise.DomainModel.HumanResources.Benefits;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class AllowanceRepository : GenericRepository<Allowances>, IAllowanceRepository
    {
        
        public AllowanceRepository(AenEnterpriseDbContext context) : base(context)
        {
        }

        public async Task<List<Allowances>> GetAllAllowances()
        {
            return await _context.Allowances.ToListAsync();
        }
 
    }
}
