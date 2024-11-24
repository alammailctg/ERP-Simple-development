using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.HumanResource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromQuery] CreateEmployeeRequest request)
        {
            if (request == null)
            {
                return BadRequest("Employee data is required.");
            }

            // Call the service method to create the employee
            var response = await _employeeService.CreateEmployeeAsync(request);

            // Return the response with a status code
            return CreatedAtAction(nameof(CreateEmployee), new { id = response.Id }, response);
        }
    }

}

