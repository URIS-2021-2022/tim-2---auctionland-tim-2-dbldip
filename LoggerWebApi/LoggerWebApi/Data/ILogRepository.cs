using LoggerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerWebApi.Data
{
    public interface ILogRepository
    {
        void Log(LogMessageDto logMessage);
    }
}
