using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.ServiceCalls
{
    public interface ILoggerService
    {
        void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null);
    }
}
