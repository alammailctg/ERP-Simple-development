using AenEnterprise.ServiceImplementations.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [ApiController]
    [Route("api/TrialBalance")]
    public class TrialBalanceController : ControllerBase
    {
        private readonly ITrialBalanceService _trialBalanceService;

        public TrialBalanceController(ITrialBalanceService trialBalanceService)
        {
            _trialBalanceService = trialBalanceService;
        }

        [Route("generate")]
        [HttpPost]
        public async Task<IActionResult> GenerateTrialBalance([FromQuery] DateTime asOfDate)
        {
            try
            {
                var trialBalance = await _trialBalanceService.GenerateTrialBalance(asOfDate);
                return Ok(trialBalance);
            }
            catch (Exception ex)
            {
                // Log the exception (optional, based on your logging setup)
                return StatusCode(500, new { Message = "An error occurred while generating the trial balance.", Details = ex.Message });
            }
        }
    }
}
