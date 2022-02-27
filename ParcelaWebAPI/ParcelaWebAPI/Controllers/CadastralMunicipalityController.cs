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
    /// <summary>
    /// Controller for the cadastral municipality
    /// </summary>
    [ApiController]
    [Route("api/cadastralMunicipalities")]
    public class CadastralMunicipalityController : ControllerBase
    {
        private readonly ICadastralMunicipalityRepository cadastralMunicipalityRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Cadastral municipality Controller constructor
        /// </summary>
        /// <param name="cadastralMunicipalityRepository">Cadastral municipality repository</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger Service</param>
        public CadastralMunicipalityController(ICadastralMunicipalityRepository cadastralMunicipalityRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.cadastralMunicipalityRepository = cadastralMunicipalityRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all cadastral municipalities
        /// </summary>
        /// <returns>List of cadastral municipalities</returns>
        /// <response code="200">Returns all cadastral municipalities</response>
        /// <response code="404">No cadastral municipality found</response>
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

        /// <summary>
        /// Returns Cadastral municipality by ID
        /// </summary>
        /// <param name="cadastralMunicipalityId">Cadastral municipality ID</param>
        /// <returns>Cadastral municipality</returns>
        /// <response code="200">Returns Cadastral municipality by ID</response>
        /// <response code="404">No Cadastral municipality by ID found</response>
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
