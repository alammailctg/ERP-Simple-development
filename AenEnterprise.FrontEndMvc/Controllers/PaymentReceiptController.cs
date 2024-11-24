using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/PaymentReceipt")]
    [ApiController]
    public class PaymentReceiptController : ControllerBase
    {
        private readonly IPaymentReceiptService _paymentReceiptService;
        public PaymentReceiptController(IPaymentReceiptService paymentReceiptService)
        {
            _paymentReceiptService = paymentReceiptService;
        }

        [HttpPost("add-payment-receipt")] // Define the route for the POST request
        public async Task<IActionResult> AddPaymentReceipt([FromQuery] CreatePaymentReceiptRequest request)
        {
            CreatePaymentReceiptResponse response = await _paymentReceiptService.AddPaymentReceiptAsync(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Payment receipt added successfully.", PaymentReceipt = response.PaymentReceipt });
            }


            return BadRequest(new { Message = response.Message });
        }

        [Route("deposit-customer-payment")]
        [HttpPost]
        public async Task<IActionResult> DepositCustomerPaymentForm([FromBody] CreatePaymentReceiptRequest request)
        {
            var response= await _paymentReceiptService.DepositCustomerPaymentAsync(request);

            return Ok(response);
        }

        [Route("GetJournalEntryId")]
        [HttpGet]
        public async Task<IActionResult> GetJournalEntry()
        {
            var journalEntryId = await _paymentReceiptService.GetRedisJournalEntryId();

            if (string.IsNullOrEmpty(journalEntryId))
            {
                return NotFound("JournalEntryId does not exist!");
            }

            return Ok(journalEntryId);
        }

        [Route("GetJournalEntryDetailsByRedis")]
        [HttpGet]
        public async Task<IActionResult> GetJournalEntryDetails()
        {
            var response = await _paymentReceiptService.GetJournalEntryById();

            if (response==null)
            {
                return NotFound("JournalEntryId does not exist!");
            }

            return Ok(response);
        }

        [Route("GetPaymentId")]
        [HttpGet]
        public async Task<IActionResult> GetPaymentId()
        {
            var paymentId = await _paymentReceiptService.GetRedisPaymentId();

            if (string.IsNullOrEmpty(paymentId))
            {
                return NotFound("JournalEntryId does not exist!");
            }

            return Ok(paymentId);
        }

    }
}
