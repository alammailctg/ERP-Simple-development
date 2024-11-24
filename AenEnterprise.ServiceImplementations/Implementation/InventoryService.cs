using AenEnterprise.DataAccess.Repository;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.CookieStorage;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.ServiceImplementations.Mapping;
using AenEnterprise.ServiceImplementations.Messaging.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation
{
    public class InventoryService:IInventoryService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;
        private ICookieImplementation _cookieImplementation;
        public InventoryService(IProductRepository productRepository,
            IUnitRepository unitRepository,
            IUnitOfWork unitOfWork,
            ICookieImplementation cookieImplementation)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _unitRepository = unitRepository;
            _cookieImplementation = cookieImplementation;

        }

        public async Task<GetAllProductReponse> GetAllProducts()
        {
            GetAllProductReponse response=new GetAllProductReponse();
            IEnumerable<Product> products =await _productRepository.FindAllAsync();
            response.Products = products.ConvertToProductViews();
            return response;
        }

        public async Task<GetAllUnitResponse> GetAllUnits()
        {
            GetAllUnitResponse response=new GetAllUnitResponse();
            IEnumerable<Unit> units =await _unitRepository.FindAllAsync();
            response.Units = units.ConvertToUnitViews();
            return response;
        }
    }
}
