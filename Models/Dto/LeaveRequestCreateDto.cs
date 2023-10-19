namespace VacationRequester.Models.Dto
{
    public class LeaveRequestCreateDto
    {
        public Guid UserId { get; set; }
        public Guid LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
