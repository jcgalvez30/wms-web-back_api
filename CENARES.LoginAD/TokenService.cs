using CENARES.Infraestructure.Entity;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CENARES.LoginAD;

public static class TokenService {
    public static string GenerateToken( string userName ) {
        var key = "La llave secreta es WMS";
        var issuer = "pre_wms.cenares.gob.pe";

        var claims = new[] {
                new Claim(ClaimTypes.Name, userName)
            };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}