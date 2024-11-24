using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class CreateEmployeeRequest
    {
     
        public string Name { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; }
        public decimal ActualSalary { get; set; }
        public int TalentAcquisitionId { get; set; }
        public decimal HouseRent { get; set; }
        public decimal Transportation { get; set; }
        public decimal FoodAllowance { get; set; }
        public decimal HealthInsuranceMonthlyCost { get; set; }
        public decimal RetirmentPlanMonthlyContributionCost { get; set; }
    }
}
