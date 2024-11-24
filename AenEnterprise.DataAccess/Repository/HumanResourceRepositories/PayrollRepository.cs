using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class PayrollRepository : GenericRepository<Payroll>, IPayrollRepository
    {
        private readonly AenEnterpriseDbContext _context;

        public PayrollRepository(AenEnterpriseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payroll> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.Payrolls.Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.EmployeeId == employeeId);
        }
    }
}
