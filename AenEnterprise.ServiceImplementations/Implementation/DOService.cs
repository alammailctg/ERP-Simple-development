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
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DeliveryOrderMessage;
using AenEnterprise.ServiceImplementations.Mapping;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using Microsoft.EntityFrameworkCore;
using AenEnterprise.ServiceImplementations.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DispatchOrder;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public class DOService : IDOService
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
        public DOService(ISalesOrderRepository salesOrderRepository,
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

        public async Task<CreateDeliveryOrderResponse> CreateCustomDeliveryOrderAsync(CreateDeliveryOrderRequest request)
        {
            try
            {
                CreateDeliveryOrderResponse response = new CreateDeliveryOrderResponse();
                Invoice invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);
                var orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId);
                string DeliveryOrderId = _request.HttpContext.Session.GetString("DeliveryOrderId");

                if (DeliveryOrderId != null)
                {
                    if (int.TryParse(DeliveryOrderId, out int parseDeliveryId))
                    {
                        DeliveryOrder deliveryOrder = await _deliveryOrderRepository.GetByIdAsync(parseDeliveryId);
                        if (invoice != null)
                        {
                            deliveryOrder.CreateDeliveryOrderItem(orderItem, request.DeliveryQuantity);
                            await _deliveryOrderRepository.UpdateAsync(deliveryOrder);
                            response.DeliveryOrder = deliveryOrder.ConvertToDeliveryOrderView(_mapper, 1, true);
                        }
                    }
                }
                else
                {
                    var deliveries = await _deliveryOrderRepository.FindAllAsync();
                    int LastDOId = deliveries.Any() ? deliveries.Last().Id : 0;
                    DeliveryOrder newDeliveryOrder = new DeliveryOrder();
                    newDeliveryOrder.InvoiceId = request.InvoiceId;

                    newDeliveryOrder.SalesOrderId = invoice.SalesOrderId;

                    if (LastDOId > 0)
                    {
                        newDeliveryOrder.DeliveryOrderNo = "DO-" + (LastDOId + 1).ToString();
                    }
                    else
                    {
                        newDeliveryOrder.DeliveryOrderNo = "DO-1";
                    }

                    newDeliveryOrder.CreateDeliveryOrderItem(orderItem, request.DeliveryQuantity);
                    await _deliveryOrderRepository.AddAsync(newDeliveryOrder); // Add newDeliveryOrder to the repository
                    response.DeliveryOrder = newDeliveryOrder.ConvertToDeliveryOrderView(_mapper, 1, true);
                    _request.HttpContext.Session.SetString("DeliveryOrderId", response.DeliveryOrder.Id.ToString());
                }

                await AddInvoiceItem(request.invoiceItemIdToAdd, invoice, request.DeliveryQuantity);
                await _invoiceRepository.UpdateAsync(invoice);
                await _unitOfWork.SaveAsync(); // Save changes to the database
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task AddInvoiceItem(IList<int> invoiceItemIdToAdd, Invoice invoice, decimal quantity)
        {
            foreach (int invoiceItemId in invoiceItemIdToAdd)
            {
                InvoiceItem invoiceItem = await _invoiceItemRepository.GetByIdAsync(invoiceItemId);
                if (invoiceItem != null)
                {
                    invoice.setInvoiceItem(invoiceItem, quantity);
                    await _invoiceItemRepository.UpdateAsync(invoiceItem);
                }
                else
                {
                    // Handle the case where the order item was not found (e.g., log an error or throw an exception).
                    // Depending on your application's requirements, you may choose to skip this order item or take other actions.
                }
            }
        }
        public async Task<GetAllDeliveryOrderResponse> ApprovalStatusDeliveryOrderAsync(UpdateSalesOrderApprovalStatusRequest request)
        {
            GetAllDeliveryOrderResponse response = new GetAllDeliveryOrderResponse();
            IEnumerable<DeliveryOrder> deliveryOrders = await _deliveryOrderRepository.FindAllAsync();
            var deliveryOrderItem = await _deliveryItemOrderRepository.GetByIdAsync(request.DeliveryOrderItemId);

            try
            {
                if (deliveryOrderItem != null)
                {
                    deliveryOrderItem.StatusId = request.StatusId;
                    await _deliveryItemOrderRepository.UpdateAsync(deliveryOrderItem);
                    await _unitOfWork.SaveAsync();

                    response.DeliveryOrders = deliveryOrders.ConvertToDeliveryOrderViews(_mapper, 1, true);
                    return response;
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
        }
        public async Task<GetAllDeliveryOrderResponse> GetAllUnApproveDeliveryOrder(SalesOrderSearchCriteriaRequest request)
        {
            GetAllDeliveryOrderResponse response = new GetAllDeliveryOrderResponse();

            var deliveryIdsWithStatus1 = await _context.DeliveryOrders
                .Where(so => so.DeliveryOrderItems.Any(inv => inv.StatusId == 1 && inv.IsActive == true))
                .Select(so => so.Id)
                .ToListAsync();

            IQueryable<DeliveryOrder> salesOrderByCriteria = _context.DeliveryOrders
                .Include(d => d.SalesOrder)
        .ThenInclude(s => s.Customer)
    .Include(d => d.DeliveryOrderItems)
    .ThenInclude(doi => doi.OrderItem)  // Ensure OrderItem is loaded
            .ThenInclude(oi => oi.Product)
                .Where(e =>
                    EF.Functions.Like(e.Invoice.SalesOrder.Customer.Name, $"%{request.CriteriaName}%") ||
                    EF.Functions.Like(e.Invoice.SalesOrder.SalesOrderNo, $"%{request.CriteriaName}%") ||
                    e.Invoice.InvoiceItems.Any(oi =>
                        EF.Functions.Like(oi.OrderItem.Product.Name, $"%{request.CriteriaName}%") ||
                        EF.Functions.Like(oi.OrderItem.Price.ToString(), $"%{request.CriteriaName}%")
                    ) ||
                    EF.Functions.Like(e.Invoice.InvoiceNo, $"%{request.CriteriaName}%")
                );

            IQueryable<DeliveryOrder> salesOrderByDateRange = salesOrderByCriteria
                .Where(dt => dt.SalesOrder.OrderedDate.Date >= request.DateFrom.Date && dt.SalesOrder.OrderedDate.Date <= request.DateTo.Date.AddDays(1))
                .OrderByDescending(or => or.SalesOrder.OrderedDate)
                .Where(so => deliveryIdsWithStatus1.Contains(so.Id));

            int totalCount = await salesOrderByDateRange.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);
            int skipCount = (request.PageNumber - 1) * request.PageSize;

            IEnumerable<DeliveryOrder> paginateSalesOrder = await salesOrderByDateRange
                .Skip(skipCount)
                .Take(request.PageSize)
                .ToListAsync();

            response.DeliveryOrders = paginateSalesOrder.ConvertToDeliveryOrderViews(_mapper, 1, true);
            response.TotalPages = totalPages;
            response.PageNumber = request.PageNumber;
            response.PageSize = request.PageSize;
            response.TotalCount = totalCount;

            await _unitOfWork.SaveAsync();

            return response;
        }
        public async Task<GetAllDeliveryOrderResponse> GetAllApproveDeliveryOrder(SalesOrderSearchCriteriaRequest request)
        {
            GetAllDeliveryOrderResponse response = new GetAllDeliveryOrderResponse();

            var deliveryIdsWithStatus2 = await _context.DeliveryOrders
                .Where(so => so.DeliveryOrderItems.Any(inv => inv.StatusId == 2 && inv.IsActive == true))
                .Select(so => so.Id)
                .ToListAsync();

            IQueryable<DeliveryOrder> salesOrderByCriteria = _context.DeliveryOrders
                .Include(d => d.SalesOrder)
                .ThenInclude(s => s.Customer)
            .Include(d => d.DeliveryOrderItems)
            .ThenInclude(doi => doi.OrderItem)  // Ensure OrderItem is loaded
            .ThenInclude(oi => oi.Product)
                .Where(e =>
                    EF.Functions.Like(e.Invoice.SalesOrder.Customer.Name, $"%{request.CriteriaName}%") ||
                    EF.Functions.Like(e.Invoice.SalesOrder.SalesOrderNo, $"%{request.CriteriaName}%") ||
                    e.Invoice.InvoiceItems.Any(oi =>
                        EF.Functions.Like(oi.OrderItem.Product.Name, $"%{request.CriteriaName}%") ||
                        EF.Functions.Like(oi.OrderItem.Price.ToString(), $"%{request.CriteriaName}%")
                    ) ||
                    EF.Functions.Like(e.Invoice.InvoiceNo, $"%{request.CriteriaName}%")
                );

            IQueryable<DeliveryOrder> salesOrderByDateRange = salesOrderByCriteria
                .Where(dt => dt.SalesOrder.OrderedDate.Date >= request.DateFrom.Date && dt.SalesOrder.OrderedDate.Date <= request.DateTo.Date.AddDays(1))
                .OrderByDescending(or => or.SalesOrder.OrderedDate)
                .Where(so => deliveryIdsWithStatus2.Contains(so.Id));

            int totalCount = await salesOrderByDateRange.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);
            int skipCount = (request.PageNumber - 1) * request.PageSize;

            IEnumerable<DeliveryOrder> paginateSalesOrder = await salesOrderByDateRange
                .Skip(skipCount)
                .Take(request.PageSize)
                .ToListAsync();

            response.DeliveryOrders = paginateSalesOrder.ConvertToDeliveryOrderViews(_mapper, 2, true);
            response.TotalPages = totalPages;
            response.PageNumber = request.PageNumber;
            response.PageSize = request.PageSize;
            response.TotalCount = totalCount;

            await _unitOfWork.SaveAsync();

            return response;
        }
        public async Task<CreateDispatchResponse> CreateCustomDispatchAsync(CreateDispatchRequest request)
        {
            try
            {
                CreateDispatchResponse response = new CreateDispatchResponse();
                DeliveryOrder deliveryOrder = await _deliveryOrderRepository.GetByIdAsync(request.DeliveryOrderId);
                OrderItem orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId);

                string DispatchId = _request.HttpContext.Session.GetString("DispatchId");

                if (DispatchId != null)
                {
                    if (int.TryParse(DispatchId, out int parseDispatchId))
                    {
                        DispatcheOrder dispatchOrder = await _dispatcheRepository.GetByIdAsync(parseDispatchId);
                        if (dispatchOrder != null)
                        {
                            dispatchOrder.CreateDispatchItem(orderItem, request.VehicalNo, request.VehicalEmptyWeight, request.VehicalLoadWeight, request.DispatchQuantity, 1);
                            await _dispatcheRepository.UpdateAsync(dispatchOrder);
                            response.DispatcheOrder = dispatchOrder.ConvertToDispatchView(1, true);
                        }
                    }
                }
                else
                {
                    var dispatchs = await _dispatcheRepository.FindAllAsync();
                    int LastDispatchId = dispatchs.Any() ? dispatchs.Last().Id : 0;
                    DispatcheOrder newDispatch = new DispatcheOrder();
                    newDispatch.DeliveryOrderId = deliveryOrder.Id;
                    newDispatch.InvoiceId = deliveryOrder.InvoiceId;
                    newDispatch.SalesOrderId = deliveryOrder.SalesOrderId;

                    if (LastDispatchId > 0)
                    {
                        newDispatch.DispatcheNo = "GP-" + (LastDispatchId + 1).ToString();
                    }
                    else
                    {
                        newDispatch.DispatcheNo = "GP-1";
                    }

                    newDispatch.CreateDispatchItem(orderItem, request.VehicalNo, request.VehicalEmptyWeight, request.VehicalLoadWeight, request.DispatchQuantity, 1);
                    await _dispatcheRepository.AddAsync(newDispatch);
                    response.DispatcheOrder = newDispatch.ConvertToDispatchView(1, true);
                    _request.HttpContext.Session.SetString("DispatchId", response.DispatcheOrder.Id.ToString());
                }

                await AddDeliveryItem(request.deliveryItemToAdd, deliveryOrder, request.DispatchQuantity);
                await _deliveryOrderRepository.UpdateAsync(deliveryOrder);
                await _unitOfWork.SaveAsync();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task AddDeliveryItem(IList<int> deliveryItemIdToAdd, DeliveryOrder deliveryOrder, decimal quantity)
        {
            foreach (int deliveryItemId in deliveryItemIdToAdd)
            {
                DeliveryOrderItem deliveryItem = await _deliveryItemOrderRepository.GetByIdAsync(deliveryItemId);
                if (deliveryItem != null)
                {
                    deliveryOrder.setDeliveryOrderItem(deliveryItem, quantity);
                    await _deliveryItemOrderRepository.UpdateAsync(deliveryItem);
                }
                else
                {

                }
            }
        }
        public async Task<GetDeliveryOrderResponse> GetApprovedDeliveryOrderDetailsAsync(int deliveryOrderId)
        {
            GetDeliveryOrderResponse response = new GetDeliveryOrderResponse();
            DeliveryOrder deliveryOrder = await _deliveryOrderRepository.GetByIdAsync(deliveryOrderId); // Adjust this method to load SalesOrder without Invoices

            // Check if the SalesOrder entity is retrieved
            if (deliveryOrderId != null)
            {
                response.DeliveryOrder = deliveryOrder.ConvertToDeliveryOrderView(_mapper,2, true);
            }
            else
            {
                // Handle scenario where SalesOrder couldn't be loaded
                // For instance, log an error or set response.SalesOrder to null
                response.DeliveryOrder = null;
            }

            return response;
        }


    }



}
