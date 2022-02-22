using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using OglasWebAPI.Data.Interfaces;
using OglasWebAPI.Entities;
using OglasWebAPI.Models.Oglas;
using OglasWebAPI.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Controllers
{
    [Route("api/oglas")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OglasController : ControllerBase
    {
        private readonly IOglasRepository _oglasRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public OglasController(IOglasRepository oglasRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _oglasRepository = oglasRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<OglasDto>>> GetAllOglasi()
        {
            var oglasi = await _oglasRepository.GetAllOglasi();

            if (oglasi == null || oglasi.Count == 0)
            {
                _loggerService.LogMessage("Lista oglasa je prazna", "Get", LogLevel.Warning);
                return NoContent();
            }
            _loggerService.LogMessage("Oglasi su uspesno vraceni", "Get", LogLevel.Information);
            return Ok(_mapper.Map<IEnumerable<OglasDto>>(oglasi));
        }

        [HttpGet("{oglasId}")]
        public async Task<ActionResult<OglasDto>> GetOglas(Guid oglasId)
        {
            var oglas = await _oglasRepository.GetOglasById(oglasId);
            if (oglas == null)
            {
                _loggerService.LogMessage("Ne postoji oglas sa tim ID-em", "Get", LogLevel.Warning);
                return NotFound();
            }
            _loggerService.LogMessage("Oglas je uspesno vracen", "Get", LogLevel.Information);
            return Ok(_mapper.Map<OglasDto>(oglas));
        }

        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<OglasCreateDto>> CreateOglas([FromBody] OglasCreateDto oglas)
        {
            try
            {
                Oglas createdOglas = await _oglasRepository.CreateOglas(_mapper.Map<Oglas>(oglas));
                string location = _linkGenerator.GetPathByAction("GetOglas", "Oglas", new { oglasId = createdOglas.OglasId });

                _loggerService.LogMessage("Oglas je dodat", "Post", LogLevel.Information);
                return Created(location, _mapper.Map<OglasCreateDto>(createdOglas));
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom kreiranja oglasa", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Oglas error!");
            }
        }

        [Consumes("application/json")]
        [HttpPut("{oglasId}")]
        public async Task<ActionResult<OglasUpdateDto>> UpdateOglas(Guid oglasId, [FromBody] OglasUpdateDto oglas)
        {
            try
            {
                var oglasEntity = await _oglasRepository.GetOglasById(oglasId);

                if (oglasEntity == null)
                {
                    _loggerService.LogMessage("Ne postoji oglas sa tim ID-em", "Put", LogLevel.Warning);
                    return NotFound();
                }

                _mapper.Map(oglas, oglasEntity);

                await _oglasRepository.UpdateOglas(_mapper.Map<Oglas>(oglas));

                _loggerService.LogMessage("Oglas je uspesno azurirana", "Put", LogLevel.Information);
                return Ok(oglas);
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom azuriranja oglasa", "Put", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Oglas error!");
            }
        }

        [HttpDelete("{oglasId}")]
        public async Task<ActionResult> DeleteOglas(Guid oglasId)
        {
            try
            {
                var oglas = await _oglasRepository.GetOglasById(oglasId);

                if (oglas == null)
                {
                    _loggerService.LogMessage("Ne postoji oglas sa tim ID-em", "Delete", LogLevel.Warning);
                    return NotFound();
                }

                await _oglasRepository.DeleteOglas(oglasId);
                _loggerService.LogMessage("Uspesno obrisan oglas", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom brisanja oglasa", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Oglas error!");
            }
        }

    }
}
