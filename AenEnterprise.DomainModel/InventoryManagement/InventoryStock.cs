using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class InventoryStock
    {
      
        public InventoryStock()
        {
            CreatedDate = DateTime.Today;
        }
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string InventoryStockNo { get; set; }
        public DateTime StockDate { get; set; }
        public int InventoryTransferId { get; set; }
        public InventoryTransfer InventTransfer { get; set; }
        public List<InventoryStockItem> InventoryStockItems { get; set; }

    }
}
