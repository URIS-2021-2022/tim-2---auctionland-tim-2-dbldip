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
    [ApiController]
    [Route("api/parcels")]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelRepository parcelRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        public ParcelController(IParcelRepository parcelRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.parcelRepository = parcelRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
    }
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

        [HttpPost]
        public ActionResult<ParcelConfirmationDto> CreateParcel([FromBody] ParcelCreationDto parcel, Guid parcelId)
        {
            Parcel parcelToCreate = mapper.Map<Parcel>(parcel);
            Parcel parcelCheck = parcelRepository.GetParcelById(parcelId);
            if (parcelCheck == null)
            {
                this.loggerService.LogMessage("Adding new parcel did not happen", "Post", LogLevel.Warning);
                return NoContent();
            }
            ParcelConfirmation confirmation = parcelRepository.CreateParcel(parcelToCreate);
            parcelRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcel", controller: "Parcel", values: new { parcelId = confirmation.parcelId });
            this.loggerService.LogMessage("Parcel is added", "Post", LogLevel.Information);
            return Created(location, mapper.Map<ParcelConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<ParcelDto> UpdateParcel(Guid parcelId, ParcelUpdateDto parcel)
        {
            var oldParcel = parcelRepository.GetParcelById(parcel.parcelId);
            if (oldParcel == null)
            {
                this.loggerService.LogMessage("There is no parcel with that id", "Put", LogLevel.Warning);
                return NotFound();

            }

            Parcel parcelEntity = mapper.Map<Parcel>(parcel);
            mapper.Map(parcelEntity, oldParcel);
            parcelRepository.SaveChanges();

            this.loggerService.LogMessage("Parcel is updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<ParcelDto>(oldParcel));
        }

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
