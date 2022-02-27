using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelPartDtos;
using ParcelaWebAPI.ServiceCalls;
using System;
using System.Collections.Generic;

namespace ParcelaWebAPI.Controllers
{
    /// <summary>
    /// Controller for the parcel part
    /// </summary>
    [ApiController]
    [Route("api/parcelParts")]
    public class ParcelPartController : ControllerBase
    {
        private readonly IParcelPartRepository parcelPartRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;


        /// <summary>
        /// Parcel part Controller constructor
        /// </summary>
        /// <param name="parcelPartRepository">Parcel part repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        ///  /// <param name="loggerService">Logger Service</param>
        public ParcelPartController(IParcelPartRepository parcelPartRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService)
        {
            this.parcelPartRepository = parcelPartRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all parcel parts
        /// </summary>
        /// <returns>List of parcel parts</returns>
        /// <response code="200">Returns all parcel parts</response>
        /// <response code="404">No parcel part found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<ParcelPartDto>> GetParcelParts()
        {
            var parcelPartsCheck = this.parcelPartRepository.GetParcelParts();
            if (parcelPartsCheck == null || parcelPartsCheck.Count == 0)
            {
                this.loggerService.LogMessage("List of parcels parts is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            var parcelParts = parcelPartRepository.GetParcelParts();

            this.loggerService.LogMessage("List of parcel parts is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<ParcelPartDto>>(parcelParts));
        }

        /// <summary>
        /// Returns parcel part by ID
        /// </summary>
        /// <param name="parcelPartId">Parcel part ID</param>
        /// <returns>Parcel part</returns>
        /// <response code="200">Returns parcel part by ID</response>
        /// <response code="404">No parcel part by ID found</response>
        [HttpGet("{parcelPartId}")]
        public ActionResult<ParcelPartDto> GetParcelPart (Guid parcelPartId)
        {
            var parcelPart = parcelPartRepository.GetParcelPartById(parcelPartId);
            if (parcelPart == null)
            {
                this.loggerService.LogMessage("There is no parcel part with that id", "Get", LogLevel.Warning);
                return NoContent();

            }

            this.loggerService.LogMessage("Parcel part is returned", "Get", LogLevel.Information);

            return Ok(mapper.Map<ParcelPartDto>(parcelPart));

        }

        /// <summary>
        /// Create new parcel part
        /// </summary>
        /// <param name="parcelPart">Creation parcel part DTO</param>
        /// <returns>Confirmation of created parcel part</returns>
        /// <response code="201">Returns confirmation of created parcel part</response>
        /// <response code="500">Parcel part creation error</response>
        [HttpPost]
        public ActionResult<ParcelPartConfirmationDto> CreateParcelPart([FromBody] ParcelPartCreationDto parcelPart)
        {
            ParcelPartCreation parcelPartToCreate = mapper.Map<ParcelPartCreation>(parcelPart);
           
            ParcelPartConfirmation confirmation = parcelPartRepository.CreateParcelPart(parcelPartToCreate);
            parcelPartRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcelPart", controller: "ParcelPart", values: new { parcelPartId = confirmation.parcelPartId });
            this.loggerService.LogMessage("Parcel part is added", "Post", LogLevel.Information);

            return Created(location, mapper.Map<ParcelPartConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Parcel part modify
        /// </summary>
        /// <param name="parcelPartId">Update parcel part DTO</param>
        /// <param name="parcelPart">Update parcel part DTO</param>
        /// <returns>Confirmation of updated parcel part</returns>
        /// <response code="200">Returns confirmation of updated parcel part</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found parcel part by ID</response>
        /// <response code="500">Server error</response>
        [Consumes("application/json")]
        [HttpPut("{parcelPartId}")]
        public ActionResult<ParcelPartUpdateDto> UpdateParcelPart(Guid parcelPartId, [FromBody] ParcelPartUpdateDto parcelPart)
        {
            var oldParcelPart = parcelPartRepository.GetParcelPartById(parcelPartId);
            if (oldParcelPart == null)
            {
                this.loggerService.LogMessage("There is no parcel part with that id", "Put", LogLevel.Warning);
                return NotFound();
            }

            ParcelPart parcelPartEntity = mapper.Map<ParcelPart>(parcelPart);
            parcelPartEntity.parcelPartId = parcelPartId;
            mapper.Map(parcelPartEntity, oldParcelPart);
            parcelPartRepository.SaveChanges();

            this.loggerService.LogMessage("Parcel part is updated", "Put", LogLevel.Information);

            return Ok(mapper.Map<ParcelPartDto>(oldParcelPart));
        }

        /// <summary>
        /// Delete parcel part
        /// </summary>
        /// <param name="parcelPartId"> Parcel part ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Parcel part deleted</response>
        /// <response code="404">Parcel part by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{parcelPartId}")]
        public IActionResult DeleteParcelPart(Guid parcelPartId)
        {
            try
            {
                var parcelPartToDelete = parcelPartRepository.GetParcelPartById(parcelPartId);
                if (parcelPartToDelete == null)
                {
                    this.loggerService.LogMessage("There is no parcel part with that id", "Delete", LogLevel.Warning);

                    return NotFound();
                }

                parcelPartRepository.DeleteParcelPart(parcelPartId);
                parcelPartRepository.SaveChanges();

                this.loggerService.LogMessage("Parcel part is deleted successfully!", "Delete", LogLevel.Warning);
                return Ok("Deleted?");
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting parcel part", "Delete", LogLevel.Error, exception);

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }


    }
}
