using LoggerWebApi.Data;
using LoggerWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogRepository _logRepository;

        public LoggerController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult LogMessage([FromBody] LogMessageDto logMessage)
        {
            try
            {
                _logRepository.Log(logMessage);

                return Ok();
            }
            catch (Exception ex)
            {
                var loggMessageError = new LogMessageDto
                {
                    Message = "LoggerWebApi",
                    LogLevel = LogLevel.Error,
                    Method = "Post",
                    Microservice = "Error with adding log message!",
                    Exception = ex
                };
                _logRepository.Log(loggMessageError);

                return StatusCode(StatusCodes.Status500InternalServerError, "Error with adding log message!");
            }
        }

    }
}