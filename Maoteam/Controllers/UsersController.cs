using Maoteam.Models.AdUser;
using Maoteam.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        readonly ADUserRepository _adUserRepository;

        public UsersController(ILogger<UsersController> logger, ADUserRepository adUserRepository)
        {
            this._adUserRepository = adUserRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _adUserRepository.GetAll();
            return users;
        }
    }
}
