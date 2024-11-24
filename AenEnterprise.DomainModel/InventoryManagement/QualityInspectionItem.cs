using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class QualityInspectionItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InspectionId { get; set; }
        public QualityInspection Inspection { get; set; }
        public string QualtityStatus { get; set; }
        public string Comments { get; set; }

    }
}
