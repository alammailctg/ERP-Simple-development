using AenEnterprise.DataAccess.Criterias;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AenEnterprise.FrontEndMvc.Controllers.SalesOrderControllers
{
    [Route("api/ApprovedSalesOrder")]
    [ApiController]
    public class ApprovedSalesOrderController : ControllerBase
    {
        private readonly IApprovedSalesOrderService _approvedSalesOrderService;
        public ApprovedSalesOrderController(IApprovedSalesOrderService approvedSalesOrderService)
        {
            _approvedSalesOrderService = approvedSalesOrderService;
        }

        [Route("GetAll")]
        [HttpPost]
        public async Task<IActionResult> GetAllApprovedSalesOrdersByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
        {
            SalesOrderCriteria request = new SalesOrderCriteria();
            request.PageNumber = formRequest.PageNumber;
            request.PageSize = formRequest.PageSize;
            request.DateFrom = formRequest.DateFrom;
            request.DateTo = formRequest.DateTo;
            request.CriteriaName = formRequest.CriteriaName;
            var SalesOrder = await _approvedSalesOrderService.GetAllApprvedSalesOrders(request);
            return Ok(SalesOrder);
        }
    }
}
