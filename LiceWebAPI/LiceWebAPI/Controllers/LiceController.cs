using AutoMapper;
using LiceWebAPI.Data.Interfaces;
using LiceWebAPI.Models.Lice;
using LiceWebAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Controllers
{
    /// <summary>
    /// Kontroler za lice
    /// </summary>
    [Route("api/lice")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class LiceController : ControllerBase
    {

        private readonly ILiceRepository _liceRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        /// <summary>
        /// Konstruktor kontrolera lica - DI
        /// </summary>
        /// <param name="liceRepository">Repository lica</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public LiceController(ILiceRepository liceRepository, IMapper mapper, ILoggerService loggerService)
        {
            _liceRepository = liceRepository;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sva lica
        /// </summary>
        /// <returns>Lista lica</returns>
        /// <response code="200">Vraća listu lica</response>
        /// <response code="404">Nije pronađeno ni jedno lice</response>
        /// 
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<LiceDto>>> GetAllLica()
        {
            var lica = await _liceRepository.GetAllLica();

            if (lica == null || lica.Count == 0)
            {
                _loggerService.LogMessage("Lista lica je prazna", "Get", LogLevel.Warning);
                return NoContent();
            }
            _loggerService.LogMessage("Lista lica je uspesno vracena", "Get", LogLevel.Information);
            return Ok(_mapper.Map<IEnumerable<LiceDto>>(lica));
        }

        /// <summary>
        /// Vraća jedno lice na osnovu ID-a
        /// </summary>
        /// <param name="liceId">ID lica</param>
        /// <returns>Lica</returns>
        /// <response code="200">Vraća traženo lice</response>
        /// <response code="404">Nije pronađeno lice za uneti ID</response>
        /// 
        [HttpGet("{liceId}")]
        public async Task<ActionResult<LiceDto>> GetLice(Guid liceId)
        {
            var lice = await _liceRepository.GetLiceById(liceId);
            if (lice == null)
            {
                _loggerService.LogMessage("Ne postoji lice sa tim ID-em", "Get", LogLevel.Warning);
                return NotFound();
            }
            _loggerService.LogMessage("Uspesno vraceno lice", "Get", LogLevel.Information);
            return Ok(_mapper.Map<LiceDto>(lice));
        }
    }
}
