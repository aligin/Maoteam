using AutoMapper;
using Maoteam.Configuration;
using Maoteam.JwtFeatures;
using Maoteam.Models.LocalUsers;
using Maoteam.Services;
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
        readonly ADUserService _adUserService;

        public AccountsController(UserManager<User> userManager,
            IMapper mapper,
            JwtHandler jwtHandler,
            ADUserService adUserService)
        {
            _adUserService = adUserService;
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationViewModel userForAuthentication)
        {
            var credentialsValid = await _adUserService.ValidateUser(userForAuthentication.Username, userForAuthentication.Password);
            if (!credentialsValid)
                return Unauthorized(new AuthResponseViewModel { ErrorMessage = "Invalid Authentication" });

            var user = await _userManager.FindByNameAsync(userForAuthentication.Username);
            if (user == null)
            {
                var adUser = await _adUserService.GetIdentity(userForAuthentication.Username, userForAuthentication.Password);

                if (adUser is null)
                    return Unauthorized(new AuthResponseViewModel { ErrorMessage = "The user is not found in the Active Directory database" });
                
                // The synchronizer has not syncronized yet the user.
                // We will retrieve the information from the AD.
                user = new User
                {
                    UserName = userForAuthentication.Username,
                    Email = userForAuthentication.Username,
                    Id = adUser.ObjectSid
                };
                await _userManager.CreateAsync(user, userForAuthentication.Password);
            }
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseViewModel { IsAuthSuccessful = true, Token = token });
        }
    }
}
