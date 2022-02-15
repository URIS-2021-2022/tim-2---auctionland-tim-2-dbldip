using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Models.ProtectedZoneDtos;
using System;
using System.Collections.Generic;

namespace ParcelaWebAPI.Controllers
{
    [ApiController]
    [Route("api/protectedZones")]
    public class ProtectedZoneController : ControllerBase
    {
        private readonly IProtectedZoneRepository protectedZoneRepository;
        private readonly IMapper mapper;
        public ProtectedZoneController(IProtectedZoneRepository protectedZoneRepository, IMapper mapper)
        {
            this.protectedZoneRepository = protectedZoneRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ProtectedZoneDto>> GetProtectedZones()
        {
            var protectedZones = protectedZoneRepository.GetProtectedZones();
            return Ok(mapper.Map<List<ProtectedZoneDto>>(protectedZones));
        }

        [HttpGet("{protectedZoneId}")]
        public ActionResult<ProtectedZoneDto> GetProtectedZone(Guid protectedZoneId)
        {
            var protectedZone = protectedZoneRepository.GetProtectedZoneById(protectedZoneId);
            if (protectedZone == null)
                return NoContent();

            return Ok(mapper.Map<ProtectedZoneDto>(protectedZone));
        }

    }
}
