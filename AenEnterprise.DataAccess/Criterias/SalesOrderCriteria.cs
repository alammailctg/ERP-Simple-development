using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.Criterias
{
    public class SalesOrderCriteria
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CriteriaName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public bool IsFullyApproved { get; set; }
        public bool IsPartiallyApproved { get; set; }
        public int statusId { get; set; }
        public bool isActive { get; set; }
    }
}
