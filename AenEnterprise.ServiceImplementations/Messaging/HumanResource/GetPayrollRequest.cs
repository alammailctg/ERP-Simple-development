using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class GetPayrollRequest
    {
        public int EmployeeId { get; set; }
        public int? Year { get; set; } // Optional year
        public int? Month { get; set; } // Optional month
    }
}
