using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class OverTimeCalculator : IOverTimeCalculator
    {
        public int CalculateOverTimeHours(List<Attendance> attendances,Employee employee)
        {
            return attendances.Where(a => a.EmployeeId == employee.Id && a.OverTimeHours.HasValue)
                .Sum(a => (int)a.OverTimeHours.Value.TotalHours);
        }

        public decimal CalculateOverTimeAmount(decimal hourlyRate, int totalOvertimeHours, decimal overtimeMultiplier)
        {
            overtimeMultiplier = 2m;
            return totalOvertimeHours * hourlyRate * overtimeMultiplier;
        }
    }
}
