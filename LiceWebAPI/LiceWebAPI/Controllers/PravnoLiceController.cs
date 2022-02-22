using AutoMapper;
using LiceWebAPI.Data.Interfaces;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.Lice.PravnoLice;
using LiceWebAPI.Models.PravnoLice;
using LiceWebAPI.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Controllers
{
    [Route("api/pravnoLice")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class PravnoLiceController : ControllerBase
    {
        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _pravnoLiceRepository = pravnoLiceRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<PravnoLiceDto>>> GetAllPravnaLica()
        {
            var pravnaLica = await _pravnoLiceRepository.GetAllPravnaLica();

            if (pravnaLica == null || pravnaLica.Count == 0)
            {
                _loggerService.LogMessage("Lista pravnih lica je prazna", "Get", LogLevel.Warning);
                return NoContent();
            }
            _loggerService.LogMessage("Pravna lica su uspesno vracena", "Get", LogLevel.Information);
            return Ok(_mapper.Map<IEnumerable<PravnoLiceDto>>(pravnaLica));
        }

        [HttpGet("{liceId}")]
        public async Task<ActionResult<PravnoLiceDto>> GetPravnoLice(Guid liceId)
        {
            var pravnoLice = await _pravnoLiceRepository.GetPravnoLiceById(liceId);
            if (pravnoLice == null)
            {
                _loggerService.LogMessage("Ne postoji pravno lice sa tim ID-em", "Get", LogLevel.Warning);
                return NotFound();
            }
            _loggerService.LogMessage("Pravno lice je uspesno vraceno", "Get", LogLevel.Information);
            return Ok(_mapper.Map<PravnoLiceDto>(pravnoLice));
        }

        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<PravnoLiceCreateDto>> CreatePravnoLice([FromBody] PravnoLiceCreateDto pravnoLice)
        {
            try
            {

                PravnoLice createdPravnoLice = await _pravnoLiceRepository.CreatePravnoLice(_mapper.Map<PravnoLice>(pravnoLice));
                string location = _linkGenerator.GetPathByAction("GetPravnoLice", "PravnoLice", new { liceId = createdPravnoLice.LiceId });
                
                _loggerService.LogMessage("Pravno lice je dodato", "Post", LogLevel.Information);
                return Created(location, _mapper.Map<PravnoLiceCreateDto>(createdPravnoLice));
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom brisanja pravnog lica", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create PravnoLice error!");
            }
        }

        [Consumes("application/json")]
        [HttpPut("{liceId}")]
        public async Task<ActionResult<PravnoLiceUpdateDto>> UpdatePravnoLice(Guid liceId, [FromBody] PravnoLiceUpdateDto pravnoLice)
        {
            try
            {
                var pravnoLiceEntity = await _pravnoLiceRepository.GetPravnoLiceById(liceId);

                if (pravnoLiceEntity == null)
                {
                    _loggerService.LogMessage("Ne postoji pravno lice sa tim ID-em", "Put", LogLevel.Warning);
                    return NotFound();
                }

                _mapper.Map(pravnoLice, pravnoLiceEntity);

                await _pravnoLiceRepository.UpdatePravnoLice(_mapper.Map<PravnoLice>(pravnoLice));
                _loggerService.LogMessage("Pravno lice je uspesno azurirano", "Put", LogLevel.Information);
                return Ok(pravnoLice);
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom azuriranja fizickog lica", "Put", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update PravnoLice error!");
            }
        }

        [HttpDelete("{liceId}")]
        public async Task<ActionResult> DeletePravnoLice(Guid liceId)
        {
            try
            {
                var pravnoLice = await _pravnoLiceRepository.GetPravnoLiceById(liceId);

                if (pravnoLice == null)
                {
                    _loggerService.LogMessage("Ne postoji pravno lice sa tim ID-em", "Delete", LogLevel.Warning);
                    return NotFound();
                }

                await _pravnoLiceRepository.DeletePravnoLice(liceId);
                _loggerService.LogMessage("Uspesno obrisano pravno lice", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom brisanja fizickog lica", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete PravnoLice error!");
            }
        }
    }
}
