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
    public static class DeliveryOrderMapping
    {
        public static DeliveryOrderView ConvertToDeliveryOrderView(this DeliveryOrder deliveryOrder, IMapper mapper, int statusId, bool isActive)
        {
            // Map the DeliveryOrder to DeliveryOrderView
            var deliveryOrderView = mapper.Map<DeliveryOrder, DeliveryOrderView>(deliveryOrder);

            // Filter DeliveryOrderItems based on statusId and isActive conditions
            deliveryOrderView.DeliveryOrderItems = deliveryOrder.DeliveryOrderItems
                .Where(item => item.StatusId == statusId && item.IsActive == isActive)
                .Select(item => mapper.Map<DeliveryOrderItem, DeliveryOrderItemView>(item))
                .ToList();

            return deliveryOrderView;
        }

        public static IEnumerable<DeliveryOrderView> ConvertToDeliveryOrderViews(this IEnumerable<DeliveryOrder> deliveryOrders, IMapper mapper, int statusId, bool isActive)
        {
            // Map each DeliveryOrder to DeliveryOrderView with the filtered DeliveryOrderItems
            return deliveryOrders.Select(deliveryOrder => deliveryOrder.ConvertToDeliveryOrderView(mapper, statusId, isActive));
        }

    }
}
