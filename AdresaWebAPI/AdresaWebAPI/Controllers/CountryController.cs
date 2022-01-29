using AdresaWebAPI.Data;
using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Controllers
{
    [ApiController]
    [Route("api/address/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public CountryController(ICountryRepository countryRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CountryDto>> GetCountries(string countryName)
        {
            var countries = countryRepository.GetCrountires(countryName);
            if (countries == null || countries.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<CountryDto>>(countries));
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CountryDto> GetCountry(Guid countryId)
        {
            var country = countryRepository.GetCountryById(countryId);
            if (country == null)
                return NoContent();
            return Ok(mapper.Map<CountryDto>(country));
        }

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

                return Created(location, mapper.Map<CountryConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<CountryDto> UpdateCountry(CountryDto country)
        {
            var oldCountry = countryRepository.GetCountryById(country.countryId);
            if (oldCountry == null)
                return NotFound();
            Country countryEntity = mapper.Map<Country>(country);
            mapper.Map(countryEntity, oldCountry);
            countryRepository.SaveChanges();
            return Ok(mapper.Map<CountryDto>(oldCountry));
        }

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
                    return NotFound();
                countryRepository.DeleteCountry(countryId);
                countryRepository.SaveChanges();
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error!");
            }
        }

    }
}

