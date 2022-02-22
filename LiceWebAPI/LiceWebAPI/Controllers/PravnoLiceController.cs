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
    /// <summary>
    /// Kontroler za pravno lice
    /// </summary>
    [Route("api/pravnoLice")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class PravnoLiceController : ControllerBase
    {
        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Konstruktor kontrolera pravnog lica - DI
        /// </summary>
        /// <param name="pravnoLiceRepository">Repository pravnog lica</param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _pravnoLiceRepository = pravnoLiceRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sva pravna lica
        /// </summary>
        /// <returns>Lista pravnoh lica</returns>
        /// <response code="200">Vraća listu pravnih lica</response>
        /// <response code="404">Nije pronađena ni jedno pravno lice</response>
        /// 
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

        /// <summary>
        /// Vraća jedno pravno lice na osnovu ID-a
        /// </summary>
        /// <param name="liceId">ID pravnog lica</param>
        /// <returns>Pravno lice</returns>
        /// <response code="200">Vraća traženo pravno lice</response>
        /// <response code="404">Nije pronađena pravno lice za uneti ID</response>
        /// 
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

        /// <summary>
        /// Kreira novo pravno lice
        /// </summary>
        /// <param name="pravnoLice">Model pravno lice</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog pravnog lica \
        /// POST /api/pravnoLice \
        /// {   
        ///     "brojTelefona": "0694534321", \
        ///     "brojTelefona2": "0694004321", \
        ///     "email": "filip@gmail.com", \
        ///     "brojRacuna": "908 ‑ 10501123 ‑ 97", \
        ///     "adresaId": "1c989ee3-13b2-4d3b-abeb-c4e6343eace7", \
        ///     "naziv": "Create ", \
        ///     "maticniBroj": "Create ", \
        ///     "faks": "1253627363526", \
        ///     "kontaktOsobaId": "91AF15C5-2AEB-454D-8AC2-AF535783444F" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju pravnog lica</returns>
        /// <response code="201">Vraća kreirano pravno lice</response>
        /// <response code="500">Desila se greška prilikom unosa novog pravnog lica</response>
        /// 
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

        /// <summary>
        /// Modifikacija pravnog lica
        /// </summary>
        /// <param name="liceId">ID pravnog lica</param>
        /// <param name="pravnoLice">Model pravno lica</param>
        /// <returns>Potvrda o modifikaciji pravnog lica</returns>
        /// <response code="200">Izmenjeno pravno lice</response>
        /// <response code="404">Nije pronađeno pravno lice za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije pravno lica</response>
        ///
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

        /// <summary>
        /// Brisanje pravnog lica na osnovu ID-a
        /// </summary>
        /// <param name="liceId">ID pravnog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Pravno lice je uspešno obrisano</response>
        /// <response code="404">Nije pronađeno pravno lice za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja pravnog lica</response>
        /// 
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
