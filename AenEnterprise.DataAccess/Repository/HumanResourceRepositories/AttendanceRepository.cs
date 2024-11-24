using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.Repository.HumanResourceRepositories
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(AenEnterpriseDbContext context) : base(context)
        {

        }
        public async Task<List<Attendance>> GetAttendancesByEmployeeId(int employeeId)
        {
            return await _context.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _context.Attendances.ToListAsync();
        }

    }
}
