using AenEnterprise.DataAccess.Criterias;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation
{
    public interface IPendingSalesOrderService
    {
        Task<GetAllSalesOrderResponse> GetAllUnApprovedOrderItems(SalesOrderCriteria request);
        Task<GetAllSalesOrderResponse> ApprovalActionAsync(UpdateSalesOrderApprovalStatusRequest request);
    }
}
