using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace VacationRequester.Middleware.Authentication
{
    public static class AuthenticationMiddleware
    {
        public static void AddAuthenticationJwt(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "VacationRequesterAPI",
                    ValidAudience = "VacationRequesterApp",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere")),
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromSeconds(0) // Eliminate clock skew to get exact expiration time
                };
            });
        }
    }
}
