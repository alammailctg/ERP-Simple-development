using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.SupplyAndChainManagement;

namespace AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation
{
    public interface ICreateSalesOrderService
    {
        Task<GetSalesOrderResponse> CreateSalesOrderAsync(CreateSalesOrderRequest request);
        Task<bool> OrderItemExistsWithSameProduct(SalesOrder salesOrder, Product product, decimal price);
        Task AddSalesOrdersAsync();
        Task DeleteSalesOrderAndOrderItemAsync();
    }
}
