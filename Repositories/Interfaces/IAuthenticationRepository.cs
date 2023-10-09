using VacationRequester.Models;

namespace VacationRequester.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task VerifyUserAsync(User entity);
        Task IsLoggedInAsync(Guid id);
        Task RefreshTokenAsync(User entity);
    }

}