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
    /// <summary>
    /// Kontroler za oglas
    /// </summary>
    [Route("api/oglas")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OglasController : ControllerBase
    {
        private readonly IOglasRepository _oglasRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Konstruktor kontrolera oglasa - DI
        /// </summary>
        /// <param name="oglasRepository">Repository oglasa/param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public OglasController(IOglasRepository oglasRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _oglasRepository = oglasRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve oglase
        /// </summary>
        /// <returns>Lista oglasa</returns>
        /// <response code="200">Vraća listu oglasa</response>
        /// <response code="404">Nije pronađen ni jedan oglas</response>
        /// 
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

        /// <summary>
        /// Vraća jedan oglas na osnovu ID-a
        /// </summary>
        /// <param name="oglasId">ID oglasa</param>
        /// <returns>Oglas</returns>
        /// <response code="200">Vraća traženi oglas</response>
        /// <response code="404">Nije pronađen oglas za uneti ID</response>
        ///
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

        /// <summary>
        /// Kreira novi oglas
        /// </summary>
        /// <param name="oglas">Model oglas</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog oglasa \
        /// POST /api/oglas \
        /// {   
        ///     "datumObjave": "2020-07-13T00:00:00", \
        ///     "rokObjave": "2022-01-31T18:32:34.4441329", \
        ///     "mesto": "Mesto 3 create", \
        ///     "oglasivac": "Oglasivac 3 create", \
        ///     "oblast": "Oblast 3 create", \
        ///     "predmetJavneProdaje": "Predmet javne prodaje 3", \
        ///     "sluzbeniListId": "09e79dbf-0679-4d8f-a15c-9aad2c86acfa", \
        ///     "sluzbeniList": null \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju oglasa</returns>
        /// <response code="201">Vraća kreirani oglas</response>
        /// <response code="500">Desila se greška prilikom unosa novog oglasa</response>
        ///
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

        /// <summary>
        /// Modifikacija oglas
        /// </summary>
        /// <param name="oglasId">ID oglasa</param>
        /// <param name="oglas">Model oglas</param>
        /// <returns>Potvrda o modifikaciji oglasa</returns>
        /// <response code="200">Izmenjen olgas</response>
        /// <response code="404">Nije pronađen oglas za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije oglasa</response>
        ///
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

        /// <summary>
        /// Brisanje oglasa na osnovu ID-a
        /// </summary>
        /// <param name="oglasId">ID oglasa</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Oglas je uspešno obrisan</response>
        /// <response code="404">Nije pronađen oglas za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja oglasa</response>
        /// 
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
