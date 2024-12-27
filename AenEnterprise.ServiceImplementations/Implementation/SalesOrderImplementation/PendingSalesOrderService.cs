using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement.SalesOrderMessaging;
using AenEnterprise.ServiceImplementations.Messaging.SalesManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using AenEnterprise.ServiceImplementations.Interface;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess.Criterias;
using AutoMapper;
using AenEnterprise.DataAccess.Repository;

namespace AenEnterprise.ServiceImplementations.Implementation.SalesOrderImplementation
{
    public class PendingSalesOrderService:IPendingSalesOrderService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        public PendingSalesOrderService(ISalesOrderRepository salesOrderRepository, IMapper mapper, IOrderItemRepository orderItemRepository, IUnitOfWork uow)
        {
            _salesOrderRepository = salesOrderRepository;
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
            _uow = uow;
        }
        public async Task<GetAllSalesOrderResponse> GetAllUnApprovedOrderItems(SalesOrderCriteria request)
        {
            GetAllSalesOrderResponse response = new GetAllSalesOrderResponse();
            IQueryable<SalesOrder> query = await _salesOrderRepository.GetSalesOrderQuery(request, 1, false);

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
                SalesOrders = salesOrders.ConvertToSalesOrderViews(_mapper, 1, true),
                TotalPages = totalPages,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };
            return response;
        }

        public async Task<GetAllSalesOrderResponse> ApprovalActionAsync (UpdateSalesOrderApprovalStatusRequest request)
        {
            GetAllSalesOrderResponse response = new GetAllSalesOrderResponse();
            IEnumerable<SalesOrder> salesOrders = await _salesOrderRepository.FindAllAsync();
            SalesOrder salesOrder = await _salesOrderRepository.GetByIdAsync(request.SalesOrderId);
            var orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId); // Assuming there's a method GetByIdAsync for order items

            if (salesOrder != null && orderItem != null)
            {
                orderItem.IsFullyApproved = false;
                orderItem.IsPartiallyApproved = true;
                orderItem.StatusId = request.StatusId;
                await _orderItemRepository.UpdateAsync(orderItem);
                await _salesOrderRepository.UpdateAsync(salesOrder);
                await _uow.SaveAsync();
                response.SalesOrders = salesOrders.ConvertToSalesOrderViews(_mapper, 2, true);
                return response;
            }
             
            return response;
        }
      
        
    }
}
