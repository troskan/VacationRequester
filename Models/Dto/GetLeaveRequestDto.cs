using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models
{
    public class GetLeaveRequestDto
    {
        public Guid LeaveRequestId { get; set; }
        public Guid UserId { get; set; }
        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public ApprovalState ApprovalState { get; set; }
    }
}
