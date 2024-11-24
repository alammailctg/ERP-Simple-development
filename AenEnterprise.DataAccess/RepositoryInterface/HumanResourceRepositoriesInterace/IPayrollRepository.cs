using AenEnterprise.DomainModel.HumanResources;

namespace AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace
{
    public interface IPayrollRepository : IGenericRepository<Payroll>
    {
        Task<Payroll> GetByEmployeeIdAsync(int employeeId);
    }
}
