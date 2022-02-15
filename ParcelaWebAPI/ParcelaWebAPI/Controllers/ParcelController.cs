using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaWebAPI.Data;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelDtos;
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
        public ParcelController(IParcelRepository parcelRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.parcelRepository = parcelRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelDto>> GetParcels()
        {
            var parcels = parcelRepository.GetParcels();
            return Ok(mapper.Map<List<ParcelDto>>(parcels));
        }

        [HttpGet("{parcelId}")]
        public ActionResult<ParcelDto> GetParcel(Guid parcelId)
        {
            var parcel = parcelRepository.GetParcelById(parcelId);
            if (parcel == null)
                return NoContent();

            return Ok(mapper.Map<ParcelDto>(parcel));
        }

        [HttpPost]
        public ActionResult<ParcelConfirmationDto> CreateParcel([FromBody] ParcelCreationDto parcel)
        {
            Parcel parcelToCreate = mapper.Map<Parcel>(parcel);
            ParcelConfirmation confirmation = parcelRepository.CreateParcel(parcelToCreate);
            parcelRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetParcel", controller: "Parcel", values: new { parcelId = confirmation.parcelId });
            return Created(location, mapper.Map<ParcelConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<ParcelDto> UpdateParcel(Guid parcelId, ParcelUpdateDto parcel)
        {
            var oldParcel = parcelRepository.GetParcelById(parcel.parcelId);
            if (oldParcel == null)
                return NotFound();

            Parcel parcelEntity = mapper.Map<Parcel>(parcel);
            mapper.Map(parcelEntity, oldParcel);
            parcelRepository.SaveChanges();
            return Ok(mapper.Map<ParcelDto>(oldParcel));
        }

        [HttpDelete("{parcelId}")]
        public IActionResult DeleteParcel(Guid parcelId)
        {
            try
            {
                var parcelToDelete = parcelRepository.GetParcelById(parcelId);
                if (parcelToDelete == null)
                    return NotFound();

                parcelRepository.DeleteParcel(parcelId);
                parcelRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

    }
}
