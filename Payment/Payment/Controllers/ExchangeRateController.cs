using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PaymentService.Data;
using PaymentService.Entities;
using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/payments/exchangeRates")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateRepository exchangeRateRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ExchangeRateController(IExchangeRateRepository exchangeRateRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.exchangeRateRepository = exchangeRateRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ExchangeRateDto>> GetExchangeRates()
        {
            var exchangeRates = exchangeRateRepository.GetExchangeRates();
            return Ok(mapper.Map<List<ExchangeRateDto>>(exchangeRates));
        }

        [HttpGet("{exchangeRateId}")]
        public ActionResult<ExchangeRateDto> GetExchangeRate(Guid exchangeRateId)
        {
            var exchangeRate = exchangeRateRepository.GetExchangeRateById(exchangeRateId);
            if (exchangeRate == null)
                return NoContent();

            return Ok(mapper.Map<ExchangeRateDto>(exchangeRate));
        }

        [HttpPost]
        public ActionResult<ExchangeRateConfirmationDto> CreateExchangeRate([FromBody] ExchangeRateCreationDto exchangeRate)
        {
            ExchangeRate exchangeRateToCreate = mapper.Map<ExchangeRate>(exchangeRate);
            ExchangeRateConfirmation confirmation = exchangeRateRepository.CreateExchangeRate(exchangeRateToCreate);
            exchangeRateRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetExchangeRate", controller: "ExchangeRateController", values: new { exchangeRate });
            return Created(location, mapper.Map<ExchangeRateConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<ExchangeRateDto> UpdateExchangeRate(ExchangeRateUpdateDto exchangeRate)
        {
            var oldExchangeRate = exchangeRateRepository.GetExchangeRateById(exchangeRate.exchangeRateId);
            if (oldExchangeRate == null)
                return NotFound();

            ExchangeRate exchangeRateEntity = mapper.Map<ExchangeRate>(exchangeRate);
            mapper.Map(exchangeRateEntity, oldExchangeRate);
            exchangeRateRepository.SaveChanges();
            return Ok(mapper.Map<ExchangeRateDto>(oldExchangeRate));
        }

        [HttpDelete("{exchangeRateId}")]
        public IActionResult DeleteExchangeRate(Guid exchangeRateId)
        {
            try
            {
                var exchangeRateToDelete = exchangeRateRepository.GetExchangeRateById(exchangeRateId);
                if (exchangeRateToDelete == null)
                    return NotFound();

                exchangeRateRepository.DeleteExchangeRate(exchangeRateId);
                exchangeRateRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}
