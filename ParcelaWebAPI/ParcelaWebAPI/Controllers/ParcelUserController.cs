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
    /// <summary>
    /// Controller for the parcel user
    /// </summary>
    [ApiController]
    [Route("api/parcelUsers")]
    public class ParcelUserController : ControllerBase
    {
        private readonly IParcelUserRepository parcelUserRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Parcel user Controller constructor
        /// </summary>
        /// <param name="parcelUserRepository">Parcel user repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        ///  /// <param name="loggerService">Logger Service</param>
        public ParcelUserController(IParcelUserRepository parcelUserRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.parcelUserRepository = parcelUserRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all parcel users
        /// </summary>
        /// <returns>List of parcel users</returns>
        /// <response code="200">Returns all parcel users</response>
        /// <response code="404">No parcel user found</response>
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

        /// <summary>
        /// Returns Parcel user by ID
        /// </summary>
        /// <param name="parcelUserId">Parcel user ID</param>
        /// <returns>Parcel user</returns>
        /// <response code="200">Returns parcel user by ID</response>
        /// <response code="404">No parcel user by ID found</response>
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

        /// <summary>
        /// Create new parcel user
        /// </summary>
        /// <param name="parcelUser">Creation parcel user DTO</param>
        /// <returns>Confirmation of created parcel user</returns>
        /// <response code="201">Returns confirmation of created parcel user</response>
        /// <response code="500">Parcel user creation error</response>
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

        /// <summary>
        /// Parcel User modify
        /// </summary>
        /// <param name="parcelUserId">Update Parcel User DTO</param>
        /// <param name="parcelUser">Update Parcel User DTO</param>
        /// <returns>Confirmation of updated Parcel User</returns>
        /// <response code="200">Returns confirmation of updated Parcel User</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found Parcel User by ID</response>
        /// <response code="500">Server error</response>
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

        /// <summary>
        /// Delete parcel user
        /// </summary>
        /// <param name="parcelUserId"> Parcel user ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Parcel user deleted</response>
        /// <response code="404">Parcel user by ID not found</response>
        /// <response code="500">Server error</response>
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
