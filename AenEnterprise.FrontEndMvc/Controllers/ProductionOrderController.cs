using AenEnterprise.FrontEndMvc.Models.ProductionOrder;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Implementation.InventoryManagement;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.InventoryManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AspNetCore.Reporting.ReportExecutionService;
using AenEnterprise.ServiceImplementations;
using StackExchange.Redis;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;


[Route("api/ProductionOrder")]
[ApiController]
public class ProductionOrderController : ControllerBase
{
    private readonly IProductionOrderService _productionOrderService;
    private readonly ILogger<ProductionOrderController> _logger;
    private readonly IDatabase _redisDb;
    private readonly RedisConnection _redisConnection;
    

    public ProductionOrderController(IProductionOrderService productionOrderService, 
        ILogger<ProductionOrderController> logger,
        RedisConnection redisConnection)
    {
        _redisDb = redisConnection.GetDatabase();
        _redisConnection = redisConnection;
        _productionOrderService = productionOrderService;
        _logger = logger;
    }


    [Route("CreateProductionOrder")]
    [HttpPost]
    public async Task<IActionResult> CreateProductionOrder([FromBody] CreateProductionOrderFormWithOrderItemRequest request)
    {
        if (request == null || request.ItemFormRequests == null)
        {
            return BadRequest("Request body is null or improperly formatted.");
        }

        GetProductionOrderResponse response = new GetProductionOrderResponse();
        foreach (var orderItem in request.ItemFormRequests)
        {
            CreateProductionOrderRequest productionOrderRequest = new CreateProductionOrderRequest
            {
                ProductionStartDate = request.OrderFormRequest.ProductionStartDate,
                ProductionEndDate = request.OrderFormRequest.ProductionEndDate,
                AssignedToId = request.OrderFormRequest.AssignedToId,
                InitiatorId = request.OrderFormRequest.InitiatorId,
                Remarks = request.OrderFormRequest.Remarks,
                OrderPriorityId = request.OrderFormRequest.OrderPriorityId,
                InitialProductionCost = request.OrderFormRequest.InitialProductionCost,
                ProductId = orderItem.ProductId,
                BranchId = request.OrderFormRequest.BranchId,
                QuantityRequested = orderItem.QuantityRequested,
                QuantityProduced = 0,
                ProductionOrderNo=request.OrderFormRequest.ProductionOrderNo,
                UnitId=orderItem.UnitId,

            };
           response = await _productionOrderService.CreateProductionOrderAsync(productionOrderRequest);
        }
        await _redisDb.KeyDeleteAsync("ProductionOrderId");
        return Ok(response);
         
    }

    [Route("GetAllProductionOrderByCriteria")]
    [HttpPost]
    public async Task<IActionResult> GetAllUnApprovedProductionOrdersByCriteria([FromQuery] ProductionOrderCriteria formRequest)
    {
        ProductionOrderCriteria request = new ProductionOrderCriteria();
        request.PageNumber = formRequest.PageNumber;
        request.PageSize = formRequest.PageSize;
        request.ProductionStartDate = formRequest.ProductionStartDate;
        request.ProductionEndDate = formRequest.ProductionEndDate;
        request.CriteriaName = formRequest.CriteriaName;
        var productionOrder = await _productionOrderService.GetAllProductionOrderAsync(request);
        return Ok(productionOrder);
    }

    [HttpPost("CreateCostTransaction")]
    public async Task<ActionResult<CreateCostTransactionResponse>> CreateCostTransaction([FromBody] CreateCostTransactionRequest request)
    {
        if (request == null)
        {
            _logger.LogWarning("Received a null request for creating CostTransaction.");
            return BadRequest("Request cannot be null.");
        }

        _logger.LogInformation("Processing CreateCostTransaction request.");

        var response = await _productionOrderService.CreateCostTransaction(request);
        return Ok(response);
    }
}
