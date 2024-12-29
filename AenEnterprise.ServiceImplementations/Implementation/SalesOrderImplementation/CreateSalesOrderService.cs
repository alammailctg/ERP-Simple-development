using AenEnterprise.DataAccess;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.CookieStorage;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using System.Text.Json;
using AenEnterprise.ServiceImplementations.MessageBroker;

namespace AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation
{
    public class CreateSalesOrderService:ICreateSalesOrderService
    {
        private AenEnterpriseDbContext _context;
        private ISalesOrderRepository _salesOrderRepository;
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;
        private ISalesOrderStatusRepository _salesOrderStatusRepository;
        private IUnitRepository _unitRepository;
        private IOrderItemRepository _orderItemRepository;
        private readonly HttpRequest _request;
        private ICustomerRepository _customerRepository;
        private ICookieImplementation _cookieImplementation;
        private IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly IDatabase _redisDb;
        private readonly RedisConnection _redisConnection;
        private readonly ILogger<SalesOrderService> _logger;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMessagePublish _messagePublish;

        public CreateSalesOrderService(ISalesOrderRepository salesOrderRepository,
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
        IMapper mapper,
        RedisConnection redisConnection,
        ILogger<SalesOrderService> logger,
        IDistributedCache cache, IHubContext<NotificationHub> notificationHubContext, IMessagePublish messagePublish)
        {
            _context = new AenEnterpriseDbContext();
            _orderItemRepository = orderItemRepository;
            _salesOrderStatusRepository = salesOrderStatusRepository;
            _unitRepository = unitRepository;
            _salesOrderRepository = salesOrderRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _cookieImplementation = cookieImplementation;
            _request = httpContextAccessor.HttpContext.Request;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _redisDb = redisConnection.GetDatabase();
            _redisConnection = redisConnection;
            _logger = logger;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _notificationHubContext = notificationHubContext;
            _messagePublish = messagePublish;
        }
        public async Task<GetSalesOrderResponse> CreateSalesOrderAsync(CreateSalesOrderRequest request)
        {
            var salesOrderId = await _redisDb.StringGetAsync("SalesOrderId");
            Product product = await _productRepository.GetByIdAsync(request.ProductId);
            Customer customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            SalesOrderStatus salesOrderStatus = await _salesOrderStatusRepository.GetByIdAsync(request.SalesOrderStatusId);
            Unit unit = await _unitRepository.GetByIdAsync(request.UnitId);
            var salesOrders = await _salesOrderRepository.FindAllAsync();
            GetSalesOrderResponse response = new GetSalesOrderResponse();
            int lastOrderId = salesOrders.Any() ? salesOrders.Last().Id : 0;
            SalesOrder newSalesOrder = new SalesOrder();

            if (salesOrderId.HasValue && int.TryParse(salesOrderId, out int orderId))
            {
                SalesOrder salesOrder = await _salesOrderRepository.GetSalesOrderByIncludeId(orderId);
                if (salesOrder == null)
                {
                    throw new InvalidOperationException($"Sales order with ID {orderId} not found.");
                }

                if (await OrderItemExistsWithSameProduct(salesOrder, product, request.Price))
                {
                    throw new InvalidOperationException("Selected product already exists in the current order.");
                }
                else
                {
                    salesOrder.CreateOrderItem(request.ProductId, request.UnitId, request.Quantity, request.Price, request.DiscountPercent, 1, true);
                }
                await _salesOrderRepository.UpdateAsync(salesOrder);
                response.SalesOrder = salesOrder.ConvertToSalesOrderView(_mapper, 1, true);
            }
            else
            {
                newSalesOrder.OrderedDate = request.OrderedDate;
                newSalesOrder.CreatedDate = DateTime.Now;
                newSalesOrder.CustomerId = customer.Id;
                newSalesOrder.Description = request.Description;
                newSalesOrder.SalesOrderStatusId = 1; // Default status
                newSalesOrder.DeliveryPlane = request.DeliveryPlane;
                newSalesOrder.CreateOrderItem(product.Id, unit.Id, request.Quantity, request.Price, request.DiscountPercent, 1, true);
                newSalesOrder.SalesOrderNo = lastOrderId > 0 ? "SO-" + (lastOrderId + 1).ToString() : "SO-1";
                await _salesOrderRepository.AddAsync(newSalesOrder);
                response.SalesOrder = newSalesOrder.ConvertToSalesOrderView(_mapper, 1, true);

                // Publish the sales order creation message to RabbitMQ
                await _messagePublish.PublishSalesOrderCreatedMessage(newSalesOrder);

                await _redisDb.StringSetAsync("SalesOrderId", response.SalesOrder.Id.ToString(), TimeSpan.FromMinutes(5));
            }
            return response;
        }

        public async Task<bool> OrderItemExistsWithSameProduct(SalesOrder salesOrder, Product product, decimal price)
        {
            var orderItems = await _orderItemRepository.FindAsync(i => i.SalesOrderId == salesOrder.Id &&
            i.Product == product && i.Price == price);

            // Check if any order item with the same product exists in the sales order
            return orderItems.Any();
        }
        public async Task AddSalesOrdersAsync()
        {
            var salesOrderId = await _redisDb.StringGetAsync("SalesOrderId");
            if (!salesOrderId.IsNullOrEmpty && int.TryParse(salesOrderId, out int orderId))
            {
                SalesOrder salesOrder = await _salesOrderRepository.GetByIdAsync(orderId);
                if (salesOrder != null)
                {
                    salesOrder.SalesOrderStatusId = 2;
                    await _salesOrderRepository.UpdateAsync(salesOrder);
                    await _unitOfWork.SaveAsync();
                    await _redisDb.KeyDeleteAsync("SalesOrderId");
                }
            }
        }

        public async Task DeleteSalesOrderAndOrderItemAsync()
        {
            var salesOrderId = await _redisDb.StringGetAsync("SalesOrderId");
            if (!salesOrderId.IsNullOrEmpty && int.TryParse(salesOrderId, out int orderId))
            {
                var salesOrderIdsWithStatus1 = await _context.SalesOrders
               .Where(so => so.OrderItems.Any(oi => oi.StatusId == 1 && oi.SalesOrderId == orderId))
               .Select(so => so.Id)
               .ToListAsync();

                if (salesOrderIdsWithStatus1.Count.Equals(1))
                {
                    SalesOrder salesOrder = await _salesOrderRepository.GetByIdAsync(orderId);
                    if (salesOrder != null)
                    {
                        foreach (var orderItem in salesOrder.OrderItems.ToList())
                        {
                            await _orderItemRepository.RemoveAsync(orderItem);
                        }
                        await _salesOrderRepository.RemoveAsync(salesOrder);
                        await _unitOfWork.SaveAsync();
                        await _redisDb.KeyDeleteAsync("SalesOrderId");
                    }
                }
            }

        }
    }
}
