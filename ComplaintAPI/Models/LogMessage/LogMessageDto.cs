using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Models.LogMessage
{
    public class LogMessageDto
    { 
        /// <summary>
        /// Log message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Log level
        /// </summary>
        public LogLevel LogLevel { get; set; }
        /// <summary>
        /// Microservice who 's sending request
        /// </summary>
        public string Microservice { get; set; }
        /// <summary>
        /// Log method
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Log exception
        /// </summary>
        public Exception Exception { get; set; }
    }
}
