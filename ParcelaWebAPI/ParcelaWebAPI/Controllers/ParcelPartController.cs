using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelPartDtos;
using System;
using System.Collections.Generic;

namespace ParcelaWebAPI.Controllers
{
    [ApiController]
    [Route("api/parcelParts")]
    public class ParcelPartController : ControllerBase
    {
        private readonly IParcelPartRepository parcelPartRepository;
        private readonly Mapper mapper;
        private readonly LinkGenerator linkGenerator;
        public ParcelPartController(IParcelPartRepository parcelPartRepository, Mapper mapper, LinkGenerator linkGenerator)
        {
            this.parcelPartRepository = parcelPartRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<ParcelPartDto>> GetParcelParts()
        {
            var parcelParts = parcelPartRepository.GetParcelParts();
            return Ok(mapper.Map<List<ParcelPartDto>>(parcelParts));
        }

        [HttpGet("{parcelPartId}")]
        public ActionResult<ParcelPartDto> GetParcelParts (Guid parcelPartId)
        {
            var parcelPart = parcelPartRepository.GetParcelPartById(parcelPartId);
            if (parcelPart == null)
                return NoContent();

            return Ok(mapper.Map<ParcelPartDto>(parcelPart));

        }

        [HttpPost]
        public ActionResult<ParcelPartConfirmationDto> CreateParcelPart([FromBody] ParcelPartCreationDto parcelPart)
        {
            ParcelPart parcelPartToCreate = mapper.Map<ParcelPart>(parcelPart);
            ParcelPartConfirmation confirmation = parcelPartRepository.CreateParcelPart(parcelPartToCreate);
            parcelPartRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcelPart", controller: "ParcelPart", values: new { parcelPartId = confirmation.parcelPartId });
            return Created(location, mapper.Map<ParcelPartConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<ParcelPartDto> UpdateParcelPart(Guid parcelPartId, ParcelPartUpdateDto parcelPart)
        {
            var oldParcelPart = parcelPartRepository.GetParcelPartById(parcelPart.parcelPartId);
            if (oldParcelPart == null)
                return NotFound();

            ParcelPart parcelPartEntity = mapper.Map<ParcelPart>(parcelPart);
            mapper.Map(parcelPartEntity, oldParcelPart);
            parcelPartRepository.SaveChanges();
            return Ok(mapper.Map<ParcelPartDto>(oldParcelPart));
        }

        [HttpDelete("{parcelPartId}")]
        public IActionResult DeleteParcelPart(Guid parcelPartId)
        {
            try
            {
                var parcelPartToDelete = parcelPartRepository.GetParcelPartById(parcelPartId);
                if (parcelPartToDelete == null)
                    return NotFound();

                parcelPartRepository.DeleteParcelPart(parcelPartId);
                parcelPartRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }


    }
}
