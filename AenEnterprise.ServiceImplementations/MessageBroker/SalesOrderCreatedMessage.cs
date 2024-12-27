using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class SalesOrderCreatedMessage
    {
        public int SalesOrderId { get; set; }
        public string CustomerName { get; set; }
        public string OrderedDate { get; set; }
        public string SalesOrderNo { get; set; }
    }
}
