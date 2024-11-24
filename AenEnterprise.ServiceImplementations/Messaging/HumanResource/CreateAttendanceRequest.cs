using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class CreateAttendanceRequest
    {
        public string? Status { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public int LeaveTypeId { get; set; }
        public string? Remarks { get; set; }
        public int EmployeeId { get; set; }
        public int? PiecesProduced { get; set; }
    }
}
