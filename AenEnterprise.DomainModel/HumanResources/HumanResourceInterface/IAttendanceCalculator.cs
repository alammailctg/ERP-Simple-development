using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources.HumanResourceInterface
{
    public interface IAttendanceCalculator
    {
        int CountPresentHours(List<Attendance> attendances, Employee employee);
        decimal CalculatePresentAmount(decimal hourlyRate, int totalPresentHours);
    }
}
