using Common.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CommonCore.Services
{
    public class HosterService2 : IHostedService, IDisposable
    {
        public HosterService2(IHostingEnvironment environment, ILogger<HosterService2> logger, ILogerBDService logerBDService)
        {
            Environment = environment;
            this.logger = logger;
            this.logerBDService = logerBDService;
        }

        private Timer timerText;
        private string fileName = "File2.txt";
        private string message = string.Empty;
        private readonly ILogger logger;
        private readonly ILogerBDService logerBDService;

        public IHostingEnvironment Environment { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timerText = new Timer(DoWorkText, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWorkText(object state)
        {
            var path = $@"{Environment.ContentRootPath}\wwwroot\{fileName}";
            using(StreamWriter write = new StreamWriter(path, append: true))
            {
                message = $"Mensage generado, escrito al Text2 {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")} ";
                write.WriteLine(message);
                message = string.Empty;
                //logger.LogInformation("Informacion: Cuando se escribe en TEXT2 desde DoWorkTExt");
                //logger.LogError("Error: Cuando se escribe en TEXT2 desde DoWorkTExt");
                //logger.LogWarning("Advertencia: Cuando se escribe en TEXT2 desde DoWorkTExt");
                logerBDService.CraerLogs("DESDE Servicio dos (2)");
            }
            
        }        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timerText?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timerText?.Dispose();
        }
    }
}
