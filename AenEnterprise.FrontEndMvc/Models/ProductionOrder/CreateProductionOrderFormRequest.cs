namespace AenEnterprise.FrontEndMvc.Models.ProductionOrder
{
    public class CreateProductionOrderFormRequest
    {
        public string ProductionOrderNo { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public int AssignedToId { get; set; }
        public int InitiatorId { get; set; }
        public string Remarks { get; set; }
        public int OrderPriorityId { get; set; }
        public decimal InitialProductionCost { get; set; }
        public int BranchId { get; set; }
    }
}
