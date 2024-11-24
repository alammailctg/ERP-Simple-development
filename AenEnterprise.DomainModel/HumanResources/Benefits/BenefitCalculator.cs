using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;

namespace AenEnterprise.DomainModel.HumanResources.Benefits
{
    public class BenefitCalculator : IBenefitCalculator
    {
        public decimal CalculateBenefits(List<Benefit> benefits, Employee employee)
        {
           return benefits.Where(b => b.EmployeeId == employee.Id).Sum(b => b.MonthlyCost);
        }
    }
}
