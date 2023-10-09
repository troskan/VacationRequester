using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository<AuthenticationRepository>
    {
        public Task IsLoggedInAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task VerifyCredentialsAsync(AuthenticationRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task RefreshTokenAsync(AuthenticationRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(AuthenticationRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
