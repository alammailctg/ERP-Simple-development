using AenEnterprise.DomainModel.CookieStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AutoMapper;
using AenEnterprise.ServiceImplementations.Messaging.ProcurementManagement;

using AenEnterprise.DomainModel.SupplyAndChainManagement;


namespace AenEnterprise.ServiceImplementations.Implementation.Inventories
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly ICookieImplementation _cookieImplementation;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseItemRepository _purchaseItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUnitRepository _unitRepository;
       



        public PurchaseOrderService(
            ICookieImplementation cookieImplementation,
            IMapper mapper,
            IProductRepository productRepository,
            IPurchaseOrderRepository purchaseOrderRepository,
            IPurchaseItemRepository purchaseItemRepository,
            IUnitOfWork unitOfWork,
            IUnitRepository unitRepository
          )
        {
            _cookieImplementation = cookieImplementation;
            _productRepository = productRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _purchaseItemRepository = purchaseItemRepository;
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<CreatePurchaseOrderResponse> CreatePurchaseOrderAsync(CreatePurchaseOrderRequest request)
        {
            CreatePurchaseOrderResponse response = new CreatePurchaseOrderResponse();
            Product product = await _productRepository.GetByIdAsync(request.ProductId);
            Unit unit = await _unitRepository.GetByIdAsync(request.UnitId);


            string purchaseOrderId = _cookieImplementation.Get(CookieDataKey.PurchaseOrderId.ToString());
            var purchaseOrders = await _purchaseOrderRepository.FindAllAsync();
            int lastPurchaseOrderId = purchaseOrders.Any() ? purchaseOrders.Last().Id : 0;


            if (purchaseOrderId != null && int.TryParse(purchaseOrderId, out int orderId))
            {
                PurchaseOrder purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(orderId);


                if (purchaseOrder != null)
                {
                    //if (await PurchaseItemExistsWithSameProduct(purchaseOrder, product, request.Price))
                    //{
                    //    throw new InvalidOperationException("Selected product already exists in the current purchase order.");
                    //}
                    //else
                    //{

                    //    purchaseOrder.CreatePurchaseItem(product, request.Quantity, unit, request.Price);
                    //    await _purchaseOrderRepository.UpdateAsync(purchaseOrder); // Update the existing Supplier
                    //}
                    response.PurchaseOrder = purchaseOrder.ConvertToPurchaseOrderView(_mapper);
                }
            }
            else
            {

                PurchaseOrder newPurchaseOrder = new PurchaseOrder
                {
                    PurchaseDate = request.PurchaseDate,
                    PurchaseOrderNo = lastPurchaseOrderId > 0 ? "PO-" + (lastPurchaseOrderId + 1).ToString() : "PO-1"
                };


                newPurchaseOrder.CreatePurchaseItem(product, request.Quantity, unit, request.Price);
                await _purchaseOrderRepository.AddAsync(newPurchaseOrder);

                response.PurchaseOrder = newPurchaseOrder.ConvertToPurchaseOrderView(_mapper);


                _cookieImplementation.Set(CookieDataKey.PurchaseOrderId.ToString(), response.PurchaseOrder.Id.ToString(), 1,true,false);
            }

            await _unitOfWork.SaveAsync(); // Commit changes to the database
            return response;
        }

        public Task<bool> PurchaseItemExistsWithSameProduct(PurchaseOrder purchaseOrder, Product product, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}















//public async Task<CreatePurchaseOrderResponse> CreatePurchaseOrderAsync(CreatePurchaseOrderRequest request)
//{
//    CreatePurchaseOrderResponse response = new CreatePurchaseOrderResponse();
//    Product product = await _productRepository.GetByIdAsync(request.ProductId);
//    Unit unit = await _unitRepository.GetByIdAsync(request.UnitId);
//    string purchaseOrderId = _cookieImplementation.Get(CookieDataKey.PurchaseOrderId.ToString());
//    var purchaseOrders = await _purchaseOrderRepository.FindAllAsync();
//    int LastPurchaseOrderId = purchaseOrders.Any() ? purchaseOrders.Last().Id : 0;

//    if (purchaseOrderId != null && int.TryParse(purchaseOrderId, out int orderId))
//    {
//        Supplier purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(orderId);
//        if (purchaseOrder != null)
//        {
//            if (await PurchaseItemExistsWithSameProduct(purchaseOrder, product, request.Price))
//            {
//                throw new InvalidOperationException("Selected product already exists in current purchase Order");
//            }
//            else
//            {
//                purchaseOrder.CreatePurchaseItem(product,request.Quantity,unit,request.Price,request.DiscountAmount,request.DiscountPercent,request.TotalCost);
//                await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
//            }
//            response.Supplier = purchaseOrder.ConvertToPurchaseOrderView(_mapper);
//        }
//    }

//    else
//    {
//        Supplier newPurchaseOrder = new Supplier();
//        newPurchaseOrder.PurchaseDate = request.PurchaseDate;
//        newPurchaseOrder.PurchaseOrderNo = request.PurchaseOrderNo;
//        newPurchaseOrder.SupplierId = request.SupplierId;
//        if (LastPurchaseOrderId > 0)
//        {
//            newPurchaseOrder.PurchaseOrderNo = "PO-" + (LastPurchaseOrderId + 1).ToString();
//        }
//        else
//        {
//            newPurchaseOrder.PurchaseOrderNo = "PO-" + 1.ToString();
//        }
//        await _purchaseOrderRepository.AddAsync(newPurchaseOrder);

//        newPurchaseOrder.CreatePurchaseItem(product,request.Quantity,unit, request.Price, request.DiscountAmount, request.DiscountPercent, request.TotalCost);

//        response.Supplier = newPurchaseOrder.ConvertToPurchaseOrderView(_mapper);
//        _cookieImplementation.Set(CookieDataKey.PurchaseOrderId.ToString(), response.Supplier.Id.ToString(), 1);
//    }

//    return response;


//}


