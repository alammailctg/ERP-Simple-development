using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.HumanResources.Benefits;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using AenEnterprise.ServiceImplementations.ViewModel.HumanResource;
using AutoMapper;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation.HumanResourceImplementation
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPayrollRepository _payrollRepository;
        
       
        public EmployeeService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDatabase redisDb,
            RedisConnection redisConnection,
            ILogger<EmployeeService> logger,
            IEmployeeRepository employeeRepository,
            IPayrollRepository payrollRepository
            )
            : base(unitOfWork, mapper, redisDb, redisConnection, logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _payrollRepository = payrollRepository;
        
        }

        public async Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            Employee employee = new Employee()
            {
                Name = request.Name,
                Designation = request.Designation,
                DepartmentId = request.DepartmentId,
                HireDate = request.HireDate,
                Status = request.Status,
                ActualSalary = request.ActualSalary,
            };

            
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.SaveAsync();

            // Convert the created employee to an EmployeeView using _mapper
            var employeeView = employee.ConvertToView<Employee, EmployeeView>(_mapper);

            // Create the response and set the employee data
            var response = new CreateEmployeeResponse
            {
                Id = employee.Id,
                Employee = employeeView // Assuming CreateEmployeeResponse has a property for EmployeeView
            };

            return response;
        }

        
    }

}
