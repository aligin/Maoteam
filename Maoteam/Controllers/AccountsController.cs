using AutoMapper;
using Maoteam.JwtFeatures;
using Maoteam.Models.AdUser;
using Maoteam.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Maoteam.Controllers
{
    [Route("/api/account")]
    [ApiController]
    public class AccountsController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
        readonly JwtHandler _jwtHandler;

        public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationViewModel userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseViewModel { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseViewModel { IsAuthSuccessful = true, Token = token });
        }
    }
}
