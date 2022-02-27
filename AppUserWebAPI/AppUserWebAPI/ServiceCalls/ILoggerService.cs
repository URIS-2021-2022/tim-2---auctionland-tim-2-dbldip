using Microsoft.Extensions.Logging;
using System;

namespace AppUserWebAPI.ServiceCalls
{
    public interface ILoggerService
    {
        void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null);
    }
}