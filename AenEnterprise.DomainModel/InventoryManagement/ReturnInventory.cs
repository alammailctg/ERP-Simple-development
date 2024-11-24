using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class ReturnInventory
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ReturnDate { get; set; }
        public string ReturnReason { get; set; }
    }
}
