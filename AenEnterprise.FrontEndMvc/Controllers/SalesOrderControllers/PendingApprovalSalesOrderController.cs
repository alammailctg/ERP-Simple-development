using AenEnterprise.DataAccess.Criterias;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.FrontEndMvc.Models.SalesOrder;
using AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.FrontEndMvc.Controllers.SalesOrderControllers
{
    [Route("api/PendingApprovalSalesOrder")]
    [ApiController]
    public class PendingApprovalSalesOrderController : ControllerBase
    {
        private readonly IPendingSalesOrderService _pendingSalesOrderService;
        public PendingApprovalSalesOrderController(IPendingSalesOrderService pendingSalesOrderService)
        {
            _pendingSalesOrderService = pendingSalesOrderService;
        }

        //[Authorize(Roles="Manager,Admin")]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllUnApprovedSalesOrdersByCriteria(SalesOrderSearchCriteriaFormRequest formRequest)
        {
            SalesOrderCriteria request = new SalesOrderCriteria();
            request.PageNumber = formRequest.PageNumber;
            request.PageSize = formRequest.PageSize;
            request.DateFrom = formRequest.DateFrom;
            request.DateTo = formRequest.DateTo;
            request.CriteriaName = formRequest.CriteriaName;
            var SalesOrder = await _pendingSalesOrderService.GetAllUnApprovedOrderItems(request);
            return Ok(SalesOrder);
        }

        //[Authorize(Roles ="Sales,Manager,Admin")]
        [HttpPost("ApprovalAction")]
        public async Task<IActionResult> ApprovalActionForm([FromBody] List<SalesOrderUpdateApprovalStatusFormRequest> formRequests)
        {
            GetAllSalesOrderResponse response = new GetAllSalesOrderResponse();
            try
            {
                foreach (var formRequest in formRequests)
                {
                    var request = new UpdateSalesOrderApprovalStatusRequest
                    {
                        SalesOrderId = formRequest.SalesOrderId,
                        StatusId = formRequest.StatusId,
                        OrderItemId = formRequest.OrderItemId
                    };
                    response = await _pendingSalesOrderService.ApprovalActionAsync(request);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


     

    }
}
