using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models.ComplaintType;
using ComplaintService.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Controllers
{
    /// <summary>
    /// Kontroler za tip žalbe
    /// </summary>
    [ApiController]
    [Route("api/complaintType")]
    [Produces("application/json", "application/xml")]
    public class ComplaintTypeController : ControllerBase
    {
        private readonly IComplaintTypeRepository complaintTypeRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Konstruktor kontrolera tipa žalbe
        /// </summary>
        /// <param name="complaintTypeRepository">Repozitorijum kontolera tipa žalbe</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        public ComplaintTypeController(IComplaintTypeRepository complaintTypeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.complaintTypeRepository = complaintTypeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove žalbi
        /// </summary>
        /// <param name="complaintType">Naziv tipa žalbe</param>
        /// <response code="200">Vraćena je lsita tipova žalbi</response>
        /// <response code="204">Nije pronađen ni jedan tip žalbe</response>
        /// <returns>Lista tipova žalbi</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<ComplaintTypeDto>> GetAllComplaintTypes(string complaintType)
        {
            var complaintTypesList = complaintTypeRepository.GetAllComplaintTypes(complaintType);

            if(complaintTypesList == null || complaintTypesList.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<IEnumerable<ComplaintTypeDto>>(complaintTypesList));
        }

        /// <summary>
        /// Vraća tip žalbe sa prosleđnim ID-jem
        /// </summary>
        /// <param name="complaintTypeId">ID tipa žalbe</param>
        /// <returns>Tip žalbe</returns>
        /// <response code="200">Vraćen je traženi tip žalbe</response>
        /// <response code="404">Nije pronađen tip žalbe sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{complaintTypeId}")]
        public ActionResult<ComplaintTypeDto> GetComplaint(Guid complaintTypeId)
        {
            var complaintType = complaintTypeRepository.GetComplaintTypeById(complaintTypeId);

            if(complaintType == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ComplaintTypeDto>(complaintType));
        }

        /// <summary>
        /// Kreira novi tip žalbe
        /// </summary>
        /// <param name="complaintType">Model tipa žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa žalbe \
        /// POST /api/complaintType \
        /// {   
        ///     "complaintType": "Zalba na Odluku o davanju u zakup"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju tipa žalbe</returns>
        /// <response code="201">Vraćen je kreiran tip žalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa novog tipa žalbe</response>
        [Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<ComplaintTypeCreateDto> CreateComplaintType([FromBody] ComplaintTypeCreateDto complaintType)
        {
            try
            {
                var validComplaintType = complaintTypeRepository.isValidComplaintType(complaintType.complaintType);

                if (!validComplaintType)
                {
                    return BadRequest();
                }

                ComplaintType createdComplaintType = complaintTypeRepository.CreateComplaintType(mapper.Map<ComplaintType>(complaintType));

                string location = linkGenerator.GetPathByAction("GetComplaintType", "ComplaintType", new  { complaintTypeId = createdComplaintType.complaintTypeId });

                return Created(location, mapper.Map<ComplaintTypeCreateDto>(createdComplaintType));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Complaint Type error");
            }
        }

        /// <summary>
        /// Izmena tipa žalbe
        /// </summary>
        /// <param name="complaintTypeId">ID tipa žalbe</param>
        /// <param name="complaintType">Model tipa zalbe</param>
        /// <returns>Potvrda o izmeni tipa žalbe</returns>
        /// <response code="200">Izmenjen tip zalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađen tip žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene tipa žalbe</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{complaintTypeId}")]
        public ActionResult<ComplaintTypeUpdateDto> UpdateComplaintType(Guid complaintTypeId, [FromBody] ComplaintTypeUpdateDto complaintType)
        {
            try
            {
                var validComplaintType = complaintTypeRepository.isValidComplaintType(complaintType.complaintType);

                if (!validComplaintType)
                {
                    return BadRequest();
                }

                var complaintTypeEntity = complaintTypeRepository.GetComplaintTypeById(complaintTypeId);

                if(complaintTypeEntity == null)
                {
                    return NotFound();
                }

                mapper.Map(complaintType, complaintTypeEntity);
                complaintTypeRepository.UpdateComplaintType(mapper.Map<ComplaintType>(complaintType));
                
                return Ok(complaintType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Complaint Type error");
            }

        }

        /// <summary>
        /// Brisanje tipa žalbe na osnovu ID-ja
        /// </summary>
        /// <param name="complaintTypeId">ID tipa žalbe</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">Tip žalbe je uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja tipa žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{complaintTypeId}")]
        public ActionResult DeleteComplaintType(Guid complaintTypeId)
        {
            try
            {
                var complaintType = complaintTypeRepository.GetComplaintTypeById(complaintTypeId);

                if (complaintType == null)
                {
                    return NotFound();
                }

                complaintTypeRepository.DeleteComplaintType(complaintTypeId);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Complaint Type error");
            }
        }

    }
}
