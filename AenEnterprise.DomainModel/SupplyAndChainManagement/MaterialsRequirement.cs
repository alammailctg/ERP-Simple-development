using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class MaterialsRequirement
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int RequiredQuantity { get; set; }

        // Foreign Key for ProductionPlanning
        public int ProductionPlanningId { get; set; }
        public ProductionPlanning ProductionPlanning { get; set; }
    }

}
