using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Models.CadastralMunicipalityDtos;
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
        public CadastralMunicipalityController(ICadastralMunicipalityRepository cadastralMunicipalityRepository, IMapper mapper)
        {
            this.cadastralMunicipalityRepository = cadastralMunicipalityRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<CadastralMunicipalityDto>> GetPriorities()
        {
            var cadastralMunicipalities = cadastralMunicipalityRepository.GetCadastralMunicipalities();
            return Ok(mapper.Map<List<CadastralMunicipalityDto>>(cadastralMunicipalities));
        }

        [HttpGet("{cadastralMunicipalityId}")]
        public ActionResult<CadastralMunicipalityDto> GetCadastralMunicipality(Guid cadastralMunicipalityId)
        {
            var cadastralMunicipality = cadastralMunicipalityRepository.GetCadastralMunicipalityById(cadastralMunicipalityId);
            if (cadastralMunicipality == null)
                return NoContent();

            return Ok(mapper.Map<CadastralMunicipalityDto>(cadastralMunicipality));
        }
    }
}
