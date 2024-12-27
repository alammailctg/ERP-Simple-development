using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess;
using AenEnterprise.DomainModel.CookieStorage;
using AenEnterprise.ServiceImplementations.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.Invoice;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DeliveryOrderMessage;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.DispatchOrder;
using AenEnterprise.ServiceImplementations.Messaging.InventoryManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using AenEnterprise.ServiceImplementations.Mapping;
using AenEnterprise.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using Microsoft.Extensions.Logging;
using AenEnterprise.ServiceImplementations.ViewModel;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using AenEnterprise.DomainModel.UserDomain;
using System.Security.Claims;


namespace AenEnterprise.ServiceImplementations.Implementation
{

    public class SalesOrderService : ISalesOrderService
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
        private readonly IDistributedCache _cache;
        private readonly IDatabase _redisDb;
        private readonly RedisConnection _redisConnection;
        private readonly ILogger<SalesOrderService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository,
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
        IMapper mapper,
        RedisConnection redisConnection,
        ILogger<SalesOrderService> logger, 
        IDistributedCache cache)
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
            _redisDb = redisConnection.GetDatabase();
            _redisConnection = redisConnection;
            _logger = logger;
           
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<SalesOrderView>> GetAllSalesOrderUsingLinq()
        {
            var salesOrders = from s in _context.SalesOrders
                              join c in _context.Customers
                              on s.CustomerId equals c.Id  // Correct join condition
                              group s by c.Name into customerNameGroup
                              select new SalesOrderView
                              {
                                  CustomerName = customerNameGroup.Key,
                                  SalesOrders = customerNameGroup.Select(s => new SalesOrderDetails
                                  {
                                      SalesOrderNo = s.SalesOrderNo,
                                      OrderedDate = s.OrderedDate
                                  }).ToList()
                              };

            return await salesOrders.ToListAsync();
        }
        public class SalesOrderDetails
        {
            public string SalesOrderNo { get; set; }
            public DateTime OrderedDate { get; set; }
        }

        public async Task<string> GetRedisSalesOrderId()
        {
            var salesOrderId = await _redisDb.StringGetAsync("SalesOrderId");
            return salesOrderId;
        }
       
      
       
        public async Task<GetAllSalesOrderResponse> GetAllApprovedOrderItemsSummary(SalesOrderSearchCriteriaRequest request)
        {
            GetAllSalesOrderResponse response = new GetAllSalesOrderResponse();
            IQueryable<SalesOrder> salesOrderByCriteria = _context.SalesOrders
                .Include(so => so.OrderItems).ThenInclude(so => so.Unit)
                .Include(so => so.OrderItems).ThenInclude(so => so.Product).Include(so => so.Customer);
            IQueryable<Invoice> invoiceByCriteria = _context.Invoices;
            IQueryable<DispatcheOrder> dispatchByCriteria = _context.DispatchOrders;

            IQueryable<SalesOrder> salesOrderByDateRange = salesOrderByCriteria
                .Where(dt => dt.OrderedDate.Date >= request.DateFrom.Date && dt.OrderedDate.Date <= request.DateTo.Date.AddDays(1))
                .OrderByDescending(or => or.OrderedDate);
            IQueryable<Invoice> invoiceByDateRange = invoiceByCriteria
                .Where(dt => dt.CreatedDate.Date >= request.DateFrom.Date && dt.CreatedDate.Date <= request.DateTo.Date.AddDays(1))
                .OrderByDescending(or => or.CreatedDate);
            IQueryable<DispatcheOrder> dispatchByDateRange = dispatchByCriteria
               .Where(dt => dt.CreatedDate.Date >= request.DateFrom.Date && dt.CreatedDate.Date <= request.DateTo.Date.AddDays(1))
               .OrderByDescending(or => or.CreatedDate);

            var flattenedSalesOrders = await salesOrderByDateRange
                .Select(so => new
                {
                    salesOrderQuantity = so.OrderItems.Where(oi => oi.StatusId == 2 || oi.StatusId == 3).Sum(oi => oi.Quantity),
                    salesOrderAmount = so.OrderItems.Where(oi => oi.StatusId == 2 || oi.StatusId == 3).Sum(oi => oi.NetAmount),
                })
                .ToListAsync();

            var flattenedInvoices = await invoiceByDateRange
               .Select(so => new
               {
                   invoiceQuantity = so.InvoiceItems.Where(iv => iv.StatusId == 2 || iv.StatusId == 3).Sum(iv => iv.InvoiceQuantity),
                   invoiceAmount = so.InvoiceItems.Where(iv => iv.StatusId == 2 || iv.StatusId == 3).Sum(iv => iv.InvoiceAmount),
               })
               .ToListAsync();

            var flattenedDispatch = await dispatchByDateRange
               .Select(so => new
               {
                   dispatchQuantity = so.DispatchItems.Where(dp => dp.StatusId == 2 || dp.StatusId == 3).Sum(dp => dp.DispatchQuantity),
                   dispatchAmount = so.DispatchItems.Where(dp => dp.StatusId == 2 || dp.StatusId == 3).Sum(dp => dp.DispatchAmount),
               })
               .ToListAsync();

            // Calculating total quantity and total amount from the flattened query
            decimal totalSalesOrderQuantity = flattenedSalesOrders.Sum(so => so.salesOrderQuantity);
            decimal totalSalesOrderAmount = flattenedSalesOrders.Sum(so => so.salesOrderAmount);

            decimal totalInvoiceQuantity = flattenedInvoices.Sum(iv => iv.invoiceQuantity);
            decimal totalInvoiceAmount = flattenedInvoices.Sum(iv => iv.invoiceAmount);

            decimal totalDispatchQuantity = flattenedDispatch.Sum(dp => dp.dispatchQuantity);
            decimal totalDispatchAmount = flattenedDispatch.Sum(dp => dp.dispatchAmount);


            response.SalesOrders = salesOrderByDateRange.ConvertToSalesOrderViews(_mapper, 2, true);
            //response.TotalCount = totalCount;
            response.TotalSalesOrderQuantity = totalSalesOrderQuantity;
            response.TotalSalesOrderAmount = totalSalesOrderAmount;

            response.TotalInvoiceAmount = totalInvoiceAmount;
            response.TotalInvoiceQuantity = totalInvoiceQuantity;

            response.TotalDispatchAmount = totalDispatchAmount;
            response.TotalDispatchQuantity = totalDispatchQuantity;

            await _unitOfWork.SaveAsync();

            return response;
        }

        public Task<GetAllInvoiceResponse> GetAllUnApprovedInvoice(SalesOrderSearchCriteriaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllInvoiceResponse> GetAllApprovedInvoice(SalesOrderSearchCriteriaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllDeliveryOrderResponse> GetAllApproveDeliveryOrder(SalesOrderSearchCriteriaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllDeliveryOrderResponse> GetAllUnApproveDeliveryOrder(SalesOrderSearchCriteriaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetSalesOrderResponse> GetApprovedOrderItemDetailsAsync(int salesOrderId)
        {
            throw new NotImplementedException();
        }

        public Task<GetInvoiceResponse> GetApprovedInvoiceDetailsAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<CreateDispatchResponse> CreateCustomDispatchAsync(CreateDispatchRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetDeliveryOrderResponse> GetApprovedDeliveryOrderDetailsAsync(int deliveryOrderId)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllInvoiceResponse> ApprovalStatusInvoiceAsync(UpdateSalesOrderApprovalStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllDeliveryOrderResponse> ApprovalStatusDeliveryOrderAsync(UpdateSalesOrderApprovalStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GetSalesOrderResponse> GetSalesOrderById()
        {
            var salesOrderId = await _redisDb.StringGetAsync("SalesOrderId");
            GetSalesOrderResponse response = new GetSalesOrderResponse();
            if (!string.IsNullOrEmpty(salesOrderId) && int.TryParse(salesOrderId, out int orderId))
            {
                SalesOrder salesOrder = await _salesOrderRepository.GetSalesOrderByIncludeId(orderId);
                response.SalesOrder = salesOrder.ConvertToSalesOrderView(_mapper, 1, true);
            }
            return response;
        }

        public async Task<GetSalesOrderResponse> GetSalesOrderById(int salesOrderId)
        {

            GetSalesOrderResponse response = new GetSalesOrderResponse();
            SalesOrder salesOrder = await _salesOrderRepository.GetByIdAsync(salesOrderId);
            response.SalesOrder = salesOrder.ConvertToSalesOrderView(_mapper, 1, true);
            return response;
        }

        public Task<GetAllProductReponse> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<GetSalesOrderResponse> UpdateSalesOrder(UpdateSalesOrderRequest request)
        {
            throw new NotImplementedException();
        }



        public Task<GetAllSalesOrderResponse> UpdateInvoiceApprovalStatusAsync(UpdateSalesOrderApprovalStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllSalesOrderResponse> GetAllSalesOrdersBasket()
        {
            throw new NotImplementedException();
        }

        public Task<CreateDeliveryOrderResponse> CreateCustomDeliveryOrderAsync(CreateDeliveryOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task CreateBankAccount()
        {
            throw new NotImplementedException();
        }

        public async Task<GetSalesOrderResponse> DeleteOrderItemAsync(DeleteOrderItemRequest request)
        {
            var salesOrderId = await _redisDb.StringGetAsync("SalesOrderId");
            OrderItem orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId);
            GetSalesOrderResponse response = new GetSalesOrderResponse();
            if (!string.IsNullOrEmpty(salesOrderId) && int.TryParse(salesOrderId, out int orderId))
            {
                SalesOrder salesOrder = await _salesOrderRepository.GetSalesOrderByIncludeId(orderId);

                await _orderItemRepository.RemoveAsync(orderItem);
                await _unitOfWork.SaveAsync();
                response.SalesOrder = salesOrder.ConvertToSalesOrderView(_mapper, 1, true);
            }
            return response;

        }

        public async Task<GetSalesOrderResponse> DeleteSalesOrderAsync(DeleteOrderItemRequest request)
        {
            GetSalesOrderResponse response = new GetSalesOrderResponse();
            SalesOrder salesOrder = await _salesOrderRepository.GetByIdAsync(request.SalesOrderId);
            await _salesOrderRepository.RemoveAsync(salesOrder);
            await _redisDb.KeyDeleteAsync("SalesOrderId");
            await _unitOfWork.SaveAsync();

            response.SalesOrder = salesOrder.ConvertToSalesOrderView(_mapper, 1, true);
            return response;

        }



        public async Task DeleteSalesOrderAsync(int salesOrderId)
        {
            var salesOrder = await _salesOrderRepository.GetByIdAsync(salesOrderId);

            if (salesOrder == null)
                throw new KeyNotFoundException($"Sales order with ID {salesOrderId} not found.");

            await _salesOrderRepository.RemoveAsync(salesOrder);  // Avoid async here to prevent concurrent DbContext access
            await _unitOfWork.SaveAsync();
        }




        public Task<GetSalesOrderResponse> DeleteSalesOrderBasedOnOrderLimitAsync(DeleteOrderItemRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<SalesOrder> GetSalesOrderByOrderItemStatusAsync()
        {
            throw new NotImplementedException();
        }
 
    }
}







//var user = _httpContextAccessor.HttpContext.User;
//if (!user.Claims.Any(c => c.Type == "Permission" && c.Value == "ViewUnApproveSalesOrder"))
//{
//    throw new UnauthorizedAccessException("You have no permission to access Sales Order");
//}
// Call the base method with statusId = 1 for unapproved orders


//private void ValidateCreateSalesOrderRequest(CreateSalesOrderRequest request)
//{
//    if (request == null)
//    {
//        throw new ArgumentNullException(nameof(request), "The sales order request cannot be null.");
//    }

//    if (request.ProductId <= 0)
//    {
//        throw new ArgumentException("Product ID must be provided.");
//    }

//    if (request.CustomerId <= 0)
//    {
//        throw new ArgumentException("Customer ID must be provided.");
//    }

//    if (request.Quantity <= 0)
//    {
//        throw new ArgumentException("Quantity must be greater than 0.");
//    }

//    if (request.Price <= 0)
//    {
//        throw new ArgumentException("Price must be greater than 0.");
//    }

//    // Add other necessary input validations as needed
//}

//private async Task<Product> ValidateProductExists(int productId)
//{
//    var product = await _productRepository.GetByIdAsync(productId);
//    if (product == null)
//    {
//        throw new InvalidOperationException($"Product with ID {productId} does not exist.");
//    }
//    return product;
//}

//private async Task<Customer> ValidateCustomerExists(int customerId)
//{
//    var customer = await _customerRepository.GetByIdAsync(customerId);
//    if (customer == null)
//    {
//        throw new InvalidOperationException($"Customer with ID {customerId} does not exist.");
//    }
//    return customer;
//}

//private async Task<SalesOrderStatus> ValidateSalesOrderStatusExists(int salesOrderStatusId)
//{
//    var salesOrderStatus = await _salesOrderStatusRepository.GetByIdAsync(salesOrderStatusId);
//    if (salesOrderStatus == null)
//    {
//        throw new InvalidOperationException($"Sales order status with ID {salesOrderStatusId} does not exist.");
//    }
//    return salesOrderStatus;
//}

//private async Task<Unit> ValidateUnitExists(int unitId)
//{
//    var unit = await _unitRepository.GetByIdAsync(unitId);
//    if (unit == null)
//    {
//        throw new InvalidOperationException($"Unit with ID {unitId} does not exist.");
//    }
//    return unit;
//}
