using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class BillOfMaterialItem
    {
        public int Id { get; set; }
        public int BillOfMaterialsId { get; set; }
        public string MaterialName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public BillOfMaterial BillOfMaterial { get; set; }
    }
}
