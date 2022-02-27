using Microsoft.Extensions.Logging;
using System;

namespace AdresaWebAPI.ServiceCalls
{
    public interface ILoggerService
    {
        void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null);
    }
}
