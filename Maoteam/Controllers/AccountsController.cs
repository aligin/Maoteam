using AutoMapper;
using MaoTeam.Configuration.MapperProfiles;
using MaoTeam.JwtFeatures;
using MaoTeam.Models.LocalUsers;
using MaoTeam.Services;
using MaoTeam.ViewModels.Auth;
using MaoTeam.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Monq.Core.MvcExtensions.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MaoTeam.Controllers
{
    [Route("/api/account")]
    [ApiController]
    public class AccountsController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
        readonly JwtHandler _jwtHandler;
        readonly AdUserService _adUserService;

        public AccountsController(UserManager<User> userManager,
            IMapper mapper,
            JwtHandler jwtHandler,
            AdUserService adUserService)
        {
            _adUserService = adUserService;
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseViewModel>> Login([FromBody] UserForAuthenticationViewModel userForAuthentication)
        {
            var credentialsValid = await _adUserService.ValidateUser(userForAuthentication.Username, userForAuthentication.Password);

            if (!credentialsValid)
                return Unauthorized(new AuthResponseViewModel { ErrorMessage = "Invalid Authentication" });

            var user = await _userManager.FindByNameAsync(userForAuthentication.Username);
            if (user == null)
            {
                var adUser = await _adUserService.GetIdentity(userForAuthentication.Username, userForAuthentication.Password);

                if (adUser is null)
                    return Unauthorized(new AuthResponseViewModel { ErrorMessage = "The user is not found in the Active Directory database." });

                // The synchronizer has not syncronized yet the user.
                // We will retrieve the information from the AD.
                user = new User
                {
                    UserName = userForAuthentication.Username,
                    Email = userForAuthentication.Username, // TODO: заполнять email.
                    Id = adUser.ObjectSid
                };
                // Just before we will create a new user, we must be sure
                // that the synchronizer didn't insert the user while we were fetching data from AD.
                var existingUser = await _userManager.FindByNameAsync(userForAuthentication.Username);
                if (existingUser == null)
                    await _userManager.CreateAsync(user, userForAuthentication.Password);
                else
                    user = existingUser;
            }
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            claims.Add(new Claim("sub", user.Id));
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthResponseViewModel { IsAuthSuccessful = true, Token = token };
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetProfile()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return NotFound(new ErrorResponseViewModel($"User with id: {userId} is not found."));

            var mappedUser = new UserViewModel();

            var model = _mapper.Map(user, mappedUser);

            return model;
        }
    }
}
