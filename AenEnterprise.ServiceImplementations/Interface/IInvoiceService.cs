using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.Invoice;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Interface
{
    public interface IInvoiceService
    {
        Task<CreateInvoiceResponse> CreateCustomInvoiceAsync(CreateInvoiceRequest request);
        Task<GetAllInvoiceReponse> GetAllInvoiceAsync();
        Task<GetAllSalesOrderResponse> UpdateInvoiceApprovalStatusAsync(UpdateSalesOrderApprovalStatusRequest request);
        Task<GetAllInvoiceResponse> ApprovalStatusInvoiceAsync(UpdateSalesOrderApprovalStatusRequest request);
        Task<GetAllInvoiceResponse> GetAllUnApprovedInvoice(SalesOrderSearchCriteriaRequest request);
        Task<GetAllInvoiceResponse> GetAllApprovedInvoice(SalesOrderSearchCriteriaRequest request);
        Task<GetInvoiceResponse> GetApprovedInvoiceDetailsAsync(int invoiceId);
         
        Task<GetAllInvoiceResponse> GetApprovedInvoice(SalesOrderSearchCriteriaRequest request);
        Task<GetSalesOrderResponse> GetApprovedOrderItemDetailsAsync(int salesOrderId);


    }
}
