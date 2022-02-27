using Application.Data;
using Application.Models;
using Application.ServiceCalls;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/applications/priority")]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityRepository priorityRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// ApplicationController constructor
        /// </summary>
        /// <param name="priorityRepository">Priority repository</param>
        /// <param name="mapper">AutoMapper</param>
        /// /// <param name="loggerService">Logger service</param>
        public PriorityController(IPriorityRepository priorityRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.priorityRepository = priorityRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all priorities
        /// </summary>
        /// <returns>List of priorities</returns>
        /// <response code="200">Returns all priorities</response>
        /// <response code="404">No priority found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PriorityDto>> GetPriorities()
        {
            var priorities = priorityRepository.GetPriorities();

            if (priorities == null || priorities.Count == 0)
            {
                loggerService.LogMessage("List of priorities is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("List of priorities returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PriorityDto>>(priorities));
        }

        /// <summary>
        /// Returns priority by ID
        /// </summary>
        /// <param name="priorityId">Priority ID</param>
        /// <returns>Priority</returns>
        /// <response code="200">Returns priority by ID</response>
        /// <response code="404">No priority by ID found</response>
        [HttpGet("{priorityId}")]
        public ActionResult<PriorityDto> GetPriority(Guid priorityId)
        {
            var priority = priorityRepository.GetPriorityById(priorityId);
            if (priority == null)
            {
                loggerService.LogMessage("There is no priority with that id", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("Priority returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<PriorityDto>(priority));
        }
    }
}
