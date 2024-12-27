using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure;
using AutoMapper;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.DataAccess;
using AenEnterprise.DataAccess.Criterias;

namespace AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation
{
    public class ApprovedSalesOrderService : IApprovedSalesOrderService
    {
        private readonly AenEnterpriseDbContext _context;
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly IMapper _mapper;
        public ApprovedSalesOrderService(ISalesOrderRepository salesOrderRepository, IMapper mapper)
        {
            _salesOrderRepository = salesOrderRepository;
            _context = new AenEnterpriseDbContext();
            _mapper = mapper;
        }

        public async Task<GetAllSalesOrderResponse> GetAllApprvedSalesOrders(SalesOrderCriteria request)
        {
            GetAllSalesOrderResponse response=new GetAllSalesOrderResponse();
            IQueryable<SalesOrder> query = await _salesOrderRepository.GetSalesOrderQuery(request, 2, true);
            
            int totalCount = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);
            int skipCount = (request.PageNumber - 1) * request.PageSize;
            
            IEnumerable<SalesOrder> salesOrders = await query
                .OrderByDescending(so => so.OrderedDate)
                .ThenByDescending(so => so.Id)
                .Skip(skipCount)
                .Take(request.PageSize)
                .ToListAsync();

            response = new GetAllSalesOrderResponse
            {
                SalesOrders = salesOrders.ConvertToSalesOrderViews(_mapper, 2, true),
                TotalPages = totalPages,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };
            return response;
        }
    }
}



//// This code is for reduce loading complexity

//string cacheKey = $"SalesOrders_{statusId}_{isPartial}_{request.PageNumber}_{request.PageSize}_{request.CriteriaName}_{request.DateFrom}_{request.DateTo}";

//// Check if the response is in Redis cache
//var cachedData = await _cache.GetStringAsync(cacheKey);
//if (!string.IsNullOrEmpty(cachedData))
//{
//    // Deserialize and return cached response
//    response = JsonConvert.DeserializeObject<GetAllSalesOrderResponse>(cachedData);
//    return response;
//}

//// Cache the response in Redis
//var cacheOptions = new DistributedCacheEntryOptions
//{
//    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Customize expiration
//};

//await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(response), cacheOptions);