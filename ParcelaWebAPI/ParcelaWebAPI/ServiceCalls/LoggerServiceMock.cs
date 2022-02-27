using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParcelaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.ServiceCalls
{
    public class LoggerServiceMock : ILoggerService
    {
        public void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null)
        {
            var logMessage = new LogMessageDto
            {
                Message = message,
                Method = method,
                LogLevel = logLevel,
                Exception = exception,
                Microservice = "ParcelaWebApi"
            };

            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(logMessage));
        }
    }
}
