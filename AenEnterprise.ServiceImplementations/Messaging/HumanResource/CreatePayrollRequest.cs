using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class CreatePayrollRequest
    {
        public int EmployeeId { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal OvertimeHours { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TaxRate { get; set; } = 0.2m; // Default tax rate, can be customized
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public PayType PayType { get; set; }
    }
}
