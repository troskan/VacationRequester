using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models
{
    public class EditLeaveRequestDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public ApprovalState ApprovalState { get; set; }
    }
}
