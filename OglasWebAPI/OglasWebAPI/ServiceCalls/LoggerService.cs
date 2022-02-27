﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OglasWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OglasWebAPI.ServiceCalls
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
                    Microservice = "KupacWebApi"
                };

                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(logMessage));
                httpContent.Headers.ContentType.MediaType = "application/json";


         

            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Error while sending log message to logger service");
            }
        }
    }
}
