using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models.Dto
{
    public class RegisterDto
    { 
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
