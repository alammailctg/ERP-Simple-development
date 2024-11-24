using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DeliveryOrderMessage;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DispatchOrder;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public interface IDOService
    {
        Task<CreateDeliveryOrderResponse> CreateCustomDeliveryOrderAsync(CreateDeliveryOrderRequest request);
        Task<GetAllDeliveryOrderResponse> GetAllApproveDeliveryOrder(SalesOrderSearchCriteriaRequest request);
        Task<GetAllDeliveryOrderResponse> ApprovalStatusDeliveryOrderAsync(UpdateSalesOrderApprovalStatusRequest request);
        Task<GetAllDeliveryOrderResponse> GetAllUnApproveDeliveryOrder(SalesOrderSearchCriteriaRequest request);
        Task<CreateDispatchResponse> CreateCustomDispatchAsync(CreateDispatchRequest request);
        Task<GetDeliveryOrderResponse> GetApprovedDeliveryOrderDetailsAsync(int deliveryOrderId);
    }

    
  
}