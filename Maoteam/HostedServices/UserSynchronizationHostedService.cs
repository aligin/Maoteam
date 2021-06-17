using MaoTeam.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MaoTeam.HostedServices
{
    public class UserSynchronizationHostedService : BackgroundService
    {
        readonly ILogger<UserSynchronizationHostedService> _logger;
        readonly IServiceProvider _services;

        public UserSynchronizationHostedService(IServiceProvider services, ILogger<UserSynchronizationHostedService> logger)
        {
            _services = services;
            _logger = logger;
        }

        async Task DoWork()
        {
            using (var scope = _services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IUserSynchronizationService>();

                try
                {
                    await scopedProcessingService.Sync();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("User Synchronization Service running.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork();

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}
