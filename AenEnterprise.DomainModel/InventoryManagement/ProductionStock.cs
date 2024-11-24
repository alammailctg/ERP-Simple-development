using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionStock
    {
        public ProductionStock()
        {
            ProductionStockItems = new List<ProductionStockItem>();
            CreatedDate = DateTime.Today;
        }
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public int ProductionOrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public DateTime StockDate { get; set; }
        public string StockLocation { get; set; }
         
        public List<ProductionStockItem> ProductionStockItems { get; set; }

        public void AddProductionStock(ProductionStockItem productionStockItem)
        {
            ProductionStockItems.Add(productionStockItem);
        }
    }
}
