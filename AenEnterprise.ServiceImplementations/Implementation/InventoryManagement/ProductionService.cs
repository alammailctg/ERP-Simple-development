using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.InventoryManagement;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.ServiceImplementations.Messaging.InventoryManagement;
using AenEnterprise.ServiceImplementations.ViewModel.InventoryVM;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AutoMapper;
using AenEnterprise.ServiceImplementations.Interface;
using System.Transactions;
using Microsoft.AspNetCore.Http.HttpResults;
using AenEnterprise.DataAccess.Repository;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.EntityFrameworkCore;
using AenEnterprise.DataAccess;
using static Vonage.ProactiveConnect.Lists.SyncStatus;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.MappingProfile;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

namespace AenEnterprise.ServiceImplementations.Implementation.InventoryManagement
{
    public class ProductionOrderService:IProductionOrderService
    {
        private AenEnterpriseDbContext _context;
        private readonly IProductionOrderRepository _productionOrderRepository;
        private readonly ICostTransactionRepository _costTransactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductionOrderItemValidator _productionOrderItemValidator;
        private readonly IDatabase _redisDb;
        private readonly RedisConnection _redisConnection;
        private readonly ILogger<ProductionOrderService> _logger;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public ProductionOrderService(
            IProductionOrderRepository productionOrderRepository,
            IProductRepository productRepository,
            ILogger<ProductionOrderService> logger,
            RedisConnection redisConnection,
        IMapper mapper, IUnitOfWork unitOfWork, 
        ICostTransactionRepository costTransactionRepository, 
        IProductionOrderItemValidator productionOrderItemValidator)
        {
            // Dependency Injection ensures the class only depends on interfaces
            _productionOrderRepository = productionOrderRepository;
            _productRepository = productRepository;
            _redisDb = redisConnection.GetDatabase();
            _logger = logger;
            _redisConnection = redisConnection;
            _mapper = mapper;
            _context = new AenEnterpriseDbContext();
            _unitOfWork = unitOfWork;
            _costTransactionRepository = costTransactionRepository;
            _productionOrderItemValidator = productionOrderItemValidator;
        }

        public async Task<GetProductionOrderResponse> CreateProductionOrderAsync(CreateProductionOrderRequest request)
        {
            var productionOrderId = await _redisDb.StringGetAsync("ProductionOrderId");
            
            Product product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {request.ProductId} not found.");
            }
            GetProductionOrderResponse response = new GetProductionOrderResponse();
            if (productionOrderId.HasValue && int.TryParse(productionOrderId, out int orderId))
            {
                ProductionOrder existingOrder = await _productionOrderRepository.GetByIdAsync(orderId);

                if (existingOrder == null)
                {
                    throw new InvalidOperationException($"Production order with ID {orderId} not found.");
                }

                existingOrder.AddProductOrderItem(product.Id, request.QuantityRequested, request.QuantityProduced, request.UnitId);
                existingOrder.SetItemValidator(_productionOrderItemValidator);
                await _productionOrderRepository.UpdateAsync(existingOrder);
                response.ProductionOrder = existingOrder.ConvertToView<ProductionOrder, ProductionOrderView>(_mapper);
            }
            else
            {
                // Create a new order and pass required dependencies
                ProductionOrder newProductionOrder = new ProductionOrder()
                {
                    ProductionStartDate = request.ProductionStartDate,
                    ProductionEndDate = request.ProductionEndDate,
                    LastDateOfUpdate = DateTime.Now,
                    ProductionOrderNo = request.ProductionOrderNo,
                    InitiatorId = request.InitiatorId,
                    AssignedToId = request.AssignedToId,
                    OrderPriorityId = request.OrderPriorityId,
                    Remarks = request.Remarks,
                    PurchaseCost = 10,
                    DirectLaborCost=20,
                    OtherInitialCosts=30,
                    BranchId=request.BranchId,
                    ResourceId=1,
                    InitialProductCost = request.InitialProductionCost,
                };

                newProductionOrder.AddProductOrderItem(product.Id, request.QuantityRequested, request.QuantityProduced,request.UnitId);
                newProductionOrder.SetItemValidator(_productionOrderItemValidator);
                await _productionOrderRepository.AddAsync(newProductionOrder);

                response.ProductionOrder = newProductionOrder.ConvertToView<ProductionOrder, ProductionOrderView>(_mapper);
                await _redisDb.StringSetAsync("ProductionOrderId", newProductionOrder.Id.ToString(), TimeSpan.FromMinutes(5));
            }

