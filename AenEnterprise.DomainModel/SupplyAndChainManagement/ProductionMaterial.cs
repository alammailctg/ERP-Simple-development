using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class ProductionMaterial
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public decimal UnitCost { get; set; }
        public decimal QuantityUsed { get; set; }
        public decimal CostAmount { get; set; }
    }
}
