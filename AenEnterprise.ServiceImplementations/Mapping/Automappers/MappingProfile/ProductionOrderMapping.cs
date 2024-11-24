using AenEnterprise.DomainModel.InventoryManagement;
using AenEnterprise.ServiceImplementations.ViewModel.InventoryVM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Mapping.Automappers.MappingProfile
{
    public static class ProductionOrderMapping
    {
        public static ProductionOrderView ConvertToProductionOrderView(this ProductionOrder productionOrder, IMapper mapper, int statusId, bool isActive)
        {
            // Map the ProductionOrder to ProductionOrderView
            var productionOrderView = mapper.Map<ProductionOrder, ProductionOrderView>(productionOrder);

            // Filter ProductionOrderItems based on statusId and isActive conditions
            productionOrderView.ProductionOrderItems = productionOrder.ProductionOrderItems
                .Where(item => item.ApprovalStatusId == statusId && item.IsActive == isActive)
                .Select(item => mapper.Map<ProductionOrderItem, ProductionOrderItemView>(item))
                .ToList();

            return productionOrderView;
        }

        public static IEnumerable<ProductionOrderView> ConvertToProductionOrderViews(this IEnumerable<ProductionOrder> productionOrders, IMapper mapper, int statusId, bool isActive)
        {
            // Map each ProductionOrder to ProductionOrderView with the filtered OrderItems
            return productionOrders.Select(productionOrder => productionOrder.ConvertToProductionOrderView(mapper, statusId, isActive));
        }
    }

}
