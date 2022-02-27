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
    /// Address controller that provides GET, POST, DELETE AND PUT methods
    /// </summary>
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepository">Address repository, provides methods to alter database</param>
        /// <param name="linkGenerator">Used when creating addresses</param>
        /// <param name="mapper">Mapping between variables</param>
        /// <param name="loggerService">Logging actions </param>
        public AddressController(IAddressRepository addressRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.addressRepository = addressRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Getting all addresses, has query parameters for filtering addresses
        /// </summary>
        /// <param name="streetName">Query param for street name</param>
        /// <param name="town">Query param for town</param>
        /// <param name="municipality">Query param for municipality</param>
        /// <returns>List of addresses</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AddressDto>> GetAddresses(string streetName, string town, string municipality)
        {
            var addresses = addressRepository.GetAddresses(streetName, town, municipality);
            if (addresses == null || addresses.Count == 0)
            {
                this.loggerService.LogMessage("Address list is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Address list is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<AddressDto>>(addresses));
        }

        /// <summary>
        /// Getting address with specified id value
        /// </summary>
        /// <param name="addressId">Id of address request is trying to get</param>
        /// <returns>Address</returns>
        [HttpGet("{addressId}")]
        public ActionResult<AddressDto> GetAddress(Guid addressId)
        {
            var address = addressRepository.GetAddressById(addressId);
            if (address == null)
            {
                this.loggerService.LogMessage("Address was not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Address returned!", "Get", LogLevel.Information);
            return Ok(mapper.Map<AddressDto>(address));
        }

        /// <summary>
        /// Creates new address and saves it into database
        /// </summary>
        /// <param name="address">Address to add</param>
        /// <remarks>
        /// Example of POST request\
        /// POST /api/address\
        /// "addressStreet" : "Urosa Predica"\
        /// "addressNumber" : "93"\
        /// "addressTown" : "Becej"\
        /// "addressMunicipality":"Becej"\
        /// "addressPostalCode" : 21220\
        /// "countryId" :  "6a411c13-a195-48f7-8dbd-67596c3974c0"\
        /// "countryName" : "Serbia"
        /// </remarks>
        /// <returns>Confirmation</returns>
        [HttpPost]
        public ActionResult<AddressConfirmationDto> CreateAddress([FromBody] AddressCreationDto address)
        {
            Address addressToCreate = mapper.Map<Address>(address);
            AddressConfirmation confirmation = addressRepository.CreateAddress(addressToCreate);
            addressRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetAddress", "Address", new { addressId = confirmation.addressID });
            this.loggerService.LogMessage("Created address", "Post", LogLevel.Information);
            return Created(location, mapper.Map<AddressConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="address">Addresses' new values</param>
        /// /// <summary>
        /// Creates new address and saves it into database
        /// </summary>
        /// <param name="address">Address to add</param>
        /// <remarks>
        /// Example of POST request\
        /// POST /api/address\
        /// "addressID": "a091b3a0-d4a9-420f-fea8-08d9e3282c63"\
        /// "addressStreet" : "Urosa Predica"\
        /// "addressNumber" : "93"\
        /// "addressTown" : "Becej"\
        /// "addressMunicipality":"Becej"\
        /// "addressPostalCode" : 21220\
        /// "countryId" :  "6a411c13-a195-48f7-8dbd-67596c3974c0"\
        /// "countryName" : "Serbia"
        /// </remarks>
        /// <returns>Confirmation</returns>
        [HttpPut]
        public ActionResult<AddressDto> UpdateAddress(AddressUpdateDto address)
        {
            var oldAddress = addressRepository.GetAddressById(address.addressId);
            if (oldAddress == null)
            {
                this.loggerService.LogMessage("Address was not found", "Put", LogLevel.Warning);
                return NotFound();

            }
            Address addressEntity = mapper.Map<Address>(address);
            mapper.Map(addressEntity, oldAddress);
            addressRepository.SaveChanges(); 
            this.loggerService.LogMessage("Address was updated", "Get", LogLevel.Information);
            return Ok(mapper.Map<AddressDto>(oldAddress));
        }


        /// <summary>
        /// Delete endpoint
        /// </summary>
        /// <param name="addressId">Id value of deleting address</param>
        /// <returns>Message</returns>
        [HttpDelete("{addressId}")]
        public IActionResult DeleteAddress(Guid addressId)
        {
            try
            {
                var addressToDelete = addressRepository.GetAddressById(addressId);
                if (addressToDelete == null)
                {
                    this.loggerService.LogMessage("Address was not found", "Delete", LogLevel.Warning);
                    return NotFound();
                }
                addressRepository.DeleteAddress(addressId);
                addressRepository.SaveChanges();
                this.loggerService.LogMessage("Address was deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception ex)
            {
                this.loggerService.LogMessage("Error while deleting", "Delete", LogLevel.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
