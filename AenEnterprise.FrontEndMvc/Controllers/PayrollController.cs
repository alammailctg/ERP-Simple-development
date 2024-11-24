using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/Payroll")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        private readonly ILogger<PayrollController> _logger;

        public PayrollController(IPayrollService payrollService, ILogger<PayrollController> logger)
        {
            _payrollService = payrollService ?? throw new ArgumentNullException(nameof(payrollService));
            _logger = logger;
        }

        // GET: api/payroll/{employeeId}
        [HttpPost("{employeeId}")]
        public async Task<IActionResult> GetPayrollByEmployeeId(GetPayrollRequest request)
        {
            _logger.LogInformation("Request received to get payroll for EmployeeId: {EmployeeId}", request.EmployeeId);

            var response = await _payrollService.GetPayrollByEmployeeId(request);

            if (response == null)
            {
                _logger.LogWarning("Payroll not found for EmployeeId: {EmployeeId}", request.EmployeeId);
                return NotFound(new { Message = "Payroll not found for the specified employee ID." });
            }

            return Ok(response);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreatePayroll([FromQuery] CreatePayrollRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("CreatePayroll request is null.");
                return BadRequest("Request cannot be null.");
            }
                _logger.LogInformation("Request received to create payroll for EmployeeId: {EmployeeId}", request.EmployeeId);
                var response = await _payrollService.CreatePayrollAsync(request);
                _logger.LogInformation("Payroll created successfully with ID {PayrollId}", response.PayrollId);
                return CreatedAtAction(nameof(GetPayrollByEmployeeId), new { employeeId = request.EmployeeId }, response);
        }
    }
}
