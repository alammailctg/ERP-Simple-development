using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.InventoryManagement
{
    public class CreateProductionOrderRequest
    {
        public int ProductId { get; set; }
        public decimal QuantityRequested { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public int AssignedToId { get; set; }
        public int InitiatorId { get; set; }
        public string Remarks { get; set; }
        public int OrderPriorityId { get; set; }
        public decimal InitialProductionCost { get; set; }
        public int BranchId { get; set; }
        public decimal QuantityProduced { get; set; }
        public string ProductionOrderNo { get; set; }
        public int UnitId { get; set; }

    }

}
