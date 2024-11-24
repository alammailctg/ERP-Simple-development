using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionStockItem
    {

        public ProductionStockItem()
        {
            CreatedDate = DateTime.Today;
        }
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        
        public string QualityStatus { get; set; }
        public string Production { get; set; }
        public int ProductId { get; set; }
        public decimal QuantityInProduced { get; set; }
        public decimal QuantityInStock { get; set; }
        public int StockType { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int ProductionStockId { get; set; }
        public ProductionStock ProductionStock { get; set; }
    }
}
