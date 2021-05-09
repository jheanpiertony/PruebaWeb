using Microsoft.Extensions.Logging;

namespace Common.Services
{
    public class LoggerBDService : ILogerBDService
    {
        private readonly ILogger<LoggerBDService> _logger;
        private readonly Serilog.ILogger loggerDB;

        public LoggerBDService(ILogger<LoggerBDService> logger, Serilog.ILogger loggerDB)
        {
            _logger = logger;
            this.loggerDB = loggerDB;
        }
        public void CraerLogs(string fuente)
        {
            //TExt
            _logger.LogInformation($"Desde {fuente} - Mensaje de informacion TXT");
            _logger.LogWarning($"Desde {fuente} - Mensaje de advertencia TXT");
            _logger.LogError($"Desde {fuente} -Mensaje de error TXT");
            //Ha bases de datos
            loggerDB.Information($"Desde {fuente} - Mensaje de informacion BD");
            loggerDB.Warning($"Desde {fuente} - Mensaje de advertencia BD");
            loggerDB.Error($"Desde {fuente} - Mensaje de error BD");
        }
    }
}
