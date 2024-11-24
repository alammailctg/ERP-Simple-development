namespace AenEnterprise.FrontEndMvc.Models.HumanResource
{
    public class CreateAttendanceRequestForm
    {
        public string? Status { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public int LeaveTypeId { get; set; }
        public string? Remarks { get; set; }
        public int EmployeeId { get; set; }
        public int? PiecesProduced { get; set; }
    }
}
