using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class TimeTracking
    {
        public int Id{ get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan WorkHours { get; set; }
        public bool TimeOff { get; set; }
        public Employee Employee { get; set; } // Navigation property
    }

}
