using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.ServiceImplementations.Messaging.ProcurementManagement;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IPurchaseOrderService
    {
        Task<CreatePurchaseOrderResponse> CreatePurchaseOrderAsync(CreatePurchaseOrderRequest request);
        Task<bool> PurchaseItemExistsWithSameProduct(PurchaseOrder purchaseOrder, Product product, decimal price);

       
    }
}
