using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionOrderItemManager:IProductionOrderItemManager
    {
        private readonly IList<ProductionOrderItem> _productionOrderItems = new List<ProductionOrderItem>();

        public IEnumerable<ProductionOrderItem> GetProductionOrderItems() => _productionOrderItems.AsReadOnly();
        public void AddProductionOrderItem(ProductionOrderItem item) => _productionOrderItems.Add(item);
        public bool AllItemsSubmitted() => _productionOrderItems.All(item => item.IsSubmitted);
        public ProductionOrderItem GetProductionOrderItem(int orderItemId) => _productionOrderItems.FirstOrDefault(item => item.ProductionOrderId == orderItemId);
    }
}
