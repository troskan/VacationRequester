using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models
{
    public class LeaveType
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}