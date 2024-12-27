using AenEnterprise.ServiceImplementations.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/EFQuerying")]
    [ApiController]
    public class EFQueryingController : ControllerBase
    {

        private IEFQueryingService _efService;
        public EFQueryingController(IEFQueryingService efService)
        {
            _efService = efService;
        }

        [HttpGet("GetEmp")]
        public IActionResult GetEmployeeByGroupName()
        {
            var response= _efService.GetEmployeesByNameGroup();
            return Ok(response);
        }
    }
}
