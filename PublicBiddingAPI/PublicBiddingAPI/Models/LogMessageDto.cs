using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    public class LogMessageDto
    {
        public string Message { get; set; }

        public LogLevel LogLevel { get; set; }

        public string Microservice { get; set; }

        public string Method { get; set; }

        public Exception Exception { get; set; }
    }
}
