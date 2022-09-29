using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authenticate.Models;
using Microsoft.IdentityModel.Tokens;

namespace Authenticate.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        //dotnet add package Microsoft.AspNetCore.Authentication
        //dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); 
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Bruno"), // user.identity.name
                new Claim(ClaimTypes.Role, "user") // user.identity.isinrole
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}