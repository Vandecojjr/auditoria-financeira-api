using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auditoria.Financeira.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Auditoria.Financeira.Domain.Api;

namespace Auditoria.Financeira.Domain.Api.Service;

public class TokenService
{
    public static string GenerateToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}