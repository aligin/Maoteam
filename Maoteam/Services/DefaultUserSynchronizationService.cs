using AutoMapper;
using MaoTeam.Configuration;
using MaoTeam.Models;
using MaoTeam.Models.LocalUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MaoTeam.Services
{
    public class DefaultUserSynchronizationService : IUserSynchronizationService
    {
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
        readonly AdAdminUserService _adAdminService;
        readonly ApplicationDbContext _context;
        readonly ILogger<DefaultUserSynchronizationService> _log;

        public DefaultUserSynchronizationService(UserManager<User> userManager,
            IMapper mapper,
            AdAdminUserService adAdminService,
            ApplicationDbContext context,
            ILogger<DefaultUserSynchronizationService> log
            )
        {
            _log = log;
            _context = context;
            _adAdminService = adAdminService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Sync()
        {
            _log.LogInformation("Start users synchronization cycle");
            var adUsersTask = _adAdminService.GetAll();
            var localUsersTask = _context.Users.ToListAsync();

            await Task.WhenAll(adUsersTask, localUsersTask);

            var adUsers = adUsersTask.Result;
            var localUsers = localUsersTask.Result;

            int usersCreated = 0;

            foreach (var adUser in adUsers)
            {
                var localUser = localUsers.FirstOrDefault(localUser => localUser.Id == adUser.ObjectSid);
                if (localUser is null)
                {
                    await _userManager.CreateAsync(CreateUser(adUser));
                    usersCreated++;
                }
            }
            _log.LogInformation($"Users synchronization cycle ended with results: {Environment.NewLine} Users Created: {{UsersCreated}}", usersCreated);
        }

        User CreateUser(AdUser adUser)
        {
            var model = _mapper.Map<User>(adUser);
            return model;
        }
    }
}
