using Maoteam.Configuration;
using Maoteam.Models.LocalUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maoteam.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        readonly ILogger<UsersController> _logger;
        readonly ApplicationDbContext _context;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext context)
        {
            this._context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}
