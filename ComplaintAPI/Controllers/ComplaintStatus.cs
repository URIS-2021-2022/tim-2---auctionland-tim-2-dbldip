using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models.ComplaintStatus;
using ComplaintService.Data.Interfaces;
using ComplaintService.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Controllers
{
    /// <summary>
    /// Kontroler za status žalbe
    /// </summary>
    [ApiController]
    [Route("api/complaintStatus")]
    [Produces("application/json", "application/xml")]
    public class ComplaintStatusController : ControllerBase
    {
        private readonly IComplaintStatusRepository complaintStatusRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor kontrolera statusa žalbe
        /// </summary>
        /// <param name="complaintStatusRepository">Repozitorijum kontolera statusa žalbe</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        public ComplaintStatusController(IComplaintStatusRepository complaintStatusRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.complaintStatusRepository = complaintStatusRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve tipove žalbi
        /// </summary>
        /// <param name="complaintStatus">Naziv statusa žalbe</param>
        /// <response code="200">Vraćena je lsita tipova žalbi</response>
        /// <response code="204">Nije pronađen ni jedan status žalbe</response>
        /// <returns>Lista tipova žalbi</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<ComplaintStatusDto>> GetAllComplaintStatuss(string complaintStatus)
        {
            var complaintStatusList = complaintStatusRepository.GetAllComplaintStatus(complaintStatus);

            if (complaintStatusList == null || complaintStatusList.Count == 0)
            {
                this.loggerService.LogMessage("List of complaint statuses is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of complaint statuses is returned", "Get", LogLevel.Information);

            return Ok(mapper.Map<IEnumerable<ComplaintStatusDto>>(complaintStatusList));
        }

        /// <summary>
        /// Vraća status žalbe sa prosleđnim ID-jem
        /// </summary>
        /// <param name="complaintStatusId">ID statusa žalbe</param>
        /// <returns>Status žalbe</returns>
        /// <response code="200">Vraćen je traženi status žalbe</response>
        /// <response code="404">Nije pronađen status žalbe sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{complaintStatusId}")]
        public ActionResult<ComplaintStatusDto> GetComplaint(Guid complaintStatusId)
        {
            var complaintStatus = complaintStatusRepository.GetComplaintStatusById(complaintStatusId);

            if (complaintStatus == null)
            {
                this.loggerService.LogMessage("There is no complaint status with that id", "Get", LogLevel.Warning);
                return NotFound();
            }
            this.loggerService.LogMessage("Complaint status is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<ComplaintStatusDto>(complaintStatus));
        }

        /// <summary>
        /// Kreira novi status žalbe
        /// </summary>
        /// <param name="complaintStatus">Model statusa žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog statusa žalbe \
        /// POST /api/complaintStatus \
        /// {   
        ///     "complaintStatus": "Zalba na Odluku o davanju u zakup"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju statusa žalbe</returns>
        /// <response code="201">Vraćen je kreiran status žalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa novog statusa žalbe</response>
        [Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<ComplaintStatusCreateDto> CreateComplaintStatus([FromBody] ComplaintStatusCreateDto complaintStatus)
        {
            try
            {
                var validComplaintStatus = complaintStatusRepository.isValidComplaintStatus(complaintStatus.complaintStatus);

                if (!validComplaintStatus)
                {
                    this.loggerService.LogMessage("Complaint status is not valid.", "Post", LogLevel.Warning);
                    return BadRequest();
                }

                ComplaintStatus createdComplaintStatus = complaintStatusRepository.CreateComplaintStatus(mapper.Map<ComplaintStatus>(complaintStatus));
                string location = linkGenerator.GetPathByAction("GetComplaintStatus", "ComplaintStatus", new { complaintStatusId = createdComplaintStatus.complaintStatusId });
                
                this.loggerService.LogMessage("Complaint status is created", "Post", LogLevel.Information);

                return Created(location, mapper.Map<ComplaintStatusCreateDto>(createdComplaintStatus));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with creating complaint status", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Complaint Status error");
            }
        }

        /// <summary>
        /// Izmena statusa žalbe
        /// </summary>
        /// <param name="complaintStatusId">ID statusa žalbe</param>
        /// <param name="complaintStatus">Model statusa zalbe</param>
        /// <returns>Potvrda o izmeni statusa žalbe</returns>
        /// <response code="200">Izmenjen status zalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađen status žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene statusa žalbe</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{complaintStatusId}")]
        public ActionResult<ComplaintStatusUpdateDto> UpdateComplaintStatus(Guid complaintStatusId, [FromBody] ComplaintStatusUpdateDto complaintStatus)
        {
            try
            {
                var validComplaintStatus = complaintStatusRepository.isValidComplaintStatus(complaintStatus.complaintStatus);

                if (!validComplaintStatus)
                {
                    this.loggerService.LogMessage("Complaint status is not valid", "Put", LogLevel.Warning);
                    return BadRequest();
                }

                var complaintStatusEntity = complaintStatusRepository.GetComplaintStatusById(complaintStatusId);

                if (complaintStatusEntity == null)
                {
                    this.loggerService.LogMessage("Complaint to update not found", "Put", LogLevel.Warning);
                    return NotFound();
                }

                mapper.Map(complaintStatus, complaintStatusEntity);
                complaintStatusRepository.UpdateComplaintStatus(mapper.Map<ComplaintStatus>(complaintStatus));

                this.loggerService.LogMessage("Complaint status is updated successfully!", "Put", LogLevel.Information);
                return Ok(complaintStatus);
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with updating complaint status", "Put", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Complaint Status error");
            }

        }

        /// <summary>
        /// Brisanje statusa žalbe na osnovu ID-ja
        /// </summary>
        /// <param name="complaintStatusId">ID statusa žalbe</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">Status žalbe je uspešno obrisan</response>
        /// <response code="404">Nije pronađen status žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja statusa žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{complaintStatusId}")]
        public ActionResult DeleteComplaintStatus(Guid complaintStatusId)
        {
            try
            {
                var complaintStatus = complaintStatusRepository.GetComplaintStatusById(complaintStatusId);

                if (complaintStatus == null)
                {
                    this.loggerService.LogMessage("Complaint status to delete does not exist.", "Delete", LogLevel.Warning);
                    return NotFound();
                }

                this.loggerService.LogMessage("Complaint status is deleted", "Delete", LogLevel.Information);
                complaintStatusRepository.DeleteComplaintStatus(complaintStatusId);

                return NoContent();
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting complaint status", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Complaint Status error");
            }
        }

    }
}
