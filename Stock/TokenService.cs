namespace Stock;

public static class TokenService {
    //public static string GenerateToken(SeguridadModel.Response.ValidarLogin user) {
    //    Settings.Secret = user.idAD;
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.ASCII.GetBytes(user.idAD.ToString());
    //    var tokenDescriptor = new SecurityTokenDescriptor {
    //        Subject = new ClaimsIdentity(new Claim[] {
    //            new Claim(ClaimTypes.Name, user.sNombreUsuario.ToString()),
    //            new Claim(ClaimTypes.Sid, user.idAD.ToString()),
    //            new Claim(ClaimTypes.Email, user.sEmail.ToString()),
    //            new Claim(ClaimTypes.GivenName, string.Concat(user.sNombres.ToString(), user.sApellidos.ToString())),
    //            new Claim(ClaimTypes.MobilePhone, user.sCelular.ToString()),
    //            new Claim(ClaimTypes.Role, user.idRolWeb.ToString()),
    //        }),
    //        Expires = DateTime.UtcNow.AddHours(1),
    //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //    };
    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    return tokenHandler.WriteToken(token);
    //}

    public static string GenerateToken(SeguridadModel.Response.ValidarLogin user)
    {
        Settings.Secret = user.idUsuario.ToString();
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(user.idUsuario.ToString());
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.sNombreUsuario.ToString()),
                new Claim(ClaimTypes.Sid, user.idUsuario.ToString()),
                new Claim(ClaimTypes.Email, user.sEmail.ToString()),
                new Claim(ClaimTypes.GivenName, string.Concat(user.sNombres.ToString(), user.sApellidos.ToString())),
                new Claim(ClaimTypes.MobilePhone, user.sCelular.ToString()),
                new Claim(ClaimTypes.Role, user.idRolWeb.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
