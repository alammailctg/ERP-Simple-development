using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class Shipping
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public DateTime ShippingDate { get; set; }
        
    }
}
