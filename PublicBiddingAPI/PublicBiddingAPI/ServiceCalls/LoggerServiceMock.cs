using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.ServiceCalls
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
                Microservice = "PublicBiddingAPI"
            };

            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(logMessage));
        }
    }
}
