using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class AdvancePaymentRepository : GenericRepository<AdvancePayment>, IAdvancePaymentRepository
    {
        public AdvancePaymentRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
        public async Task<List<AdvancePayment>> GetAdvancePaymentByEmployeeId(int employeeId)
        {
            return await _context.AdvancePayments
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<AdvancePayment>> GetAllAdvancePayments()
        {
            return await _context.AdvancePayments.ToListAsync();
        }

    }
}
