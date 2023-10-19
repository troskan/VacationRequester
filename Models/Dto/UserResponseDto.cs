using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models.Dto
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Role Role { get; set; }  // This is an enum

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
