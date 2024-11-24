using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.InventoryManagement
{
    public class CostTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } 
        public int ProductionOrderId { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
    }
}
