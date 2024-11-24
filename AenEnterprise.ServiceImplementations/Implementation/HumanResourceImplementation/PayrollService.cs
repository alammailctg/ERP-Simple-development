using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using AenEnterprise.DataAccess.RepositoryInterface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.DomainModel.HumanResources.Benefits;

namespace AenEnterprise.ServiceImplementations.Implementation.HumanResourceImplementation
{
    public class PayrollService : BaseService, IPayrollService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPayrollRepository _payrollRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IAllowanceRepository _allowanceRepository;
        private readonly IBenefitRepository _benefitRepository;
        private readonly IAttendanceCalculator _attendanceCalculator;
        private readonly IOverTimeCalculator _overTimeCalculator;
        private readonly IBenefitCalculator _benefitCalculator;
        private readonly IAllowanceCalculator _allowanceCalculator;
        private readonly IAdvancePaymentRepository _advancePaymentRepository;
        public PayrollService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDatabase redisDb,
            RedisConnection redisConnection,
            ILogger<EmployeeService> logger,
            IEmployeeRepository employeeRepository,
            IPayrollRepository payrollRepository,
            IAttendanceRepository attendanceRepository,
            IAttendanceCalculator attendanceCalculator,
            IOverTimeCalculator overTimeCalculator,
            IAllowanceRepository allowanceRepository,
            IBenefitRepository benefitRepository,
            IBenefitCalculator benefitCalculator,
            IAllowanceCalculator allowanceCalculator,
            IAdvancePaymentRepository advancePaymentRepository)
            : base(unitOfWork, mapper, redisDb, redisConnection, logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _payrollRepository = payrollRepository;
            _attendanceRepository = attendanceRepository;
            _attendanceCalculator = attendanceCalculator;
            _overTimeCalculator = overTimeCalculator;
            _allowanceRepository = allowanceRepository;
            _benefitRepository = benefitRepository;
            _benefitCalculator = benefitCalculator;
            _allowanceCalculator = allowanceCalculator;
            _advancePaymentRepository = advancePaymentRepository;
        }

        public async Task<GetPayrollResponse> GetPayrollByEmployeeId(GetPayrollRequest request)
        {
            _logger.LogInformation("Payroll found for EmployeeId: {EmployeeId}", request.EmployeeId);
            GetPayrollResponse response = new GetPayrollResponse();
            return response;
            //payroll.CalculatePresentHourse(employee);
        }

        public async Task<CreatePayrollResponse> CreatePayrollAsync(CreatePayrollRequest request)
        {
            CreatePayrollResponse response = new CreatePayrollResponse();
            Employee employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            List<AdvancePayment> advancePayments =await _advancePaymentRepository.GetAllAdvancePayments();
            List<Attendance> attendances = await _attendanceRepository.GetAllAttendances();
            List<Allowances> allowances = await _allowanceRepository.GetAllAllowances();
            List<Benefit> benefits = await _benefitRepository.GetAllBenefits();
            Payroll payroll = new Payroll(_attendanceCalculator, _overTimeCalculator, attendances,
                employee, "Present", request.Year, request.Month, _allowanceCalculator, 
                _benefitCalculator, allowances, benefits,advancePayments)
            {
                TaxRate = 2m,
                EmployeeId = request.EmployeeId,
                PaymentDate = DateTime.Today
            };


            await _payrollRepository.AddAsync(payroll);
            await _unitOfWork.SaveAsync();

            if (employee == null) throw new ArgumentException("Employee not found.");
            return response;
        }
    }
}






//var existingPayroll = await _payrollRepository
//    .FindAsync(p => p.EmployeeId == request.EmployeeId &&
//         p.selectedYear == request.Year &&
//         p.selectedMonth == request.Month);

//if (existingPayroll != null)
//{
//    Console.WriteLine("Payroll record found: EmployeeId = " + request.EmployeeId + ", Year = " + request.Year + ", Month = " + request.Month);
//    throw new InvalidOperationException("Payroll already exists for this employee for the selected year and month.");
//}

