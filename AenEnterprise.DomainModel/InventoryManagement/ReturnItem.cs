using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ReturnItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal ReturnedQuantity { get; set; }
    }
}
