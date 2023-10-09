using VacationRequester.Models;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Task IsLoggedInAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RefreshTokenAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task VerifyUserAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
