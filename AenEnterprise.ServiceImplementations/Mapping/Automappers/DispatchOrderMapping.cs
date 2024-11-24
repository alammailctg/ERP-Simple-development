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
    public static class DispatchOrderMapping
    {
        public static DispatcheOrderView ConvertToDispatchOrderView(this DispatcheOrder dispatcheOrder, IMapper mapper, int statusId, bool isActive)
        {
            // Map the DispatchOrder to DispatchOrderView
            var dispatchOrderView = mapper.Map<DispatcheOrder, DispatcheOrderView>(dispatcheOrder);

            // Filter DispatchItems based on statusId and isActive conditions
            dispatchOrderView.dispatchItems = dispatcheOrder.DispatchItems
                .Where(item => item.StatusId == statusId && item.IsActive == isActive)
            .Select(item => mapper.Map<DispatchItem, DispatchItemView>(item))
            .ToList();
            return dispatchOrderView;
        }

        public static IEnumerable<DispatcheOrderView> ConvertToDispatchOrderViews(this IEnumerable<DispatcheOrder> dispatcheOrders, IMapper mapper, int statusId, bool isActive)
        {
            // Map each DispatchOrder to DispatchOrderView with the filtered DispatchItems
            return dispatcheOrders.Select(dispatchOrder => dispatchOrder.ConvertToDispatchOrderView(mapper, statusId, isActive));
        }

    }
}
