using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources.Benefits
{
    public class AllowanceCalculator : IAllowanceCalculator
    {
        public decimal CalculateMonthlyCost(List<Allowances> allowances, Employee employee)
        {
          return allowances.Where(a => a.EmployeeId == employee.Id).Sum(a => a.MonthlyCost);
        }
    }
}
