using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Messaging.HumanResource
{
    public class CreateAttendanceResponse
    {
        public int AttendanceId { get; set; }
        public string Message { get; set; } = "Attendance created successfully.";
    }
}
