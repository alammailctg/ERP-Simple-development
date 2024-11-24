using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
//public enum LeaveType
//{
//    // Casual leave, typically for short-term personal reasons
//    CasualLeave, // 10 days per year

//    // Sick leave, generally requiring a medical certificate
//    SickLeave, // 14 days per year

//    // Annual leave, earned over time based on work duration
//    AnnualLeave, // 1 day for every 18 days worked

//    // Festival holidays, designated by the employer
//    FestivalHoliday, // 11 days per year

//    // Maternity leave for female employees
//    MaternityLeave, // 8 weeks before and 8 weeks after childbirth (16 weeks total)

//    // Public holidays as per government declarations
//    PublicHoliday, // Specific dates declared each year

//    // Leave without pay, subject to employer approval
//    LeaveWithoutPay // Unpaid leave after exhausting other types of leave
//}