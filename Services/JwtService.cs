using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtService: IJwtService {

    private readonly IOptions<AppSettings> _appSettings;

    public JwtService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings;
    }

    public string GetToken(){
        var claims = new Claim[] {
            new Claim(ClaimTypes.Name, "aman")
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.SecretKey));
        var signinCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(
            issuer: _appSettings.Value.Issuer,
            audience: _appSettings.Value.Audience,
            expires: DateTime.Now.AddMinutes(60),
            claims: claims,
            signingCredentials: signinCred
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}