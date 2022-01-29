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
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public AddressController(IAddressRepository addressRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AddressDto>> GetAddresses(string streetName, string town, string municipality)
        {
            var addresses = addressRepository.GetAddresses(streetName, town, municipality);
            if (addresses == null || addresses.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<AddressDto>>(addresses));
        }

        [HttpGet("{addressId}")]
        public ActionResult<AddressDto> GetAddress(Guid addressId)
        {
            var address = addressRepository.GetAddressById(addressId);
            if (address == null)
                return NoContent();
            return Ok(mapper.Map<AddressDto>(address));
        }

        [HttpPost]
        public ActionResult<AddressConfirmationDto> CreateAddress([FromBody] AddressCreationDto address)
        {
            Address addressToCreate = mapper.Map<Address>(address);
            AddressConfirmation confirmation = addressRepository.CreateAddress(addressToCreate);
            addressRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetAddress", "Address", new { addressId = confirmation.addressID });
            return Created(location, mapper.Map<AddressConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<AddressDto> UpdateAddress(AddressUpdateDto address)
        {
            var oldAddress = addressRepository.GetAddressById(address.addressId);
            if (oldAddress == null)
                return NotFound();
            Address addressEntity = mapper.Map<Address>(address);
            mapper.Map(addressEntity, oldAddress);
            addressRepository.SaveChanges();
            return Ok(mapper.Map<AddressDto>(oldAddress));
        }

        [HttpDelete("{addressId}")]
        public IActionResult DeleteAddress(Guid addressId)
        {
            try
            {
                var addressToDelete = addressRepository.GetAddressById(addressId);
                if (addressToDelete == null)
                    return NotFound();
                addressRepository.DeleteAddress(addressId);
                addressRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error!");
            }
        }
    }
}
