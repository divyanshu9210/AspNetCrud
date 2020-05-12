using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCrud.Controllers {

    [Route("{controller}")]
    public class AuthController: ControllerBase {

        private readonly IOptions<AppSettings> _appSettings;
        public AuthController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet("token")]
        public IActionResult GetToken(){
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
            return Ok(tokenString);
        }

    }
}