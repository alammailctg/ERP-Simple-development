namespace AenEnterprise.FrontEndMvc.Models.SalesOrder
{
    public class CreateSalesOrderFormWithOrderItemsRequest
    {
        public class CreateSalesOrderFormWithItemsRequest
        {
            public CreateSalesOrderFormRequest FormRequest { get; set; }
            public List<CreateOrderItemsRequest> OrderItemsRequests { get; set; }
        }

    }
}
