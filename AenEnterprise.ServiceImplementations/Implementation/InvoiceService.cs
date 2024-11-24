using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess;
using AenEnterprise.DomainModel.CookieStorage;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.Invoice;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.Mapping;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using Vonage.Applications.Capabilities;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.AccountReceivable;
using AenEnterprise.ServiceImplementations.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public class InvoiceService:IInvoiceService
    {
        private AenEnterpriseDbContext _context;
        private ISalesOrderRepository _salesOrderRepository;
        private IUnitOfWork _unitOfWork;
        private IBankAccountRepository _bankAccountRepository;
        private IProductRepository _productRepository;
        private ISalesOrderStatusRepository _salesOrderStatusRepository;
        private IUnitRepository _unitRepository;
        private IOrderItemRepository _orderItemRepository;
        private readonly HttpRequest _request;
        private IInvoiceRepository _invoiceRepository;
        private IInvoiceItemRepository _invoiceItemRepository;
        private ICustomerRepository _customerRepository;
        private IDeliveryOrderRepository _deliveryOrderRepository;
        private IDeliveryOrderItemRepository _deliveryItemOrderRepository;
        private IDispatcheRepository _dispatcheRepository;
        private ICookieImplementation _cookieImplementation;
        private IMapper _mapper;
        public InvoiceService(ISalesOrderRepository salesOrderRepository,
            IBankAccountRepository bankAccountRepository,
            IUnitOfWork unitOfWork, IProductRepository productRepository,
            IUnitRepository unitRepository,
            ISalesOrderStatusRepository salesOrderStatusRepository,
            IOrderItemRepository orderItemRepository,
        IHttpContextAccessor httpContextAccessor,
            IInvoiceRepository invoiceRepository,
            ICustomerRepository customerRepository,
        IDeliveryOrderRepository deliveryOrderRepository,
        IDispatcheRepository dispatcheRepository,
        ICookieImplementation cookieImplementation,
        IInvoiceItemRepository invoiceItemRepository,
        IDeliveryOrderItemRepository deliveryItemOrderRepository,
        IMapper mapper)
        {
            _context = new AenEnterpriseDbContext();
            _orderItemRepository = orderItemRepository;
            _salesOrderStatusRepository = salesOrderStatusRepository;
            _unitRepository = unitRepository;
            _salesOrderRepository = salesOrderRepository;
            _unitOfWork = unitOfWork;
            _bankAccountRepository = bankAccountRepository;
            _productRepository = productRepository;
            _cookieImplementation = cookieImplementation;
            _request = httpContextAccessor.HttpContext.Request;
            _invoiceRepository = invoiceRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _customerRepository = customerRepository;
            _deliveryOrderRepository = deliveryOrderRepository;
            _dispatcheRepository = dispatcheRepository;
            _deliveryItemOrderRepository = deliveryItemOrderRepository;
            _mapper = mapper;
        }

        public async Task<CreateInvoiceResponse> CreateCustomInvoiceAsync(CreateInvoiceRequest request)
        {
                CreateInvoiceResponse response = new CreateInvoiceResponse();
                SalesOrder salesOrder = await _salesOrderRepository.GetByIdAsync(request.SalesOrderId);
                OrderItem orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId);
               
                // Invoice Part
                var lastOrderItem = salesOrder.LastOrderItem(request.OrderItemId);

                if (lastOrderItem != null)
                {
                    string invoiceId = _request.HttpContext.Session.GetString("InvoiceId");
                    if (invoiceId != null)
                    {
                        if (int.TryParse(invoiceId, out int parseInvoiceId))
                        {
                           Invoice invoice = await _invoiceRepository.GetByIdAsync(parseInvoiceId);
                            if (invoice != null)
                            {
                                invoice.CreateInvoiceItem(orderItem, request.InvoiceQuantity, 1);
                                await _invoiceRepository.UpdateAsync(invoice);
                                response.Invoice = invoice.ConvertToInvoiceView(_mapper,1,true);
                            }
                        }
                    }
                    else
                    {
                        var invoices = await _invoiceRepository.FindAllAsync();
                        int LastInvoiceId = invoices.Any() ? invoices.Last().Id : 0;
                        Invoice newInvoice = new Invoice();
                        newInvoice.SalesOrderId = request.SalesOrderId;
                        if (LastInvoiceId > 0)
                        {
                            newInvoice.InvoiceNo = "INV-" + (LastInvoiceId + 1).ToString();
                        }
                        else
                        {
                            newInvoice.InvoiceNo = "INV-1";
                        }

                        newInvoice.CreateInvoiceItem(orderItem, request.InvoiceQuantity, 1);
                        await _invoiceRepository.AddAsync(newInvoice);

                        response.Invoice = newInvoice.ConvertToInvoiceView(_mapper,1, true);
                        _request.HttpContext.Session.SetString("InvoiceId", response.Invoice.Id.ToString());
                    }

                    await AddOrderItem(request.orderItemIdToAdd, salesOrder, request.InvoiceQuantity);
                    await _salesOrderRepository.UpdateAsync(salesOrder);
                    await _unitOfWork.SaveAsync();
                }

                return response;
             
             
        }
        public async Task<GetAllInvoiceReponse> GetAllInvoiceAsync()
        {
            GetAllInvoiceReponse response = new GetAllInvoiceReponse();
            IEnumerable<Invoice> invoices = await _invoiceRepository.FindAllAsync();
            response.Invoices = invoices.ConvertToViews<Invoice, InvoiceView>(_mapper);
            return response;
        }
        public Task<GetAllSalesOrderResponse> UpdateInvoiceApprovalStatusAsync(UpdateSalesOrderApprovalStatusRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<GetAllInvoiceResponse> ApprovalStatusInvoiceAsync(UpdateSalesOrderApprovalStatusRequest request)
        {
            GetAllInvoiceResponse response = new GetAllInvoiceResponse();
            Invoice invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);
            InvoiceItem invoiceItem = await _invoiceItemRepository.GetByIdAsync(request.InvoiceItemId);

            try
            {
                if (invoice != null)
                {
                    invoiceItem.StatusId = request.StatusId;
                    await _invoiceItemRepository.UpdateAsync(invoiceItem);
                    await _invoiceRepository.UpdateAsync(invoice);

                    response.Invoice = invoice.ConvertToInvoiceView(_mapper, 1, true);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, SalesOrder not found", ex);
            }

            await _unitOfWork.SaveAsync();
            return response;
        }
        private async Task AddOrderItem(IList<int> orderItemIdToAdd, SalesOrder salesOrder, decimal quantity)
        {
            foreach (int orderItemId in orderItemIdToAdd)
            {
                OrderItem orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
                if (orderItem != null)
                {
                    salesOrder.setOrderItem(orderItem, quantity);
                    await _orderItemRepository.UpdateAsync(orderItem);
                }
                else
                {
                    // Handle the case where the order item was not found (e.g., log an error or throw an exception).
                    // Depending on your application's requirements, you may choose to skip this order item or take other actions.
                }
            }
        }
        public async Task<GetAllInvoiceResponse>GetAllUnApprovedInvoice(SalesOrderSearchCriteriaRequest request)
        {
            return await GetAllInvoice(request, 1);
        }
        public async Task<GetAllInvoiceResponse> GetAllApprovedInvoice(SalesOrderSearchCriteriaRequest request)
        {
           return await GetAllInvoice(request,2);
        }
        public async Task<GetAllInvoiceResponse> GetAllInvoice(SalesOrderSearchCriteriaRequest request, int statusId)
        {
            GetAllInvoiceResponse response = new GetAllInvoiceResponse();

            var invoiceIdsWithStatus1 = await _context.Invoices
                .Where(so => so.InvoiceItems.Any(inv => inv.StatusId == statusId && inv.IsActive == true))
                .Select(so => so.Id)
                .ToListAsync();

            IQueryable<Invoice> salesOrderByCriteria = _context.Invoices
                .Include(e => e.SalesOrder)
                .ThenInclude(s => s.Customer)
                .Include(e => e.InvoiceItems) // Include InvoiceItems
                .ThenInclude(i => i.OrderItem) // Include related OrderItem
                .ThenInclude(oi => oi.Product) // Include related Product
                .Where(e =>
                    EF.Functions.Like(e.SalesOrder.Customer.Name, $"%{request.CriteriaName}%") ||
                    EF.Functions.Like(e.SalesOrder.SalesOrderNo, $"%{request.CriteriaName}%") ||
                    e.InvoiceItems.Any(oi =>
                        EF.Functions.Like(oi.OrderItem.Product.Name, $"%{request.CriteriaName}%") ||
                        EF.Functions.Like(oi.OrderItem.Price.ToString(), $"%{request.CriteriaName}%")
                    ) ||
                    EF.Functions.Like(e.InvoiceNo, $"%{request.CriteriaName}%")
                );

            IQueryable<Invoice> salesOrderByDateRange = salesOrderByCriteria
                .Where(dt => dt.SalesOrder.OrderedDate.Date >= request.DateFrom.Date && dt.SalesOrder.OrderedDate.Date <= request.DateTo.Date.AddDays(1))
                .OrderByDescending(or => or.SalesOrder.OrderedDate).ThenByDescending(inv => inv.InvoiceNo)
                .Where(so => invoiceIdsWithStatus1.Contains(so.Id));

            int totalCount = await salesOrderByDateRange.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);
            int skipCount = (request.PageNumber - 1) * request.PageSize;

            IEnumerable<Invoice> paginateSalesOrder = await salesOrderByDateRange
                .Skip(skipCount)
                .Take(request.PageSize)
                .ToListAsync();

            response.Invoices = paginateSalesOrder.ConvertToInvoiceViews(_mapper, statusId, true);
            response.TotalPages = totalPages;
            response.PageNumber = request.PageNumber;
            response.PageSize = request.PageSize;
            response.TotalCount = totalCount;

            await _unitOfWork.SaveAsync();

            return response;

        }


        public async Task<GetInvoiceResponse> GetApprovedInvoiceDetailsAsync(int invoiceId)
        {
            GetInvoiceResponse response = new GetInvoiceResponse();
            Invoice invoice = await _invoiceRepository.GetInvoiceByIncludeId(invoiceId);

            if (invoice != null)
            {
                response.Invoice = invoice.ConvertToInvoiceView(_mapper, 2, true);
            }
            else
            {
                // Handle scenario where SalesOrder couldn't be loaded
                // For instance, log an error or set response.SalesOrder to null
                response.Invoice = null;
            }

            return response;
        }
        public async Task<GetSalesOrderResponse> GetApprovedOrderItemDetailsAsync(int salesOrderId)
        {
            GetSalesOrderResponse response = new GetSalesOrderResponse();

            // Retrieve the SalesOrder entity with Invoices navigation property eagerly loaded
            SalesOrder salesOrder = await _salesOrderRepository.GetSalesOrderByIncludeId(salesOrderId); // Adjust this method to load SalesOrder without Invoices

            // Check if the SalesOrder entity is retrieved
            if (salesOrder != null)
            {
                // Convert SalesOrder to SalesOrderView
                response.SalesOrder = salesOrder.ConvertToSalesOrderView(_mapper, 2, true);

                // Calculate total amount from order items
                if (response.SalesOrder.OrderItems != null)
                {
                    response.SalesOrder.TotalAmount = response.SalesOrder.OrderItems
                        .Sum(item => item.Amount);
                    response.SalesOrder.TotalInvoicedQuantity = response.SalesOrder.OrderItems
                        .Sum(item => item.InvoicedQuantity);
                    response.SalesOrder.TotalQuantity = response.SalesOrder.OrderItems
                        .Sum(item => item.Quantity);

                }
                else
                {
                    response.SalesOrder.TotalAmount = 0; // If there are no order items
                }
            }
            else
            {
                // Handle scenario where SalesOrder couldn't be loaded
                // For instance, log an error or set response.SalesOrder to null
                response.SalesOrder = null;
            }
            return response;
        }
        public Task<GetAllInvoiceResponse> GetApprovedInvoice(SalesOrderSearchCriteriaRequest request)
        {
            throw new NotImplementedException();
        }
 
    }
}
