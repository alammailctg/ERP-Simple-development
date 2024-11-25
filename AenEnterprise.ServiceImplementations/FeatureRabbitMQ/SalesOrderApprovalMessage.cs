using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.FeatureRabbitMQ
{
    public class SalesOrderApprovalMessage
    {
        public int SalesOrderId { get; set; }
        public string Status { get; set; }
        public bool IsApproved { get; set; }
    }
}
