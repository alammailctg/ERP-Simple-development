using AenEnterprise.DataAccess;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.UserDomain;
using AenEnterprise.FrontEndMvc.Models;
using AenEnterprise.FrontEndMvc.Models.JsonDto;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DeliveryOrderMessage;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DispatchOrder;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.Invoice;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AspNetCore.Reporting.ReportExecutionService;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using static AenEnterprise.FrontEndMvc.Controllers.AuthenController;
using static AenEnterprise.FrontEndMvc.Models.SalesOrder.CreateSalesOrderFormWithOrderItemsRequest;


namespace AenEnterprise.FrontEndMvc.Controllers
{

    [Route("api/SalesOrder")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private AenEnterpriseDbContext _context;
        private readonly ISalesOrderService _salesOrderService;
        private readonly IInvoiceService _invoiceService;
        private readonly IUserService _userService;
        private readonly HttpRequest _request;
        public SalesOrderController(ISalesOrderService salesOrderService, IUserService userService, IHttpContextAccessor httpContextAccessor, IInvoiceService invoiceService)
        {
            _salesOrderService = salesOrderService;
            _userService = userService;
            _context = new AenEnterpriseDbContext();
            _request = httpContextAccessor.HttpContext.Request;
            _invoiceService = invoiceService;
        }
        [Route("GetSalesOrder")]
        [HttpGet]
        public async Task<IActionResult> GetSalesOrderId()
        {
            var salesOrderId = await _salesOrderService.GetRedisSalesOrderId();

            if (string.IsNullOrEmpty(salesOrderId))
            {
                return NotFound("SalesOrderId does not exist!");
            }

            return Ok(salesOrderId);
        }
        [HttpGet("GetSalesOrders")]
        public ActionResult GetSalesOrders(int pageNumber, int pageSize)
        {
            // Your logic to retrieve sales orders for the specified page number and size
            // Return the sales orders data or perform necessary operations
            return Ok();
        }

        [HttpGet("GetAllUsingLinq")]
        public async Task<ActionResult> GetSalesOrdersUsingLinq()
        {
            var response = await _salesOrderService.GetAllSalesOrderUsingLinq();
            return Ok(response);
        }

        //[Authorize(Roles = "Admin")]
        [Route("CreateSalesOrder")]
        [HttpPost]
        public async Task<IActionResult> CreateSalesOrderForm([FromBody] CreateSalesOrderFormWithItemsRequest request)
        {
            if (request == null || request.FormRequest == null)
            {
                return BadRequest("Request body is null or improperly formatted.");
            }

            GetSalesOrderResponse response = new GetSalesOrderResponse();
            foreach (var orderItem in request.OrderItemsRequests)
            {
                CreateSalesOrderRequest salesOrderRequest = new CreateSalesOrderRequest
                {
                    OrderedDate = request.FormRequest.OrderedDate,
                    CustomerId = request.FormRequest.CustomerId,
                    SalesOrderStatusId = 1,
                    DeliveryPlane = string.IsNullOrEmpty(request.FormRequest.DeliveryPlane) ? null : request.FormRequest.DeliveryPlane,
                    Description = string.IsNullOrEmpty(request.FormRequest.Description) ? null : request.FormRequest.Description,
                    ProductId = orderItem.ProductId,
                    Price = orderItem.Price,
                    Quantity = orderItem.Quantity,
                    UnitId = orderItem.UnitId,
                    DiscountPercent = orderItem.DiscountPercent
                };
                response = await _salesOrderService.CreateSalesOrderAsync(salesOrderRequest);
            }
            return Ok(response);
        }
        //[Authorize(Roles = "Manager,Sales,Admin")]
        [HttpPost("AddSalesOrders")]
public async Task<IActionResult> AddSalesOrdersForm()
{
    await _salesOrderService.AddSalesOrdersAsync();
    return Ok("Sales order created successfully");
}

//[Authorize(Roles ="Sales,Manager,Admin")]
[HttpPost("ApproveOrderItems")]
public async Task<IActionResult> ApprovalStatusOrderItemsForm([FromBody] List<SalesOrderUpdateApprovalStatusFormRequest> formRequests)
{
    GetAllSalesOrderResponse response = new GetAllSalesOrderResponse();

    try
    {
        foreach (var formRequest in formRequests)
        {
            var request = new UpdateSalesOrderApprovalStatusRequest
            {
                SalesOrderId = formRequest.SalesOrderId,
                StatusId = formRequest.StatusId,
                OrderItemId = formRequest.OrderItemId
            };

            response = await _salesOrderService.ApprovalStatusOrderItemsAsync(request);
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

[HttpPost("ApproveInvoices")]
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

            response = await _salesOrderService.ApprovalStatusInvoiceAsync(request);
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
//[Authorize(Roles="Manager,Admin")]
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

            response = await _salesOrderService.ApprovalStatusDeliveryOrderAsync(request);
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


[HttpGet("GetAllSalesOrders")]
public async Task<IActionResult> GetAllSalesOrderBasketAsync()
{
    var SalesOrder = await _salesOrderService.GetAllSalesOrdersBasket();
    return Ok(SalesOrder);
}

[Route("DeleteOrderItem")]
[HttpPost]
public async Task<IActionResult> DeleteOrderItems([FromBody] DeleteOrderItemFormRequest formRequest, [FromQuery] int orderItemId)
{
    GetSalesOrderResponse response = new GetSalesOrderResponse();
    DeleteOrderItemRequest request = new DeleteOrderItemRequest();
    request.SalesOrderId = formRequest.SalesOrderId;
    request.OrderItemId = orderItemId;

    try
    {

        response = await _salesOrderService.DeleteOrderItemAsync(request);

        var salesOrderIdsWithStatus1 = await _context.SalesOrders
            .Where(so => so.OrderItems.Any(oi => oi.StatusId == 1 && oi.SalesOrderId == formRequest.SalesOrderId))
            .Select(so => so.Id)
            .ToListAsync();


        if (salesOrderIdsWithStatus1.Count.Equals(0) || response == null || Response.StatusCode == 500)
        {

            await _salesOrderService.DeleteSalesOrderAsync(request);

            var redirectUrl = Url.Action("CreateSalesOrder", "SalesManagement");
            return Ok(new { redirectUrl });
        }
        return Ok(response);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);

        // Return the status code and message
        return StatusCode(500, "Internal Server Error");
    }
}

//[HttpPost("DeleteOrderItem")]
//public async Task<IActionResult> DeleteOrderItems(DeleteOrderItemFormRequest formRequest, int orderItemId)
//{
//    GetSalesOrderResponse response = new GetSalesOrderResponse();
//    DeleteOrderItemRequest request = new DeleteOrderItemRequest();
//    request.SalesOrderId = formRequest.SalesOrderId;
//    request.OrderItemId = orderItemId;

//    try
//    {
//        response = await _salesOrderService.DeleteSalesOrderBasedOnOrderLimitAsync(request);
//        return Ok(response);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex);
//        return StatusCode(500, "Internal Server Error");
//    }
//}

//private async Task CancelSalesOrderBasedOrderLimit()
//{
//    await _salesOrderService.DeleteSalesOrderAndOrderItemAsync();
//}

[Route("CancelSalesOrder")]
[HttpPost]
public async Task<IActionResult> CancelSalesOrderForm()
{
    await _salesOrderService.DeleteSalesOrderAndOrderItemAsync();
    return Ok();
}

        [Route("DeleteSalesOrderBySalesOrderId")]
        [HttpPost]
        public async Task<IActionResult> DeleteSalesOrderForm(int salesOrderId)
        {
            await _salesOrderService.DeleteSalesOrderAsync(salesOrderId);
            return Ok("Successfully deleted your order");
        }

        
//[Authorize(Roles="Manager,Admin")]
[HttpPost("GetAllUnApprovedSalesOrders")]
public async Task<IActionResult> GetAllUnApprovedSalesOrdersByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
{
    SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
    request.PageNumber = formRequest.PageNumber;
    request.PageSize = formRequest.PageSize;
    request.DateFrom = formRequest.DateFrom;
    request.DateTo = formRequest.DateTo;
    request.CriteriaName = formRequest.CriteriaName;
    var SalesOrder = await _salesOrderService.GetAllUnApprovedOrderItems(request);
    return Ok(SalesOrder);
}

//[HttpGet("GetPaginationLinks")]
//public ActionResult<IEnumerable<string>> GetPaginationLinks(int totalPages, int currentPage = 1, int pageSize = 6)
//{
//    var paginationLinks = Enumerable.Range(1, totalPages)
//        .Select(pageNumber => new
//        {
//            PageNumber = pageNumber,
//            IsActive = pageNumber == currentPage,
//            Link = Url.Action(nameof(GetSalesOrders), new { pageNumber, pageSize })
//        })
//        .Select(linkInfo => $"<a href=\"{linkInfo.Link}\" class=\"page-link{(linkInfo.IsActive ? " active" : "")}\">{linkInfo.PageNumber}</a>")
//        .ToList();

//    return Ok(paginationLinks);
//}

//[Authorize(Roles = "Manager,Sales,Admin")]
[HttpPost("GetAllApprovedSalesOrders")]
public async Task<IActionResult> GetAllApprovedSalesOrdersByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
{
    SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
    request.PageNumber = formRequest.PageNumber;
    request.PageSize = formRequest.PageSize;
    request.DateFrom = formRequest.DateFrom;
    request.DateTo = formRequest.DateTo;
    request.CriteriaName = formRequest.CriteriaName;
    var SalesOrder = await _salesOrderService.GetAllApprovedOrderItems(request);
    return Ok(SalesOrder);
}

//[Authorize(Roles = "Manager,Sales,Admin")]
[HttpPost("GetAllApprovedOrderItemsSummary")]
public async Task<IActionResult> GetAllApprovedOrderItemsSummaryByCriteria([FromQuery] SalesOrderSearchCriteriaFormRequest formRequest)
{
    SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
    request.DateFrom = formRequest.DateFrom;
    request.DateTo = formRequest.DateTo;
    var SalesOrder = await _salesOrderService.GetAllApprovedOrderItemsSummary(request);
    return Ok(SalesOrder);
}

[HttpPost("GetAllUnApproveInvoices")]
public async Task<IActionResult> GetAllApprovedSalesOrdersWithInvoiceByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
{
    SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
    request.PageNumber = formRequest.PageNumber;
    request.PageSize = formRequest.PageSize;
    request.DateFrom = formRequest.DateFrom;
    request.DateTo = formRequest.DateTo;
    request.CriteriaName = formRequest.CriteriaName;
    var SalesOrder = await _salesOrderService.GetAllUnApprovedInvoice(request);
    return Ok(SalesOrder);
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
    var SalesOrder = await _salesOrderService.GetAllUnApproveDeliveryOrder(request);
    return Ok(SalesOrder);
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
    var SalesOrder = await _salesOrderService.GetAllApproveDeliveryOrder(request);
    return Ok(SalesOrder);
}

//[Authorize(Roles = "Manager,Sales,Admin")]
[HttpPost("GetAllApprovedInvoices")]
public async Task<IActionResult> GetAllApprovedInvoiceByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
{
    SalesOrderSearchCriteriaRequest request = new SalesOrderSearchCriteriaRequest();
    request.PageNumber = formRequest.PageNumber;
    request.PageSize = formRequest.PageSize;
    request.DateFrom = formRequest.DateFrom;
    request.DateTo = formRequest.DateTo;
    request.CriteriaName = formRequest.CriteriaName;
    var SalesOrder = await _salesOrderService.GetAllApprovedInvoice(request);
    return Ok(SalesOrder);
}





[HttpPost("UpdateInvoiceApprovalStatus")]
public async Task<IActionResult> ChangeInvoiceApprovalStatus([FromBody] List<SalesOrderUpdateApprovalStatusFormRequest> formRequests)
{
    GetAllSalesOrderResponse response = new GetAllSalesOrderResponse();
    foreach (var formRequest in formRequests)
    {
        var request = new UpdateSalesOrderApprovalStatusRequest
        {
            SalesOrderId = formRequest.SalesOrderId,
            SalesOrderStatusId = formRequest.SalesOrderStatusId,
        };

        response = await _salesOrderService.UpdateInvoiceApprovalStatusAsync(request);
    }
    return Ok(response);
}

[HttpPost("UpdateSalesOrder")]
public IActionResult UpdateSales(int id)
{
    UpdateSalesOrderRequest request = new UpdateSalesOrderRequest();
    request.Id = id;
    request.CustomerId = 1;
    request.ProductId = 1;
    request.UnitId = 1;
    request.SalesOrderStatusId = 1;
    request.Description = "3 days";
    request.OrderedDate = DateTime.Now;
    request.SalesOrderNo = "SO-77";
    request.Quantity = 50000;
    request.Price = 20;
    _salesOrderService.UpdateSalesOrder(request);
    return Ok();
}

[HttpGet("GetSalesOrderDetails")]
public async Task<IActionResult> GetSalesOrderById(int salesOrderId)
{
    var SalesOrder = await _salesOrderService.GetSalesOrderById(salesOrderId);
    return Ok(SalesOrder);
}



[HttpGet("ApprovedDeliveryOrderDetails")]
public async Task<IActionResult> GetApprovedDeliveryOrderDetails(int deliveryOrderId)
{
    var deliveryOrder = await _salesOrderService.GetApprovedDeliveryOrderDetailsAsync(deliveryOrderId);
    return Ok(deliveryOrder);
}

[HttpGet("GetSalesOrderDetailsByRedis")]
public async Task<IActionResult> GetSalesOrderByRedis()
{
    GetSalesOrderResponse response = new GetSalesOrderResponse();
    response = await _salesOrderService.GetSalesOrderById();

    return Ok(response);
}



[HttpPost("CreateCustomInvoices")]
public async Task<IActionResult> CreateCustomizeInvoices([FromBody] List<CreateInvoiceFormRequest> formRequests)
{
    try
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
    catch (Exception)
    {
        throw;
    }


}

[HttpPost("CreateCustomDO")]
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
            response = await _salesOrderService.CreateCustomDeliveryOrderAsync(request);
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


[HttpPost("CreateBankAccount")]
public IActionResult CreateBankAccount()
{
    _salesOrderService.CreateBankAccount();
    return Ok();
}

//Cookie Option
public void Set(string key, string value, int? expireTime)
{
    CookieOptions option = new CookieOptions();
    if (expireTime.HasValue)
        option.Expires = DateTime.Now.AddDays(expireTime.Value);
    else
        option.Expires = DateTime.Now.AddDays(1);
    Response.Cookies.Append(key, value, option);
}

public string Get(string key)
{
    return Request.Cookies[key];
}

public enum CookieDataKey
{
    SalesOrderId
}

public void Remove(string key)
{
    Response.Cookies.Delete(key);
}
 

        

        //// Example of caching data in ASP.NET Core Controller action
        //[HttpGet]
        //public async Task<IActionResult> GetSalesOrders()
        //{
        //var cacheKey = "CustomersData";
        //var cachedData = _memoryCache.Get(cacheKey);

        //    if (cachedData == null)
        //    {
        //        // Retrieve data from the database
        //        var salesOrders = await _repository.GetSalesOrders();

        //        // Cache the data for future requests
        //        _memoryCache.Set(cacheKey, salesOrders, TimeSpan.FromMinutes(10)); // Cache for 10 minutes
        //        return Ok(salesOrders);
        //    }

        //    return Ok(cachedData);
        //}

    }
}
