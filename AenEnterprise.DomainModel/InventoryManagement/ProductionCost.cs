using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ProductionCost
    {
        public int Id { get; set; }
        public int ProductionOrderId { get; set; }
        public string CostType { get; set; } // e.g., Labor, Material, Overhead
        public decimal CostAmount { get; set; }
        // Navigation property
        public ProductionOrder ProductionOrder { get; set; }
    }
}
