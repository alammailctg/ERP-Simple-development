using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public static class ProductionOrderFactory
    {
        public static ProductionOrderItem CreateNewProductOrderItem(ProductionOrder productionOrder, int productId, decimal quantityRequested, decimal quantityProduce, int unitId)
        {
            return new ProductionOrderItem(productionOrder, productId, quantityRequested, quantityProduce,unitId);
        }
    }
}
