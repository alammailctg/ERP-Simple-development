using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.InventoryVM
{
    public class ProductionOrderView
    {
        public int Id { get; set; }
        public string ProductionOrderNo { get; set; } = string.Empty;
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public DateTime LastDateOfUpdate { get; set; }
        public DateTime CreatedDate { get; set; }
       
        // List of production order items
        public IList<ProductionOrderItemView> ProductionOrderItems { get; set; } = new List<ProductionOrderItemView>();
    }
}
