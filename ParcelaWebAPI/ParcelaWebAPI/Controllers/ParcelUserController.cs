using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelUserDtos;
using ParcelaWebAPI.ServiceCalls;
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
        private readonly ILoggerService loggerService;
        public ParcelUserController(IParcelUserRepository parcelUserRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.parcelUserRepository = parcelUserRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelUserDto>> GetParcelUsers()
        {
            var parcelUsersCheck = this.parcelUserRepository.GetParcelUsers();
            if (parcelUsersCheck == null || parcelUsersCheck.Count == 0)
            {
                this.loggerService.LogMessage("List of parcels users is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            var parcelUsers = parcelUserRepository.GetParcelUsers();
            this.loggerService.LogMessage("List of parcel users is returned", "Get", LogLevel.Information);

            return Ok(mapper.Map<List<ParcelUserDto>>(parcelUsers));
        }

        [HttpGet("{parcelUserId}")]
        public ActionResult<ParcelUserDto> GetParcelUser(Guid parcelUserId)
        {
            var parcelUser = parcelUserRepository.GetParcelUserById(parcelUserId);
            if (parcelUser == null)
            {
                this.loggerService.LogMessage("There is no parcel user with that id", "Get", LogLevel.Warning);

                return NoContent();

            }
            this.loggerService.LogMessage("Parcel user is returned", "Get", LogLevel.Information);

            return Ok(mapper.Map<ParcelUserDto>(parcelUser));
        }

        [HttpPost]
        public ActionResult<ParcelUserConfirmationDto> CreateParcelUser([FromBody] ParcelUserCreationDto parcelUser)
        {
            ParcelUserCreation parcelUserToCreate = mapper.Map<ParcelUserCreation>(parcelUser);

        
            ParcelUserConfirmation confirmation = parcelUserRepository.CreateParcelUser(parcelUserToCreate);
            parcelUserRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcelUser", controller: "ParcelUser", values: new { parcelUserId = confirmation.parcelUserId });
            this.loggerService.LogMessage("Parcel user is added", "Post", LogLevel.Information);

            return Created(location, mapper.Map<ParcelUserConfirmationDto>(confirmation));
        }

        [Consumes("application/json")]

        [HttpPut("{parcelUserId}")]
        public ActionResult<ParcelUserUpdateDto> UpdateParcelUser(Guid parcelUserId, ParcelUserUpdateDto parcelUser)
        {
            var oldParcelUser = parcelUserRepository.GetParcelUserById(parcelUserId);
            if (oldParcelUser == null)
            {
                this.loggerService.LogMessage("There is no parcel user with that id", "Put", LogLevel.Warning);

                return NotFound();
            }

            ParcelUser parcelUserEntity = mapper.Map<ParcelUser>(parcelUser);
            parcelUserEntity.parcelUserId = parcelUserId;
            mapper.Map(parcelUserEntity, oldParcelUser);
            parcelUserRepository.SaveChanges();

            this.loggerService.LogMessage("Parcel user is updated", "Put", LogLevel.Information);

            return Ok(mapper.Map<ParcelUserDto>(oldParcelUser));
        }

        [HttpDelete("{parcelUserId}")]
        public IActionResult DeleteParcelUser(Guid parcelUserId)
        {
            try
            {
                var parcelUserToDelete = parcelUserRepository.GetParcelUserById(parcelUserId);
                if (parcelUserToDelete == null)
                {
                    this.loggerService.LogMessage("There is no parcel user with that id", "Delete", LogLevel.Warning);

                    return NotFound();
                }

                parcelUserRepository.DeleteParcelUser(parcelUserId);
                parcelUserRepository.SaveChanges();

                this.loggerService.LogMessage("Parcel user is deleted successfully!", "Delete", LogLevel.Warning);
                return Ok("Deleted?");
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting parcel user", "Delete", LogLevel.Error, exception);

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

    }
}
