using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<List<Attendance>> GetAttendancesByEmployeeId(int employeeId);
        Task<List<Attendance>> GetAllAttendances();
    }
}
