using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models.Dto
{
    public class RegisterDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters.")]
        public string FirstName { get; set; } = string.Empty;

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters.")]
        public string LastName { get; set; } = string.Empty;
    }
}
