using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using OglasWebAPI.Data.Interfaces;
using OglasWebAPI.Entities;
using OglasWebAPI.Models.SluzbeniList;
using OglasWebAPI.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Controllers
{
    /// <summary>
    /// Kontroler za služebni list
    /// </summary>
    [Route("api/sluzbeniList")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class SluzbeniListController : ControllerBase
    {
        private readonly ISluzbeniListRepository _sluzbeniListRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Konstruktor kontrolera službenog lista - DI
        /// </summary>
        /// <param name="sluzbeniListRepository">Repository službeni list</param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public SluzbeniListController(ISluzbeniListRepository sluzbeniListRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _sluzbeniListRepository = sluzbeniListRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve kontakt osobe
        /// </summary>
        /// <returns>Lista kontakt osoba</returns>
        /// <response code="200">Vraća listu kontakt osoba</response>
        /// <response code="404">Nije pronađena ni jedna kontakt osoba</response>
        /// 
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<SluzbeniListDto>>> GetAllSluzbeniListovi()
        {
            var sluzbeniListovi = await _sluzbeniListRepository.GetAllSluzbeniListovi();

            if (sluzbeniListovi == null || sluzbeniListovi.Count == 0)
            {
                _loggerService.LogMessage("Lista sluzbenih listova je prazna", "Get", LogLevel.Warning);
                return NoContent();
            }
            _loggerService.LogMessage("Sluzbeni listovi su uspesno vraceni", "Get", LogLevel.Information);
            return Ok(_mapper.Map<IEnumerable<SluzbeniListDto>>(sluzbeniListovi));
        }

        /// <summary>
        /// Vraća jednan službeni list na osnovu ID-a
        /// </summary>
        /// <param name="sluzbeniListId">ID službenog lista</param>
        /// <returns>Službeni list</returns>
        /// <response code="200">Vraća traženi službeni list</response>
        /// <response code="404">Nije pronađen službeni list za uneti ID</response>
        /// 
        [HttpGet("{sluzbeniListId}")]
        public async Task<ActionResult<SluzbeniListDto>> GetSluzbeniList(Guid sluzbeniListId)
        {
            var sluzbeniList = await _sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);
            if (sluzbeniList == null)
            {
                _loggerService.LogMessage("Ne postoji sluzbeni list sa tim ID-em", "Get", LogLevel.Warning);
                return NotFound();
            }
            _loggerService.LogMessage("Sluzbeni list je uspesno vracen", "Get", LogLevel.Information);
            return Ok(_mapper.Map<SluzbeniListDto>(sluzbeniList));
        }

        /// <summary>
        /// Kreira novi službeni list
        /// </summary>
        /// <param name="sluzbeniList">Model službeni list</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog službenog lista \
        /// POST /api/sluzbenogLista \
        /// {   
        ///     "broj": "aa2331d", \
        ///     "datum": "2022-02-11", \
        ///     "opis": "Create Opis sluzbenog lista je odlican" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju službenog lista</returns>
        /// <response code="201">Vraća kreirani službeni list</response>
        /// <response code="500">Desila se greška prilikom unosa novog službenog lista</response>
        /// 
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<SluzbeniListCreateDto>> CreateSluzbeniList([FromBody] SluzbeniListCreateDto sluzbeniList)
        {
            try
            {
                var proveraValidnosti = await _sluzbeniListRepository.IsValidSluzbeniList(sluzbeniList.Broj);

                if (!proveraValidnosti)
                {
                    var response = new
                    {
                        Message = "Vec postoje podaci u bazi. Unesite druge podatke!"
                    };
                    _loggerService.LogMessage("Vec postoje podaci u bazi.", "Post", LogLevel.Warning);
                    return BadRequest(response);
                }

                SluzbeniList createdSluzbeniList = await _sluzbeniListRepository.CreateSluzbeniList(_mapper.Map<SluzbeniList>(sluzbeniList));
                string location = _linkGenerator.GetPathByAction("GetSluzbeniList", "SluzbeniList", new { sluzbeniListId = createdSluzbeniList.SluzbeniListId });

                _loggerService.LogMessage("Sluzbeni list je dodat", "Post", LogLevel.Information);
                return Created(location, _mapper.Map<SluzbeniListCreateDto>(createdSluzbeniList));
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom kreiranja sluzbenog lista", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create SluzbeniList error!");
            }
        }

        /// <summary>
        /// Modifikacija službenog lista
        /// </summary>
        /// <param name="sluzbeniListId">ID službenog lista</param>
        /// <param name="sluzbeniList">Model službenog lista</param>
        /// <returns>Potvrda o modifikaciji službenog lista</returns>
        /// <response code="200">Izmenjen službenog lista</response>
        /// <response code="404">Nije pronađen službeni list za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije službenog lista</response>
        ///
        [Consumes("application/json")]
        [HttpPut("{sluzbeniListId}")]
        public async Task<ActionResult<SluzbeniListUpdateDto>> UpdateSluzbeniList(Guid sluzbeniListId, [FromBody] SluzbeniListUpdateDto sluzbeniList)
        {
            try
            {
                var sluzbeniListEntity = await _sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);

                if(sluzbeniListEntity == null)
                {
                    _loggerService.LogMessage("Ne postoji sluzbeni list sa tim ID-em", "Put", LogLevel.Warning);
                    return NotFound();
                }

                var proveraValidnosti = await _sluzbeniListRepository.IsValidSluzbeniList(sluzbeniList.Broj);

                if (!proveraValidnosti)
                {
                    var response = new
                    {
                        Message = "Vec postoje podaci u bazi. Unesite druge podatke!"
                    };
                    _loggerService.LogMessage("Vec postoje podaci u bazi.", "Put", LogLevel.Warning);
                    return BadRequest(response);
                }

                _mapper.Map(sluzbeniList, sluzbeniListEntity);

                await _sluzbeniListRepository.UpdateSluzbeniList(_mapper.Map<SluzbeniList>(sluzbeniList));
                _loggerService.LogMessage("Sluzbeni list je uspesno azuriran", "Put", LogLevel.Information);
                return Ok(sluzbeniList);
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom azuriranja sluzbenog lista", "Put", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update SluzbeniList error!");
            }
        }

        /// <summary>
        /// Brisanje službenog lista na osnovu ID-a
        /// </summary>
        /// <param name="sluzbeniListId">ID službenog lista</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Službeni list je uspešno obrisan</response>
        /// <response code="404">Nije pronađen službeni list za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja službenog lista</response>
        /// 
        [HttpDelete("{sluzbeniListId}")]
        public async Task<ActionResult> DeleteSluzbeniList(Guid sluzbeniListId)
        {
            try
            {
                var sluzbeniList = await _sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);

                if(sluzbeniList == null)
                {
                    _loggerService.LogMessage("Ne postoji sluzbeni list sa tim ID-em", "Delete", LogLevel.Warning);
                    return NotFound();
                }

                await _sluzbeniListRepository.DeleteSluzbeniList(sluzbeniListId);
                _loggerService.LogMessage("Uspesno obrisan sluzbeni list", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom brisanja sluzbenog lista", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete SluzbeniList error!");
            }
        }

    }
}
