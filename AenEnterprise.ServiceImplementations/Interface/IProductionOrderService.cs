using AenEnterprise.ServiceImplementations.Messaging.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IProductionOrderService
    {
        Task<GetProductionOrderResponse> CreateProductionOrderAsync(CreateProductionOrderRequest request);
        Task<GetAllProductionOrder> GetAllProductionOrderAsync(ProductionOrderCriteria Criteria);
        Task<CreateCostTransactionResponse> CreateCostTransaction(CreateCostTransactionRequest request);
    }
}
