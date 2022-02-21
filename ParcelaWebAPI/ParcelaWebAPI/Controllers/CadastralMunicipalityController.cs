using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Models.CadastralMunicipalityDtos;
using ParcelaWebAPI.ServiceCalls;
using System;
using System.Collections.Generic;

namespace ParcelaWebAPI.Controllers
{
    [ApiController]
    [Route("api/cadastralMunicipalities")]
    public class CadastralMunicipalityController : ControllerBase
    {
        private readonly ICadastralMunicipalityRepository cadastralMunicipalityRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        public CadastralMunicipalityController(ICadastralMunicipalityRepository cadastralMunicipalityRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.cadastralMunicipalityRepository = cadastralMunicipalityRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<CadastralMunicipalityDto>> GetPriorities()
        {
            var cadastralMunicipalitiesCheck = this.cadastralMunicipalityRepository.GetCadastralMunicipalities();
            if (cadastralMunicipalitiesCheck == null || cadastralMunicipalitiesCheck.Count == 0)
            {
                this.loggerService.LogMessage("List of cadastral municipalities is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            var cadastralMunicipalities = cadastralMunicipalityRepository.GetCadastralMunicipalities();

            this.loggerService.LogMessage("List of cadastral municipalities is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<CadastralMunicipalityDto>>(cadastralMunicipalities));
        }

        [HttpGet("{cadastralMunicipalityId}")]
        public ActionResult<CadastralMunicipalityDto> GetCadastralMunicipality(Guid cadastralMunicipalityId)
        {
            var cadastralMunicipality = cadastralMunicipalityRepository.GetCadastralMunicipalityById(cadastralMunicipalityId);
            if (cadastralMunicipality == null)
            {
                this.loggerService.LogMessage("There is no cadastral municipality with that id", "Get", LogLevel.Warning);
                return NoContent();

            }
            this.loggerService.LogMessage("Cadastral municipality is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<CadastralMunicipalityDto>(cadastralMunicipality));
        }
    }
}
