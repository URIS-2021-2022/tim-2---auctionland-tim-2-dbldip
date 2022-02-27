using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using PaymentService.Data;
using PaymentService.Entities;
using PaymentService.Models;
using PaymentService.ServiceCalls;
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
        private readonly ILoggerService loggerService;

        /// <summary>
        /// ExchangeRateController constructor
        /// </summary>
        /// <param name="exchangeRateRepository">Exchange rate repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger service</param>
        public ExchangeRateController(IExchangeRateRepository exchangeRateRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.exchangeRateRepository = exchangeRateRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all exchange rates
        /// </summary>
        /// <returns>List of exchange rates</returns>
        /// <response code="200">Returns all exchange rates</response>
        /// <response code="404">No exchange rates found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ExchangeRateDto>> GetExchangeRates()
        {
            var exchangeRates = exchangeRateRepository.GetExchangeRates();
            if(exchangeRates == null)
            {
                loggerService.LogMessage("List of exchange rates are empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            loggerService.LogMessage("List of exchange rates is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<ExchangeRateDto>>(exchangeRates));
        }

        /// <summary>
        /// Returns exchange rate by ID
        /// </summary>
        /// <param name="exchangeRateId">Exchange rate ID</param>
        /// <returns>Exchange rate</returns>
        /// <response code="200">Returns exchange rate by ID</response>
        /// <response code="404">No exchange rate by ID found</response>
        [HttpGet("{exchangeRateId}")]
        public ActionResult<ExchangeRateDto> GetExchangeRate(Guid exchangeRateId)
        {
            var exchangeRate = exchangeRateRepository.GetExchangeRateById(exchangeRateId);
            if (exchangeRate == null)
            {
                loggerService.LogMessage("There is no exchange rate with that id", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("Exchange rate returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<ExchangeRateDto>(exchangeRate));
        }

        /// <summary>
        /// Create new exchange rate
        /// </summary>
        /// <param name="exchangeRate">Creation exchange rate DTO</param>
        /// <returns>Confirmation of created exchange rate</returns>
        /// <response code="201">Returns confirmation of created exchange rate</response>
        /// <response code="500">Exchange rate creation error</response>
        [HttpPost]
        public ActionResult<ExchangeRateConfirmationDto> CreateExchangeRate([FromBody] ExchangeRateCreationDto exchangeRate)
        {
            ExchangeRate exchangeRateToCreate = mapper.Map<ExchangeRate>(exchangeRate);
            ExchangeRateConfirmation confirmation = exchangeRateRepository.CreateExchangeRate(exchangeRateToCreate);
            exchangeRateRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetExchangeRate", controller: "ExchangeRate", values: new { exchangeRateId = confirmation.exchangeRateId });
            loggerService.LogMessage("Exchange rate created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<ExchangeRateConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Exchange rate modify
        /// </summary>
        /// <param name="exchangeRate">Update exchange rate DTO</param>
        /// <returns>Confirmation of updated exchange rate</returns>
        /// <response code="200">Returns confirmation of updated exchange rate</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found exchange rate by ID</response>
        /// <response code="500">Server error</response>
        [HttpPut]
        public ActionResult<ExchangeRateDto> UpdateExchangeRate(ExchangeRateUpdateDto exchangeRate)
        {
            var oldExchangeRate = exchangeRateRepository.GetExchangeRateById(exchangeRate.exchangeRateId);
            if (oldExchangeRate == null)
            {
                loggerService.LogMessage("There is no exchange rate with that id", "Get", LogLevel.Warning);
                return NotFound();
            }

            ExchangeRate exchangeRateEntity = mapper.Map<ExchangeRate>(exchangeRate);
            mapper.Map(exchangeRateEntity, oldExchangeRate);
            exchangeRateRepository.SaveChanges();
            loggerService.LogMessage("Exchange rate updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<ExchangeRateDto>(oldExchangeRate));
        }

        /// <summary>
        /// Delete exchange rate
        /// </summary>
        /// <param name="exchangeRateId">Exchange rate ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Exchange rate deleted</response>
        /// <response code="404">Exchange rate by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{exchangeRateId}")]
        public IActionResult DeleteExchangeRate(Guid exchangeRateId)
        {
            try
            {
                var exchangeRateToDelete = exchangeRateRepository.GetExchangeRateById(exchangeRateId);
                if (exchangeRateToDelete == null)
                {
                    loggerService.LogMessage("There is no exchange rate with that id", "Get", LogLevel.Warning);
                    return NotFound();
                }

                exchangeRateRepository.DeleteExchangeRate(exchangeRateId);
                exchangeRateRepository.SaveChanges();
                loggerService.LogMessage("Exchange rate deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error: " + e.Message);
            }
        }
    }
}
