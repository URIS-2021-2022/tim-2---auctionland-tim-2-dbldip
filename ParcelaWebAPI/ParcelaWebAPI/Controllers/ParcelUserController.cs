using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelUserDtos;
using System;
using System.Collections.Generic;

namespace ParcelaWebAPI.Controllers
{
    [ApiController]
    [Route("api/parcelUsers")]
    public class ParcelUserController : ControllerBase
    {
        private readonly IParcelUserRepository parcelUserRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public ParcelUserController(IParcelUserRepository parcelUserRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.parcelUserRepository = parcelUserRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelUserDto>> GetParcelUsers()
        {
            var parcelUsers = parcelUserRepository.GetParcelUsers();
            return Ok(mapper.Map<List<ParcelUserDto>>(parcelUsers));
        }

        [HttpGet("{parcelUserId}")]
        public ActionResult<ParcelUserDto> GetParcelUser(Guid parcelUserId)
        {
            var parcelUser = parcelUserRepository.GetParcelUserById(parcelUserId);
            if (parcelUser == null)
                return NoContent();

            return Ok(mapper.Map<ParcelUserDto>(parcelUser));
        }

        [HttpPost]
        public ActionResult<ParcelUserConfirmationDto> CreateParcelUser([FromBody] ParcelUserCreationDto parcelUser)
        {
            ParcelUser parcelUserToCreate = mapper.Map<ParcelUser>(parcelUser);
            ParcelUserConfirmation confirmation = parcelUserRepository.CreateParcelUser(parcelUserToCreate);
            parcelUserRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcelUser", controller: "ParcelUser", values: new { parcelUserId = confirmation.parcelUserId });
            return Created(location, mapper.Map<ParcelUserConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<ParcelUserDto> UpdateParcelUser(Guid parcelUserId, ParcelUserUpdateDto parcelUser)
        {
            var oldParcelUser = parcelUserRepository.GetParcelUserById(parcelUser.parcelUserId);
            if (oldParcelUser == null)
                return NotFound();

            ParcelUser parcelUserEntity = mapper.Map<ParcelUser>(parcelUser);
            mapper.Map(parcelUserEntity, oldParcelUser);
            parcelUserRepository.SaveChanges();
            return Ok(mapper.Map<ParcelUserDto>(oldParcelUser));
        }

        [HttpDelete("{parcelUserId}")]
        public IActionResult DeleteParcelUser(Guid parcelUserId)
        {
            try
            {
                var parcelUserToDelete = parcelUserRepository.GetParcelUserById(parcelUserId);
                if (parcelUserToDelete == null)
                    return NotFound();

                parcelUserRepository.DeleteParcelUser(parcelUserId);
                parcelUserRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

    }
}
