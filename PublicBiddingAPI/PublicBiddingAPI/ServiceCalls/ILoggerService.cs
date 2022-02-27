using Microsoft.Extensions.Logging;
using System;

namespace PublicBiddingAPI.ServiceCalls
{
    public interface ILoggerService
    {
        void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null);
    }
}
