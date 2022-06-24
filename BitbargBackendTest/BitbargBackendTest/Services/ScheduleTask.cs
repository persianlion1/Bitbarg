using BitbargBackendTest.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BitbargBackendTest.Services
{
    public class ScheduleTask : BackgroundService
    {
        private readonly ILogger<ScheduleTask> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ScheduleTask(ILogger<ScheduleTask> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IList<ToDo> items = new List<ToDo>();
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IToDoService>();
                    items = scopedService.GetEarlierToDos();
                }

                if (!items.Any())
                {
                    await Task.Delay(new TimeSpan(0, 1, 0));
                    continue;
                }

                foreach (var item in items)
                {
                    System.Diagnostics.Debug.WriteLine("Message sent to user with userId: " + item.UserId);
                }

                await Task.Delay(new TimeSpan(0, 1, 0));
            }
        }
    }
}


