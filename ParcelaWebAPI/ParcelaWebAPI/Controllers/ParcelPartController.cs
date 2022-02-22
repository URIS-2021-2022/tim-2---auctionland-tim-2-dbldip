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
    [ApiController]
    [Route("api/parcelParts")]
    public class ParcelPartController : ControllerBase
    {
        private readonly IParcelPartRepository parcelPartRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;

        public ParcelPartController(IParcelPartRepository parcelPartRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService)
        {
            this.parcelPartRepository = parcelPartRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
        }

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

        [HttpPut]
        public ActionResult<ParcelPartDto> UpdateParcelPart(Guid parcelPartId, ParcelPartUpdateDto parcelPart)
        {
            var oldParcelPart = parcelPartRepository.GetParcelPartById(parcelPart.parcelPartId);
            if (oldParcelPart == null)
            {
                this.loggerService.LogMessage("There is no parcel part with that id", "Put", LogLevel.Warning);

                return NotFound();
            }

            ParcelPart parcelPartEntity = mapper.Map<ParcelPart>(parcelPart);
            mapper.Map(parcelPartEntity, oldParcelPart);
            parcelPartRepository.SaveChanges();

            this.loggerService.LogMessage("Parcel part is updated", "Put", LogLevel.Information);

            return Ok(mapper.Map<ParcelPartDto>(oldParcelPart));
        }

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
