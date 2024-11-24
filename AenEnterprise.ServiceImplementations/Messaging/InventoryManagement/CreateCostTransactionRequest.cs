using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.InventoryManagement
{
    public class CreateCostTransactionRequest
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public int ProductionOrderId { get; set; }
        public string Message { get; set; }
    }

}
