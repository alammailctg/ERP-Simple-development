using AenEnterprise.DomainModel;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers
{

    public static class SalesOrderMapping
    {
        public static SalesOrderView ConvertToSalesOrderView(this SalesOrder salesOrder, IMapper mapper, int statusId, bool isActive)
        {
            // Map the SalesOrder to SalesOrderView
            var salesOrderView = mapper.Map<SalesOrder, SalesOrderView>(salesOrder);

            // Filter OrderItems based on statusId and isActive conditions
            salesOrderView.OrderItems = salesOrder.OrderItems
                .Where(item => item.StatusId == statusId && item.IsActive == isActive)
                .Select(item => mapper.Map<OrderItem, OrderItemView>(item))
                .ToList();

            return salesOrderView;
        }

        public static IEnumerable<SalesOrderView> ConvertToSalesOrderViews(this IEnumerable<SalesOrder> salesOrders, IMapper mapper, int statusId, bool isActive)
        {
            // Map each SalesOrder to SalesOrderView with the filtered OrderItems
            return salesOrders.Select(salesOrder => salesOrder.ConvertToSalesOrderView(mapper, statusId, isActive));
        }
    }


}


//public static class SalesOrderMapping
//{
//    public static SalesOrderView ConvertToSalesOrderView(this SalesOrder salesOrder, IMapper mapper)
//    {
//        return mapper.Map<SalesOrder, SalesOrderView>(salesOrder);
//    }

//    public static IEnumerable<SalesOrderView> ConvertToSalesOrderViews(this IEnumerable<SalesOrder> salesOrders, IMapper mapper)
//    {
//        return mapper.Map<IEnumerable<SalesOrder>, IEnumerable<SalesOrderView>>(salesOrders);
//    }



//}