﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Models.ProtectedZoneDtos;
using ParcelaWebAPI.ServiceCalls;
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
        private readonly ILoggerService loggerService;
        public ProtectedZoneController(IProtectedZoneRepository protectedZoneRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.protectedZoneRepository = protectedZoneRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ProtectedZoneDto>> GetProtectedZones()
        {
            var protectedZonesCheck = this.protectedZoneRepository.GetProtectedZones();
            if (protectedZonesCheck == null || protectedZonesCheck.Count == 0)
            {
                this.loggerService.LogMessage("List of protected zones is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            var protectedZones = protectedZoneRepository.GetProtectedZones();
            this.loggerService.LogMessage("List of protected zones is returned", "Get", LogLevel.Information);

            return Ok(mapper.Map<List<ProtectedZoneDto>>(protectedZones));
        }

        [HttpGet("{protectedZoneId}")]
        public ActionResult<ProtectedZoneDto> GetProtectedZone(Guid protectedZoneId)
        {
            var protectedZone = protectedZoneRepository.GetProtectedZoneById(protectedZoneId);
            if (protectedZone == null)
            {
                this.loggerService.LogMessage("There is no protected zone with that id", "Get", LogLevel.Warning);

                return NoContent();
            }
            this.loggerService.LogMessage("Protected zone is returned", "Get", LogLevel.Information);

            return Ok(mapper.Map<ProtectedZoneDto>(protectedZone));
        }

    }
}
