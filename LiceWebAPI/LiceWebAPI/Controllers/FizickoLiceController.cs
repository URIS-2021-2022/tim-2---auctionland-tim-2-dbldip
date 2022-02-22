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
    [Route("api/fizickoLice")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class FizickoLiceController : ControllerBase
    {
        private readonly IFizickoLiceRepository _fizickoLiceRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            _fizickoLiceRepository = fizickoLiceRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _loggerService = loggerService;
        }

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
