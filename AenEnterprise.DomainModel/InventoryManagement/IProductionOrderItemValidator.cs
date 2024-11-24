using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    //Strategy Interface to validate
    public interface IProductionOrderItemValidator
    {
        void Validate(IEnumerable<ProductionOrderItem> existingItems, ProductionOrderItem itemToAdd, ProductionOrder productionOrder);
    }
}
