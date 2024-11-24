using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace AenEnterprise.FrontEndMvc.Models.ProductionOrder
{
    public class CreateProductionOrderItemFormRequest
    {
        public int ProductId { get; set; }
        public decimal QuantityRequested { get; set; }
        public decimal QuantityProduced { get; set; }
        public int UnitId { get; set; }

    }
}
