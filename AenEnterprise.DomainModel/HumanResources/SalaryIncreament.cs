using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class SalaryIncrement
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal IncrementAmount { get; set; } // Increment amount to be added to the base salary
        public DateTime EffectiveDate { get; set; } // Date from which the increment is applicable
        public string? Reason { get; set; } // Reason for the increment (e.g., annual review, promotion)
        public decimal NewBaseSalary { get; set; } // Updated base salary after increment

        public int PayrollId { get; set; }
        public Payroll Payroll { get; set; }
        public Employee? Employee { get; set; }

        // Method to apply the salary increment
        public void ApplyIncrement(Payroll payroll)
        {
            // Check if the increment is effective
            if (DateTime.Now >= EffectiveDate)
            {
                payroll.Employee.BaseSalary += IncrementAmount; // Update the base salary
                NewBaseSalary = payroll.BaseSalary; // Set the new base salary after increment
            }
        }
    }

}
