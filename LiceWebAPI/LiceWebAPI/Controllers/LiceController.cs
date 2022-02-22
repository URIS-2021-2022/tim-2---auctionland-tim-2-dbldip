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
    public class LiceController : ControllerBase
    {
        private readonly ILiceRepository _liceRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public LiceController(ILiceRepository liceRepository, IMapper mapper, ILoggerService loggerService)
        {
            _liceRepository = liceRepository;
            _mapper = mapper;
            _loggerService = loggerService;
        }

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
