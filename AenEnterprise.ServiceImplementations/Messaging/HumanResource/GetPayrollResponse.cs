using AenEnterprise.ServiceImplementations.ViewModel.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class GetPayrollResponse
    {
        public IEnumerable<PayrollView> Payrolls { get; set; }
        public PayrollView Payroll { get; set; }
    }
}
