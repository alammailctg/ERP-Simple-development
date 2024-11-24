using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class InventoryStockItem
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }
        public decimal StockQuantity { get; set; }

        //'Return', 'Sale', 'Wastage'
        public string TransferType { get; set; }
    }
}
