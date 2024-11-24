using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.ProcurementManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    [Route("api/PurchaseOrder")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IUnitOfWork uow, IPurchaseOrderService purchaseOrderService)
        {
            _uow = uow;
            _purchaseOrderService = purchaseOrderService;
        }

        [Route("CreatePurchaseOrder")]
        [HttpPost]
        public async Task<ActionResult> CreatePurchaseOrderForm([FromBody] CreatePurchaseOrderFormRequest fromBodyRequest)
        {
            CreatePurchaseOrderResponse response = new CreatePurchaseOrderResponse();
            CreatePurchaseOrderRequest request = new CreatePurchaseOrderRequest();
            request.PurchaseDate = DateTime.Today;
            request.SupplierId = fromBodyRequest.SupplierId;
            request.ProductId = fromBodyRequest.ProductId;
            request.Quantity = fromBodyRequest.Quantity;
            request.UnitId = fromBodyRequest.UnitId;
            request.Price = fromBodyRequest.Price;
            response = await _purchaseOrderService.CreatePurchaseOrderAsync(request);
            return Ok(response);
        }
    }
}


