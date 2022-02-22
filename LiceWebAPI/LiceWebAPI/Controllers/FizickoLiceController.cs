using AutoMapper;
using LiceWebAPI.Data.Interfaces;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.Lice.FizickoLice;
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
    /// Kontroler za fizičko lice
    /// </summary>
    [Route("api/fizickoLice")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class FizickoLiceController : ControllerBase
    {
        private readonly IFizickoLiceRepository _fizickoLiceRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Konstruktor kontrolera fizičkog lica - DI
        /// </summary>
        /// <param name="fizickoLiceRepository">Repository fizičkog lica</param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _fizickoLiceRepository = fizickoLiceRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sva fizička lica
        /// </summary>
        /// <returns>Lista fizičkih lica</returns>
        /// <response code="200">Vraća listu fizičkih lica</response>
        /// <response code="404">Nije pronađena ni jedno fizičko lice</response>
        /// 
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<FizickoLiceDto>>> GetAllFizickaLica()
        {
            var fizickaLica = await _fizickoLiceRepository.GetAllFizickaLica();

            if (fizickaLica == null || fizickaLica.Count == 0)
            {
                _loggerService.LogMessage("Lista fizickih lica je prazna", "Get", LogLevel.Warning);
                return NoContent();
            }
            _loggerService.LogMessage("Fizicka lica su uspesno vracena", "Get", LogLevel.Information);
            return Ok(_mapper.Map<IEnumerable<FizickoLiceDto>>(fizickaLica));
        }

        /// <summary>
        /// Vraća jedno fizičko lice na osnovu ID-a
        /// </summary>
        /// <param name="liceId">ID fizičkog lica</param>
        /// <returns>Fizičko lice</returns>
        /// <response code="200">Vraća traženo fizičko lice</response>
        /// <response code="404">Nije pronađeno fizičko lice za uneti ID</response>
        /// 
        [HttpGet("{liceId}")]
        public async Task<ActionResult<FizickoLiceDto>> GetFizickoLice(Guid liceId)
        {
            var fizickoLice = await _fizickoLiceRepository.GetFizickoLiceById(liceId);
            if (fizickoLice == null)
            {
                _loggerService.LogMessage("Ne postoji fizicko lice sa tim ID-em", "Get", LogLevel.Warning);
                return NotFound();
            }
            _loggerService.LogMessage("Fizicko lice je uspesno vraceno", "Get", LogLevel.Information);
            return Ok(_mapper.Map<FizickoLiceDto>(fizickoLice));
        }

        /// <summary>
        /// Kreira novo fizičko lice
        /// </summary>
        /// <param name="fizickoLice">Model fizičko lice</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog fizičkog lica \
        /// POST /api/fizičkoLice \
        /// {   
        ///     "brojTelefona": "0694534321", \
        ///     "brojTelefona2": "0694004321", \
        ///     "email": "filip@gmail.com", \
        ///     "brojRacuna": "908 ‑ 10501123 ‑ 97", \
        ///     "adresaId": "1c989ee3-13b2-4d3b-abeb-c4e6343eace7", \
        ///     "ime": "Create Filip", \
        ///     "prezime": "Create Ivanic", \
        ///     "jmbg": "1253627363526" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju fizičkog lica</returns>
        /// <response code="201">Vraća kreirano fizičko lice</response>
        /// <response code="500">Desila se greška prilikom unosa novog fizičkog lica</response>
        /// 
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<FizickoLiceCreateDto>> CreateFizickoLice([FromBody] FizickoLiceCreateDto fizickoLice)
        {
            try
            {

                FizickoLice createdFizickoLice = await _fizickoLiceRepository.CreateFizickoLice(_mapper.Map<FizickoLice>(fizickoLice));
                string location = _linkGenerator.GetPathByAction("GetFizickoLice", "FizickoLice", new { liceId = createdFizickoLice.LiceId });

                _loggerService.LogMessage("Fizicko lice je dodato", "Post", LogLevel.Information);
                return Created(location, _mapper.Map<FizickoLiceCreateDto>(createdFizickoLice));
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom brisanja fizickog lica", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create FizickoLice error!");
            }
        }

        /// <summary>
        /// Modifikacija fizičkog lica
        /// </summary>
        /// <param name="liceId">ID fizičkog lica</param>
        /// <param name="fizickoLice">Model fizičkog lica</param>
        /// <returns>Potvrda o modifikaciji fizičkog lica</returns>
        /// <response code="200">Izmenjeno fizičko lice</response>
        /// <response code="404">Nije pronađeno fizičko lice za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije fizičkog lica</response>
        ///
        [Consumes("application/json")]
        [HttpPut("{liceId}")]
        public async Task<ActionResult<FizickoLiceUpdateDto>> UpdateFizickoLice(Guid liceId, [FromBody] FizickoLiceUpdateDto fizickoLice)
        {
            try
            {
                var fizickoLiceEntity = await _fizickoLiceRepository.GetFizickoLiceById(liceId);

                if (fizickoLiceEntity == null)
                {
                    _loggerService.LogMessage("Ne postoji fizicko lice sa tim ID-em", "Put", LogLevel.Warning);
                    return NotFound();
                }

                _mapper.Map(fizickoLice, fizickoLiceEntity);

                await _fizickoLiceRepository.UpdateFizickoLice(_mapper.Map<FizickoLice>(fizickoLice));

                _loggerService.LogMessage("Fizicko lice je uspesno azurirano", "Put", LogLevel.Information);
                return Ok(fizickoLice);
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom azuriranja fizickog lica", "Put", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update FizickoLice error!");
            }
        }

        /// <summary>
        /// Brisanje fizičkog lica na osnovu ID-a
        /// </summary>
        /// <param name="liceId">ID fizičkog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Fizičko lice je uspešno obrisano</response>
        /// <response code="404">Nije pronađeno fizičko lice za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja fizičkog lica</response>
        /// 
        [HttpDelete("{liceId}")]
        public async Task<ActionResult> DeleteFizickoLice(Guid liceId)
        {
            try
            {
                var fizickoLice = await _fizickoLiceRepository.GetFizickoLiceById(liceId);

                if (fizickoLice == null)
                {
                    _loggerService.LogMessage("Ne postoji fizicko lice sa tim ID-em", "Delete", LogLevel.Warning);
                    return NotFound();
                }

                await _fizickoLiceRepository.DeleteFizickoLice(liceId);
                _loggerService.LogMessage("Uspesno obrisano fizicko lice", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom brisanja fizickog lica", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete FizickoLice error!");
            }
        }
    }
}
