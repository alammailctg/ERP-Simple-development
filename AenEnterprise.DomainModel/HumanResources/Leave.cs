using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public int DaysOfLeave { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public string? ReasonForLeave { get; set; }
        public string? PlaceDuringLeave { get; set; }
        public DateTime? ApplyingDate { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
  
}
