using AenEnterprise.DataAccess;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DeliveryOrderMessage;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DispatchOrder;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/DO")]
    [ApiController]
    public class DOController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private AenEnterpriseDbContext _context;
        private readonly ISalesOrderService _salesOrderService;
        private readonly IUserService _userService;
        private readonly HttpRequest _request;
        private readonly ICustomerService _customerService;
        private readonly IPaymentReceiptService _paymentReceiptService;
        private readonly IDOService _doService;
        public DOController(IInvoiceService invoiceService,
            AenEnterpriseDbContext context,
            ISalesOrderService salesOrderService,
            IUserService userService,
            IHttpContextAccessor httpContextAccessor,
            ICustomerService customerService,
            IPaymentReceiptService paymentReceiptService,
            IDOService doService)
        {
            _invoiceService = invoiceService;
            _context = context;
            _salesOrderService = salesOrderService;
            _userService = userService;
            _request = httpContextAccessor.HttpContext.Request;
            _customerService = customerService;
            _paymentReceiptService = paymentReceiptService;
            _doService = doService;
        }

        [Route("CreateCustomDO")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomizeDeliveryOrders([FromBody] List<CreateDeliveryOrderFormRequest> formRequests)
        {
            try
            {
                CreateDeliveryOrderResponse response = new CreateDeliveryOrderResponse();
                foreach (var formRequest in formRequests)
                {
                    CreateDeliveryOrderRequest request = new CreateDeliveryOrderRequest(); // Create a new request object in each iteration
                    request.InvoiceId = formRequest.InvoiceId;
                    request.OrderItemId = formRequest.OrderItemId;
                    request.DeliveryQuantity = formRequest.DeliveryQuantity;
                    request.invoiceItemIdToAdd.Add(formRequest.InvoiceItemId);
                    response = await _doService.CreateCustomDeliveryOrderAsync(request);
                }
                if (_request.HttpContext.Session.Keys.Contains("DeliveryOrderId"))
                {
                    _request.HttpContext.Session.Remove("DeliveryOrderId");
                }
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles="Manager,Admin")]
        [HttpPost("GetAllUnApproveDeliveryOrder")]
        public async Task<IActionResult> GetAllUnApprovedSalesOrdersWithDeliveryOrderByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
        {
            SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
            request.PageNumber = formRequest.PageNumber;
            request.PageSize = formRequest.PageSize;
            request.DateFrom = formRequest.DateFrom;
            request.DateTo = formRequest.DateTo;
            request.CriteriaName = formRequest.CriteriaName;
            var SalesOrder = await _doService.GetAllUnApproveDeliveryOrder(request);
            return Ok(SalesOrder);
        }


        [HttpPost("ApproveDeliveryOrder")]
        public async Task<IActionResult> ApprovalStatusDeliveryOrderForm([FromBody] List<SalesOrderUpdateApprovalStatusFormRequest> formRequests)
        {
            GetAllDeliveryOrderResponse response = new GetAllDeliveryOrderResponse();

            try
            {
                foreach (var formRequest in formRequests)
                {
                    var request = new UpdateSalesOrderApprovalStatusRequest
                    {
                        StatusId = formRequest.StatusId,
                        DeliveryOrderItemId = formRequest.DeliveryOrderItemId
                    };

                    response = await _doService.ApprovalStatusDeliveryOrderAsync(request);
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
        [Authorize(Roles = "Manager,Admin")]
        [HttpPost("GetAllApprovedDeliveryOrder")]
        public async Task<IActionResult> GetAllApprovedSalesOrdersWithDeliveryOrderByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
        {
            SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
            request.PageNumber = formRequest.PageNumber;
            request.PageSize = formRequest.PageSize;
            request.DateFrom = formRequest.DateFrom;
            request.DateTo = formRequest.DateTo;
            request.CriteriaName = formRequest.CriteriaName;
            var SalesOrder = await _doService.GetAllApproveDeliveryOrder(request);
            return Ok(SalesOrder);
        }

        [Route("CreateCustomDispatch")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomizeDispatches([FromBody] List<CreateDispatchFormRequest> formRequests)
        {
            try
            {
                CreateDispatchResponse response = new CreateDispatchResponse();
                foreach (var formRequest in formRequests)
                {
                    CreateDispatchRequest request = new CreateDispatchRequest();
                    request.DeliveryOrderId = formRequest.DeliveryOrderId;
                    request.VehicalNo = formRequest.VehicalNo;
                    request.VehicalEmptyWeight = formRequest.VehicalEmptyWeight;
                    request.VehicalLoadWeight = formRequest.VehicalLoadWeight;
                    request.DispatchQuantity = formRequest.DispatchQuantity;
                    request.OrderItemId = formRequest.OrderItemId;
                    request.deliveryItemToAdd.Add(formRequest.DeliveryItemId);
                    response = await _doService.CreateCustomDispatchAsync(request);
                }

                if (_request.HttpContext.Session.Keys.Contains("DispatchId"))
                {
                    _request.HttpContext.Session.Remove("DispatchId");
                }
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("ApprovedDeliveryOrderDetails")]
        [HttpGet]
        public async Task<IActionResult> GetApprovedDeliveryOrderDetails(int deliveryOrderId)
        {
            var deliveryOrder = await _doService.GetApprovedDeliveryOrderDetailsAsync(deliveryOrderId);
            return Ok(deliveryOrder);
        }

    }
}
