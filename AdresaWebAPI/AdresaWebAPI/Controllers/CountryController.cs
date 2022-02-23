using AdresaWebAPI.Data;
using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AdresaWebAPI.ServiceCalls;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Controllers
{
    /// <summary>
    /// Controller class that manages country data
    /// </summary>
    [ApiController]
    [Route("api/address/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Constructor of CountryController
        /// </summary>
        /// <param name="countryRepository">Country repository that manages access to the country table in the database</param>
        /// <param name="linkGenerator">Used when creating a new country, redirects to other path - endpoint</param>
        /// <param name="mapper">Used to convert one type to another, entity to dto most of the time</param>
        /// <param name="loggerService">Used to log actions on controller</param>
        public CountryController(ICountryRepository countryRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.countryRepository = countryRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }
        /// <summary>
        /// Provides getting all countries in the database
        /// </summary>
        /// <param name="countryName">Country name, query param</param>
        /// <returns>List of countries</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CountryDto>> GetCountries(string countryName)
        {
            var countries = countryRepository.GetCrountires(countryName);
            if (countries == null || countries.Count == 0)
            {
                this.loggerService.LogMessage("List of countries is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of countries is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<CountryDto>>(countries));
        }

        /// <summary>
        /// Provides getting one country with provided id
        /// </summary>
        /// <param name="countryId">Country id</param>
        /// <returns>Country</returns>
        [HttpGet("{countryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CountryDto> GetCountry(Guid countryId)
        {
            var country = countryRepository.GetCountryById(countryId);
            if (country == null)
            {
                this.loggerService.LogMessage("There is no country with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Country is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<CountryDto>(country));
        }

        /// <summary>
        /// Creation endpoint, creates a country
        /// </summary>
        /// <param name="createdCountry">Country entity to create</param>
        /// <returns>Country confirmation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CountryConfirmationDto> CreateCountry([FromBody] CountryCreationDto createdCountry)
        {
            try
            {
                Country country = mapper.Map<Country>(createdCountry);
                CountryConfirmation confirmation = countryRepository.CreateCountry(country);
                countryRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetCountry", "Country", new { countryId = confirmation.countryId });
                this.loggerService.LogMessage("Country is being created", "Post", LogLevel.Information);
                return Created(location, mapper.Map<CountryConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                this.loggerService.LogMessage("Country can not be created!", "Get", LogLevel.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {ex}");
            }
        }

        /// <summary>
        /// Update method for country data
        /// </summary>
        /// <param name="country">New country data</param>
        /// <returns>Country confirmation</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<CountryDto> UpdateCountry(CountryDto country)
        {
            var oldCountry = countryRepository.GetCountryById(country.countryId);
            if (oldCountry == null)
            {
                this.loggerService.LogMessage("Country cant be found with that id", "Put", LogLevel.Warning);
                return NotFound();
            }                
            Country countryEntity = mapper.Map<Country>(country);
            mapper.Map(countryEntity, oldCountry);
            countryRepository.SaveChanges();
            this.loggerService.LogMessage("Country is updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<CountryDto>(oldCountry));
        }

        /// <summary>
        /// Delete method for countries
        /// </summary>
        /// <param name="countryId">Country id to delete</param>
        /// <returns>Message</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{countryId}")]
        public IActionResult DeleteCountry(Guid countryId)
        {
            try
            {
                var countryToDelete = countryRepository.GetCountryById(countryId);
                if (countryToDelete == null)
                {
                    this.loggerService.LogMessage("Country cant be found with that id", "Delete", LogLevel.Information);
                    return NotFound();
                }
                countryRepository.DeleteCountry(countryId);
                countryRepository.SaveChanges();
                this.loggerService.LogMessage("Country is deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch(Exception ex)
            {
                this.loggerService.LogMessage("Error while updating country", "Delete", LogLevel.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error!");
            }
        }

    }
}

