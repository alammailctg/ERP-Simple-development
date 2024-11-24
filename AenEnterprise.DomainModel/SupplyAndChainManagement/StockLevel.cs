using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class StockLevel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AvailableQuantity { get; set; }

        // Foreign Key for DemandPlanning
        public int DemandPlanningId { get; set; }
        public DemandPlanning DemandPlanning { get; set; }

        // One-to-Many Relationship: One StockLevel can trigger multiple ProductionPlans
        public List<ProductionPlanning> ProductionPlans { get; set; }
    }
}
