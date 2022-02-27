using AppUserWebAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppUserWebAPI.ServiceCalls
{
    public class LoggerService : ILoggerService 
    {
        private readonly IConfiguration _configuration;

        public LoggerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null)
        {
            try
            {
                using var client = new HttpClient();
                string loggerServiceUrl = _configuration["Services:LoggerService"];

                var logMessage = new LogMessageDto
                {
                    Message = message,
                    Method = method,
                    LogLevel = logLevel,
                    Exception = exception,
                    Microservice = "AppUserWebAPI"
                };

                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(logMessage));
                httpContent.Headers.ContentType.MediaType = "application/json";

                var httpResponseMessage = client.PostAsync(loggerServiceUrl, httpContent).Result;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Error while sending log message to logger service");
            }
        }
    }
}
