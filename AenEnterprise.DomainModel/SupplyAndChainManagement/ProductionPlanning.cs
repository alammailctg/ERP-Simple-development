using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class ProductionPlanning
    {
        public int Id { get; set; }
        public DateTime PlannedDate { get; set; }
        public int PlannedProductionQuantity { get; set; }

        // Foreign Key for StockLevel
        public int StockLevelId { get; set; }
        public StockLevel StockLevel { get; set; }

        // One-to-Many Relationship: One ProductionPlanning can generate multiple MaterialRequirements
        public List<MaterialsRequirement> MaterialsRequirements { get; set; }
    }
}
