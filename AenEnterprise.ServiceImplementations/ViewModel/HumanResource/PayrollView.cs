using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.HumanResource
{
    public class PayrollView
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
    }
}
