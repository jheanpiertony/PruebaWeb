using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;

namespace CommonCore.Services
{
    public class HosterService : IHostedService, IDisposable
    {
        public HosterService(IServiceProvider services, IHostingEnvironment environment)
        {
            Services = services;
            Environment = environment;
        }

        private Timer timerDB;
        private Timer timerText;
        private string fileName = "File1.txt";
        private string message = string.Empty;

        public IServiceProvider Services { get; }
        public IHostingEnvironment Environment { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timerDB = new Timer(DoWorkDB, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            timerText = new Timer(DoWorkText, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWorkText(object state)
        {
            var path = $@"{Environment.ContentRootPath}\wwwroot\{fileName}";
            using(StreamWriter write = new StreamWriter(path, append: true))
            {
                message = $"Mensage generado, escrito al Text {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")} ";
                write.WriteLine(message);
                message = string.Empty;
            }
            
        }

        private void DoWorkDB(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                message = $"Mensage generado, escrito en BD {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")} ";
                context.DoWorks.Add(
                    new DoWork() 
                    {
                      EstaBorrado=false,
                      Evento = message,
                      Fecha = DateTime.Now,
                    });
                context.SaveChanges();
                message = string.Empty;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timerDB?.Change(Timeout.Infinite, 0);
            timerText?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timerDB?.Dispose();
            timerText?.Dispose();
        }
    }
}
