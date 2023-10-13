using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models.Dto
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;


    }
}
