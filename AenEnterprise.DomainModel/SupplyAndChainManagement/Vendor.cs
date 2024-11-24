using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        // One Vendor has many PurchaseOrders
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }

}
