using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.InventoryManagement
{
    public class ProductionOrderCriteria
    {
        public int StatusId { get; set; }

        public string CriteriaName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
