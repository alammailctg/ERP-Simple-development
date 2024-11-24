using AenEnterprise.ServiceImplementations.ViewModel.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class CreatePayrollResponse
    {
        public int PayrollId { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime PaymentDate { get; set; }
        public PayrollView Payroll { get; set; }
        public decimal TotalHoursWorked { get; set; }
        public decimal TotalOvertimeHours { get; set; }

    }
}
