using AenEnterprise.DomainModel.InventoryManagement;
using AenEnterprise.ServiceImplementations.ViewModel.InventoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.InventoryManagement
{
    public class GetAllProductionOrder
    {
        public IEnumerable<ProductionOrderView> ProductionOrders { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalProductionOrderQuantity { get; set; }
        public decimal TotalProductionOrderAmount { get; set; }
    }
}
