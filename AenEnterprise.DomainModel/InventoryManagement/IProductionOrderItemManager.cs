using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public interface IProductionOrderItemManager
    {
        IEnumerable<ProductionOrderItem> GetProductionOrderItems();
        void AddProductionOrderItem(ProductionOrderItem item);
        bool AllItemsSubmitted();
        ProductionOrderItem GetProductionOrderItem(int orderItemId);
    }
}
