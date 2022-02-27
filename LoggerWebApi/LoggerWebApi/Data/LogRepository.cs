using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggerWebApi.Models;
using NLog;

namespace LoggerWebApi.Data
{
    public class LogRepository : ILogRepository
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public void Log(LogMessageDto logMessage)
        {
            string fullMessage = "Microservices: " + logMessage.Microservice + ", Method: " + logMessage.Method + ", Message: " + logMessage.Message;

            if (logMessage.LogLevel == Microsoft.Extensions.Logging.LogLevel.Information)
            {
                _logger.Info(fullMessage);
            }
            else if (logMessage.LogLevel == Microsoft.Extensions.Logging.LogLevel.Warning)
            {
                _logger.Warn(fullMessage);
            }
            else if (logMessage.LogLevel == Microsoft.Extensions.Logging.LogLevel.Error)
            {
                _logger.Error(logMessage.Exception, fullMessage);
            }
        }
    }
}
