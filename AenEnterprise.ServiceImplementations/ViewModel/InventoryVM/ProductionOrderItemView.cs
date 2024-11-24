using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.InventoryVM
{
    public class ProductionOrderItemView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal QuantityRequested { get; set; }
        public decimal QuantityProduced { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