            return response;
        }
        private decimal CalculateInitialCost(decimal quantityRequested, decimal productCost)
        {
            return quantityRequested * productCost; // Example: Initial cost is quantity times product cost
        }
        //private string GenerateProductionOrderNo()
        //{
        //    // Example: Generate based on current time and a random number
        //    string productionOrderNo = $"PO-{DateTime.Now:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
        //    _logger.LogInformation("Generated unique production order number: {ProductionOrderNo}", productionOrderNo);
        //    return productionOrderNo;
        //}

        public async Task<GetAllProductionOrder> GetAllProductionOrderAsync(ProductionOrderCriteria Criteria)
        {
            GetAllProductionOrder response = new GetAllProductionOrder();
            IQueryable<ProductionOrder> query = _context.ProductionOrders
                .Include(po => po.ProductionOrderItems)
                .ThenInclude(po => po.Product)
                .Include(po => po.CostTransactions)
                .Include(po => po.ProductionOrderItems)
                .ThenInclude(po => po.Unit)
                .Where(po => po.ProductionOrderItems != null && 
                po.ProductionOrderItems.Count() > 0 && 
                po.ProductionOrderItems.Any(oi => oi.ApprovalStatusId == Criteria.StatusId));

            // Convert string CriteriaName to dateTime
            DateTime parsedDate;
            bool isDate = DateTime.TryParse(Criteria.CriteriaName, out parsedDate);

            // Apply optional filtering based on CriteriaName
            if (!string.IsNullOrEmpty(Criteria.CriteriaName))
            {
                query = query.Where(e =>
                    EF.Functions.Like(e.ProductionOrderNo, $"%{Criteria.CriteriaName}%") ||
                    (isDate && e.ProductionStartDate.Date==parsedDate) ||
                    e.ProductionOrderItems.Any(oi =>
                        EF.Functions.Like(oi.Product.Name, $"%{Criteria.CriteriaName}%") ||
                        EF.Functions.Like(oi.Unit.Name, $"%{Criteria.CriteriaName}%"))
               );
            }

            // Apply date range filtering if both dates are provided
            if (Criteria.ProductionStartDate != null && Criteria.ProductionEndDate != null)
            {
                query = query.Where(po => po.ProductionStartDate.Date >=Criteria.ProductionEndDate.Date &&
                                           po.ProductionStartDate.Date <= Criteria.ProductionEndDate.Date.AddDays(1));
            }

            // Get total count of filtered records
            int totalCount = await query.CountAsync();

            // Pagination setup
            int totalPages = (int)Math.Ceiling((double)totalCount / Criteria.PageSize);
            int skipCount = (Criteria.PageNumber - 1) * Criteria.PageSize;

            // Apply pagination and sort
            IEnumerable<ProductionOrder> productionOrders = await query
                .OrderByDescending(po => po.CreatedDate).OrderByDescending(po => po.Id)
                .ThenByDescending(po => po.Id)
                .Skip(skipCount)
                .Take(Criteria.PageSize)
                .ToListAsync();

            // Convert to view model
            response.ProductionOrders =productionOrders.ConvertToProductionOrderViews(_mapper, Criteria.StatusId, true);
            response.TotalPages = totalPages;
            response.PageNumber =Criteria.PageNumber;
            response.PageSize = Criteria.PageSize;
            response.TotalCount = totalCount;

            // Save changes (if necessary)
            await  _unitOfWork.SaveAsync();

            return response;
        }

        public async Task<CreateCostTransactionResponse> CreateCostTransaction(CreateCostTransactionRequest request)
        {
            _logger.LogInformation("Starting cost transaction creation...");
            CreateCostTransactionResponse response = new CreateCostTransactionResponse();
            var productionOrder = await _productionOrderRepository.GetByIdAsync(request.ProductionOrderId);
            if (productionOrder == null)
            {
                _logger.LogWarning($"Production Order with ID {request.ProductionOrderId} not found.");
                throw new ArgumentException($"Production Order with ID {request.ProductionOrderId} does not exist.");
            }
            
            CostTransaction costTransaction =new CostTransaction
            {
                TransactionDate = request.TransactionDate,
                Amount = request.Amount,
                TransactionType = request.TransactionType,
                ProductionOrderId =request.ProductionOrderId,
            };
            var CostTransactionView = costTransaction.ConvertToView<CostTransaction, CostTransactionView>(_mapper);
            await _costTransactionRepository.AddAsync(costTransaction);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Cost transaction with ID {costTransaction.Id} created successfully.");
            
            return response;
        }

    }





}
