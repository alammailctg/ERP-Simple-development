using AenEnterprise.DataAccess;
using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.AccountsReceivable;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.Invoice;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/Invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private AenEnterpriseDbContext _context;
        private readonly ISalesOrderService _salesOrderService;
        private readonly IUserService _userService;
        private readonly HttpRequest _request;
        private readonly ICustomerService _customerService;
        private readonly IPaymentReceiptService _paymentReceiptService;

        public InvoiceController(IInvoiceService invoiceService,
            AenEnterpriseDbContext context,
            ISalesOrderService salesOrderService,
            IUserService userService,
            IHttpContextAccessor httpContextAccessor,
            ICustomerService customerService,
            IPaymentReceiptService paymentReceiptService)
        {
            _invoiceService = invoiceService;
            _context = context;
            _salesOrderService = salesOrderService;
            _userService = userService;
            _request = httpContextAccessor.HttpContext.Request;
            _customerService = customerService;
            _paymentReceiptService = paymentReceiptService;
        }

        [HttpGet("ApprovedOrderItemDetails")]
        public async Task<IActionResult> GetApprovedOrderItemDetails(int salesOrderId)
        {
            var SalesOrder = await _invoiceService.GetApprovedOrderItemDetailsAsync(salesOrderId);
            return Ok(SalesOrder);
        }

        [Route("CreateCustomInvoices")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomizeInvoices([FromBody] List<CreateInvoiceFormRequest> formRequests)
        {
            CreateInvoiceResponse response = new CreateInvoiceResponse();
            if (formRequests == null)
            {
                return BadRequest("Invalid request format");
            }
            foreach (var formRequest in formRequests)
            {
                CreateInvoiceRequest request = new CreateInvoiceRequest();
                request.SalesOrderId = formRequest.SalesOrderId;
                request.InvoiceQuantity = formRequest.InvoiceQuantity;
                request.OrderItemId = formRequest.OrderItemId;
                request.orderItemIdToAdd.Add(formRequest.OrderItemId);

                response = await _invoiceService.CreateCustomInvoiceAsync(request);
            }

            if (_request.HttpContext.Session.Keys.Contains("InvoiceId"))
            {
                _request.HttpContext.Session.Remove("InvoiceId");
            }


            return Ok(response);
        }

        [Route("get-all-invoice")]
        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {
            var response = await _invoiceService.GetAllInvoiceAsync();
            return Ok(response);
        }

        [Route("GetAllUnApproveInvoices")]
        [HttpPost]
        public async Task<IActionResult> GetAllUnApprovedInvoiceByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
        {
            SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
            request.PageNumber = formRequest.PageNumber;
            request.PageSize = formRequest.PageSize;
            request.DateFrom = formRequest.DateFrom;
            request.DateTo = formRequest.DateTo;
            request.CriteriaName = formRequest.CriteriaName;
            var SalesOrder = await _invoiceService.GetAllUnApprovedInvoice(request);
            return Ok(SalesOrder);
        }

        [Route("GetAllApproveInvoices")]
        [HttpPost]
        public async Task<IActionResult> GetAllApprovedInvoiceByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
        {
            SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
            request.PageNumber = formRequest.PageNumber;
            request.PageSize = formRequest.PageSize;
            request.DateFrom = formRequest.DateFrom;
            request.DateTo = formRequest.DateTo;
            request.CriteriaName = formRequest.CriteriaName;
            var SalesOrder = await _invoiceService.GetAllApprovedInvoice(request);
            return Ok(SalesOrder);
        }

        [Route("ApproveInvoices")]
        [HttpPost]
        public async Task<IActionResult> ApproveInvoiceForm([FromBody] List<SalesOrderUpdateApprovalStatusFormRequest> formRequests)
        {
            GetAllInvoiceResponse response = new GetAllInvoiceResponse();

            try
            {
                foreach (var formRequest in formRequests)
                {
                    var request = new UpdateSalesOrderApprovalStatusRequest
                    {
                        StatusId = formRequest.StatusId,
                        InvoiceId = formRequest.InvoiceId,
                        InvoiceItemId = formRequest.InvoiceItemId
                    };

                    response = await _invoiceService.ApprovalStatusInvoiceAsync(request);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                // For example, you can log it to a file or a logging system
                Console.WriteLine($"Exception occurred: {ex.Message}");

                // Return a meaningful error response
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        [HttpGet("ApprovedInvoiceDetails")]
        public async Task<IActionResult> GetApprovedInvoiceDetails(int invoiceId)
        {
            var SalesOrder = await _invoiceService.GetApprovedInvoiceDetailsAsync(invoiceId);

            return Ok(SalesOrder);
        }
    }
}
