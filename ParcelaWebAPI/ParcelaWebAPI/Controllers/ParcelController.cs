using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelDtos;
using ParcelaWebAPI.ServiceCalls;
using System;
using System.Collections.Generic;


namespace ParcelaWebAPI.Controllers
{
    /// <summary>
    /// Controller for the parcel
    /// </summary>
    [ApiController]
    [Route("api/parcels")]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelRepository parcelRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Parcel Controller constructor
        /// </summary>
        /// <param name="parcelRepository">Parcel repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger Service</param>
        public ParcelController(IParcelRepository parcelRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.parcelRepository = parcelRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all parcels
        /// </summary>
        /// <returns>List of parcels</returns>
        /// <response code="200">Returns all parcels</response>
        /// <response code="404">No parcel found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelDto>> GetParcels()
        {
            var parcelsCheck = this.parcelRepository.GetParcels();
            if (parcelsCheck == null || parcelsCheck.Count == 0)
            {
                this.loggerService.LogMessage("List of parcels is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            var parcels = parcelRepository.GetParcels();
            this.loggerService.LogMessage("List of parcels is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<ParcelDto>>(parcels));
        }

        /// <summary>
        /// Returns parcel by ID
        /// </summary>
        /// <param name="parcelId">Parcel ID</param>
        /// <returns>Parcel</returns>
        /// <response code="200">Returns parcel by ID</response>
        /// <response code="404">No parcel by ID found</response>
        [HttpGet("{parcelId}")]
        public ActionResult<ParcelDto> GetParcel(Guid parcelId)
        {
            var parcel = parcelRepository.GetParcelById(parcelId);
            if (parcel == null)
            {
                this.loggerService.LogMessage("There is no parcel with that id", "Get", LogLevel.Warning);
                return NoContent();

            }
            this.loggerService.LogMessage("Parcel is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<ParcelDto>(parcel));
        }

        /// <summary>
        /// Create new parcel
        /// </summary>
        /// <param name="parcel">Creation parcel DTO</param>
        /// <returns>Confirmation of created parcel</returns>
        /// <response code="201">Returns confirmation of created parcel</response>
        /// <response code="500">Parcel creation error</response>
        [HttpPost]
        public ActionResult<ParcelConfirmationDto> CreateParcel([FromBody] ParcelCreationDto parcel)
        {
            ParcelCreation parcelToCreate = mapper.Map<ParcelCreation>(parcel);
            
            ParcelConfirmation confirmation = parcelRepository.CreateParcel(parcelToCreate);
            parcelRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcel", controller: "Parcel", values: new { parcelId = confirmation.parcelId });
            this.loggerService.LogMessage("Parcel is added", "Post", LogLevel.Information);
            return Created(location, mapper.Map<ParcelConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Parcel modify
        /// </summary>
        /// <param name="parcelId">Update parcel DTO</param>
        /// <param name="parcel">Update parcel DTO</param>
        /// <returns>Confirmation of updated parcel</returns>
        /// <response code="200">Returns confirmation of updated parcel</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found parcel by ID</response>
        /// <response code="500">Server error</response>
        [Consumes("application/json")]
        [HttpPut("{parcelId}")]
        public ActionResult<ParcelUpdateDto> UpdateParcel(Guid parcelId, [FromBody] ParcelUpdateDto parcel)
        {
            var oldParcel = parcelRepository.GetParcelById(parcelId);
            if (oldParcel == null)
            {
                this.loggerService.LogMessage("There is no parcel with that id", "Put", LogLevel.Warning);
                return NotFound();
            }
            Parcel parcelEntity = mapper.Map<Parcel>(parcel);
            parcelEntity.parcelId = parcelId;
            mapper.Map(parcelEntity, oldParcel);
            parcelRepository.SaveChanges();

            this.loggerService.LogMessage("Parcel is updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<ParcelDto>(oldParcel));
        }

        /// <summary>
        /// Delete parcel
        /// </summary>
        /// <param name="parcelId"> Parcel ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Parcel deleted</response>
        /// <response code="404">Parcel by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{parcelId}")]
        public IActionResult DeleteParcel(Guid parcelId)
        {
            try
            {
                var parcelToDelete = parcelRepository.GetParcelById(parcelId);
                if (parcelToDelete == null)
                {
                    this.loggerService.LogMessage("There is no parcel with that id", "Delete", LogLevel.Warning);
                    return NotFound();

                }
                parcelRepository.DeleteParcel(parcelId);
                parcelRepository.SaveChanges();

                this.loggerService.LogMessage("Parcel is deleted successfully!", "Delete", LogLevel.Warning);
                return Ok("Deleted?");
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting parcel", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

    }
}
