using Application.Data;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

        public PriorityController(IPriorityRepository priorityRepository, IMapper mapper)
        {
            this.priorityRepository = priorityRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PriorityDto>> GetPriorities()
        {
            var priorities = priorityRepository.GetPriorities();
            return Ok(mapper.Map<List<PriorityDto>>(priorities));
        }

        [HttpGet("{priorityId}")]
        public ActionResult<PriorityDto> GetPriority(Guid priorityId)
        {
            var priority = priorityRepository.GetPriorityById(priorityId);
            if(priority == null)
                return NoContent();

            return Ok(mapper.Map<PriorityDto>(priority));
        }
    }
}
