using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;

namespace CommonCore.Services
{
    public class HosterService : IHostedService, IDisposable
    {
        //public HosterService(IServiceProvider services,
        //    ApplicationDbContext dbContext)
        //{
        //    Services = services;
        //    _dbContext = dbContext;
        //}
        public HosterService(IServiceProvider services)
        {
            Services = services;
        }

        private Timer _timer;

        public IServiceProvider Services { get; }

        //private ApplicationDbContext _dbContext;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var message = "ConsumeScopedService. Received message at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                context.DoWorks.Add(
                    new DoWork() 
                    {
                      EstaBorrado=false,
                      Evento = message,
                      Fecha = DateTime.Now,
                    });
                //var log = new HostedServiceLog() { Message = message };
                //context.HostedServiceLogs.Add(log);
                context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
