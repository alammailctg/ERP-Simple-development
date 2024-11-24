using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.HumanResources.Benefits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class BenefitRepository : GenericRepository<Benefit>, IBenefitRepository
    {
        public BenefitRepository(AenEnterpriseDbContext context) : base(context)
        {
        }
        public async Task<List<Benefit>> GetAllBenefits()
        {
            return await _context.Benefits.ToListAsync();
        }
    }
}
