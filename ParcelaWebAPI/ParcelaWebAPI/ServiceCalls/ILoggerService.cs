﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.ServiceCalls
{
    public interface ILoggerService
    {
        public void LogMessage(string message, string method, LogLevel logLevel, Exception exception = null);
    }
}
