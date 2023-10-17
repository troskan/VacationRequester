using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VacationRequester.Models;

namespace VacationRequester.Services;
public class JwtService
{
    public JsonWebTokenModel GenerateToken(User user)
    {
        DateTime utcNow = DateTime.UtcNow;
        TimeZoneInfo stockholmZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
        DateTime stockholmTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, stockholmZone);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "VacationRequesterAPI",
            Audience = "VacationRequesterApp",
            IssuedAt = utcNow,

            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = utcNow.AddMinutes(15),  //Test value expire
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        tokenHandler.WriteToken(token);

        var jsonWebToken = new JsonWebTokenModel
        {
            Token = tokenHandler.WriteToken(token),
            Expires = tokenDescriptor.Expires.Value,
            Created = tokenDescriptor.IssuedAt.Value
        };

        return jsonWebToken;
    }
    public RefreshToken GenerateRefreshToken()
    {
        var refreshToken = new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(1),
            Created = DateTime.Now
        };
        return refreshToken;
    }
}
