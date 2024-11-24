using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources.HumanResourceInterface
{
    public interface IOverTimeCalculator
    {
        int CalculateOverTimeHours(List<Attendance> attendances,Employee employee);
        decimal CalculateOverTimeAmount(decimal hourlyRate, int totalOvertimeHours, decimal overtimeMultiplier);
    }
}
