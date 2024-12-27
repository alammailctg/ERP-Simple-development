using AenEnterprise.DataAccess.Criterias;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;

namespace AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation
{
    public interface IApprovedSalesOrderService
    {
        Task<GetAllSalesOrderResponse> GetAllApprvedSalesOrders(SalesOrderCriteria request);
    }
}