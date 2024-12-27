using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AenEnterprise.FrontEndMvc.Models.SalesOrder.CreateSalesOrderFormWithOrderItemsRequest;
using AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation;

namespace AenEnterprise.FrontEndMvc.Controllers.SalesOrderControllers
{
    [Route("api/CreateSalesOrder")]
    [ApiController]
    public class CreateSalesOrderController : ControllerBase
    {
        private readonly ICreateSalesOrderService _createSalesOrderService;
        public CreateSalesOrderController(ICreateSalesOrderService createSalesOrderService)
        {
            _createSalesOrderService = createSalesOrderService;
        }
       
        //[Authorize(Roles = "Admin")]
        [Route("Create")]
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
                response = await _createSalesOrderService.CreateSalesOrderAsync(salesOrderRequest);
            }
            return Ok(response);
        }
      
        //[Authorize(Roles = "Manager,Sales,Admin")]
        [HttpPost("AddSalesOrders")]
        public async Task<IActionResult> AddSalesOrdersForm()
        {
            await _createSalesOrderService.AddSalesOrdersAsync();
            return Ok("Sales order created successfully");
        }

        [Route("CancelSalesOrder")]
        [HttpPost]
        public async Task<IActionResult> CancelSalesOrderForm()
        {
            await _createSalesOrderService.DeleteSalesOrderAndOrderItemAsync();
            return Ok();
        }

    }
}
