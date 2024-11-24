using AenEnterprise.ServiceImplementations.Implementation.AccountsService;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.GeneralLedger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/GeneralLedger")]
    [ApiController]
    public class GeneralLedgerController : ControllerBase
    {
        private readonly IGeneralLedgerService _generalLedgerService;
        public GeneralLedgerController(IGeneralLedgerService generalLedgerService)
        {
            _generalLedgerService = generalLedgerService;
        }


        [Route("all-accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _generalLedgerService.GetAllAccountAsync();
            return Ok(response);
        }

        [Route("create-journal-entry")]
        [HttpPost]
        public async Task<IActionResult> CreateJournalEntry([FromBody] CreateJournalEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _generalLedgerService.CreateJournalEntryAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
