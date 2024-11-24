using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class DuplicateProductionItemValidate : IProductionOrderItemValidator
    {
        public void Validate(IEnumerable<ProductionOrderItem> existingItems, ProductionOrderItem itemToAdd, ProductionOrder productionOrder)
        {
            if (existingItems.Any(item =>
             item.ProductionOrderId == productionOrder.Id && item.ProductId == itemToAdd.ProductId))
            {
                throw new InvalidOperationException("Duplicate production order item is not allowed.");
            }
        }
    }
}
