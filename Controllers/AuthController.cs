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

        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("token")]
        public IActionResult GetToken(){
            var token = _jwtService.GetToken();
            return Ok(token);
        }

    }
}