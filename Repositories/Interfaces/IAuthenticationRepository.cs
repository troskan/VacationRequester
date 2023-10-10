using VacationRequester.Models;

namespace VacationRequester.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> VerifyEmailAsync(string email);
        Task<bool> VerifyPasswordAsync(string password, string email);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByRefreshToken(RefreshToken refreshToken);
        Task IsLoggedInAsync(Guid id);
        Task RefreshTokenAsync(User entity);
    }
}