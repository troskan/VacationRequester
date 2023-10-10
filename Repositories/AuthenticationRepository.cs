using Azure.Core;
using Microsoft.EntityFrameworkCore;
using VacationRequester.Data;
using VacationRequester.Models;
using VacationRequester.Models.Dto;
using VacationRequester.Repositories.Interfaces;
using VacationRequester.Services;

namespace VacationRequester.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;

        public AuthenticationRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task IsLoggedInAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RefreshTokenAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return false;
            }

            return true;
        }
        public async Task<User> GetUserByRefreshToken(RefreshToken refreshToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken.Token);
        }

        public async Task<bool> VerifyPasswordAsync(string password, string email)
        {
            var user = await GetUserByEmailAsync(email);

            if(user == null)
            {
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return false;
            }

            return true;

        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            if( email == null )
            {
                return null;
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
