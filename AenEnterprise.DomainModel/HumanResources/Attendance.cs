using AenEnterprise.DomainModel.HumanResources.Benefits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Attendance
    {
        private TimeSpan _checkInTime;
        private TimeSpan _checkOutTime;
        private TimeSpan _workingHours;
        private TimeSpan? _overTimeHours;
        public Attendance()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Status { get; set; }
        
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public TimeSpan RegularHours { get; set; } = TimeSpan.FromHours(8);

        // Backing field for WorkingHours
       

        public TimeSpan WorkingHours
        {
            get => _workingHours;
            set => _workingHours = CheckInTime-CheckOutTime;
        }

        
        public int? PiecesProduced { get; set; }
        public TimeSpan? OverTimeHours
        {
            get
            {
                if (WorkingHours > RegularHours)
                    _overTimeHours = WorkingHours - RegularHours;
                else
                    _overTimeHours = TimeSpan.Zero;

                return _overTimeHours;
            }
            set => _overTimeHours = value;
        }

        public TimeSpan CheckInTime { get => _checkInTime; set => _checkInTime = value; }
        public TimeSpan CheckOutTime { get => _checkOutTime; set => _checkOutTime = value; }
    }

}


