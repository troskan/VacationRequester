using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}