using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.ViewModel.HumanResource
{
    public class AttendanceView
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public int LeaveTypeId { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int EmployeeId { get; set; }

        public decimal RegularHours { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public int? PiecesProduced { get; set; }
    }

}
