using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class AttendanceCalculator : IAttendanceCalculator
    {
        public decimal CalculatePresentAmount(decimal hourlyRate, int totalPresentHours)
        {
            return hourlyRate * totalPresentHours;
        }

        public int CountPresentHours(List<Attendance> attendances, Employee employee)
        {
            return attendances
           .Where(a => a.EmployeeId == employee.Id && a.Status == "Present" && a.WorkingHours.TotalHours > 8)
           .Sum(a => (int)a.WorkingHours.TotalHours);
        }

       
    }
}
