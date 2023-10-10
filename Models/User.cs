using System.ComponentModel.DataAnnotations;
using System.Data;

namespace VacationRequester.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Role Role { get; set; }  // This is an enum

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<LeaveRequest>? LeaveRequests { get; set; }  // Admin will not need this
    }
}