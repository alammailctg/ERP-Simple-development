using AenEnterprise.DomainModel.SupplyAndChainManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class Defective
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public string? ActionTaken { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public int InspectionId { get; set; }
        public QualityInspection? Inspection { get; set; }
    }
}
