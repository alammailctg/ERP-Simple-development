namespace AenEnterprise.FrontEndMvc.Models.ProductionOrder
{
    public class CreateProductionOrderFormWithOrderItemRequest
    {
        public CreateProductionOrderFormRequest OrderFormRequest { get; set; }
        public List<CreateProductionOrderItemFormRequest> ItemFormRequests { get; set; }
    }
}
