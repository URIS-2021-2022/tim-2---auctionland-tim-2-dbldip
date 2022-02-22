using AutoMapper;
using LiceWebAPI.Data.Interfaces;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.KontaktOsoba;
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
    [Route("api/kontaktOsoba")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KontaktOsobaController : ControllerBase
    {
        private readonly IKontaktOsobaRepository _kontaktOsobaRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public KontaktOsobaController(IKontaktOsobaRepository kontaktOsobaRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _kontaktOsobaRepository = kontaktOsobaRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<KontaktOsobaDto>>> GetAllKontaktOsobe()
        {
            var kontaktOsobe = await _kontaktOsobaRepository.GetAllKontaktOsobe();

            if(kontaktOsobe == null || kontaktOsobe.Count == 0)
            {
                _loggerService.LogMessage("Lista kontakt osoba je prazna", "Get", LogLevel.Warning);
                return NoContent();
            }
            _loggerService.LogMessage("Kontakt osobe su uspesno vracene", "Get", LogLevel.Information);
            return Ok(_mapper.Map<IEnumerable<KontaktOsobaDto>>(kontaktOsobe));
        }

        [HttpGet("{kontaktOsobaId}")]
        public async Task<ActionResult<KontaktOsobaDto>> GetKontaktOsoba(Guid kontaktOsobaId)
        {
            var kontaktOsoba = await _kontaktOsobaRepository.GetKontaktOsobaById(kontaktOsobaId);
            if(kontaktOsoba == null)
            {
                _loggerService.LogMessage("Ne postoji kontakt osoba sa tim ID-em", "Get", LogLevel.Warning);
                return NotFound();
            }
            _loggerService.LogMessage("Kontakt osoba je uspesno vracena", "Get", LogLevel.Information);
            return Ok(_mapper.Map<KontaktOsobaDto>(kontaktOsoba));
        }

        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<KontaktOsobaCreateDto>> CreateKontaktOsoba([FromBody] KontaktOsobaCreateDto kontaktOsoba)
        {
            try
            {
                var proveraValidnosti = await _kontaktOsobaRepository.IsValidKontaktOsoba(kontaktOsoba.Telefon);

                if (!proveraValidnosti)
                {
                    var response = new
                    {
                        Message = "Vec postoje podaci u bazi. Unesite druge podatke!"
                    };
                    _loggerService.LogMessage("Vec postoje podaci u bazi.", "Post", LogLevel.Warning);
                    return BadRequest(response);
                }

                KontaktOsoba createdKontaktOsoba = await _kontaktOsobaRepository.CreateKontaktOsoba(_mapper.Map<KontaktOsoba>(kontaktOsoba));
                string location = _linkGenerator.GetPathByAction("GetKontaktOsoba", "KontaktOsoba", new { kontaktOsobaId = createdKontaktOsoba.KontaktOsobaId });

                _loggerService.LogMessage("Kontakt osoba je dodata", "Post", LogLevel.Information);
                return Created(location, _mapper.Map<KontaktOsobaCreateDto>(createdKontaktOsoba));
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom kreiranja kontakt osobe", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create KontaktOsoba error!");
            }
        }

        [Consumes("application/json")]
        [HttpPut("{kontaktOsobaId}")]
        public async Task<ActionResult<KontaktOsobaUpdateDto>> UpdateKontaktOsoba(Guid kontaktOsobaId, [FromBody] KontaktOsobaUpdateDto kontaktOsoba)
        {
            try
            {
                var kontaktOsobaEntity = await _kontaktOsobaRepository.GetKontaktOsobaById(kontaktOsobaId);

                if(kontaktOsobaEntity == null)
                {
                    _loggerService.LogMessage("Ne postoji kontakt osoba sa tim ID-em", "Put", LogLevel.Warning);
                    return NotFound();
                }

                var provareValidnosti = await _kontaktOsobaRepository.IsValidKontaktOsoba(kontaktOsoba.Telefon);

                if (!provareValidnosti)
                {
                    var response = new
                    {
                        Message = "Vec postoje podaci u bazi. Unesite druge podatke!"
                    };
                    _loggerService.LogMessage("Vec postoje podaci u bazi.", "Put", LogLevel.Warning);
                    return BadRequest(response);
                }

                _mapper.Map(kontaktOsoba, kontaktOsobaEntity);

                await _kontaktOsobaRepository.UpdateKontaktOsoba(_mapper.Map<KontaktOsoba>(kontaktOsoba));
                _loggerService.LogMessage("Kontakt osoba je uspesno azurirana", "Put", LogLevel.Information);
                return Ok(kontaktOsoba);
            }
            catch (Exception exception)
            {
                _loggerService.LogMessage("Error prilikom azuriranja kontakt osobe", "Put", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update KontaktOsoba error!");
            }
        }

        [HttpDelete("{kontaktOsobaId}")]
        public async Task<ActionResult> DeleteKontaktOsoba(Guid kontaktOsobaId)
        {
            try
            {
                var kontaktOsoba = await _kontaktOsobaRepository.GetKontaktOsobaById(kontaktOsobaId);

                if(kontaktOsoba == null)
                {
                    _loggerService.LogMessage("Ne postoji kontakt osoba sa tim ID-em", "Delete", LogLevel.Warning);
                    return NotFound();
                }

                await _kontaktOsobaRepository.DeleteKontaktOsoba(kontaktOsobaId);
                _loggerService.LogMessage("Uspesno obrisana kontakt osoba", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception exception) 
            {
                _loggerService.LogMessage("Error prilikom brisanja kontakt osobe", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete KontaktOsoba error!");
            }
        }
    }
}
