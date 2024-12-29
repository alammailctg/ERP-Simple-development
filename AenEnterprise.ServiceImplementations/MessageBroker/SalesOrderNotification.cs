using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class SalesOrderNotification
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderedDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
