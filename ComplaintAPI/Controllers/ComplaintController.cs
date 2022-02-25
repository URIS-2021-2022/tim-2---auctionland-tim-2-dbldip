using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models;
using ComplaintAPI.Models.Complaint;
using ComplaintService.Data.Interfaces;
using ComplaintService.Entities.Confirmations;
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
    /// Kontroler žalbe
    /// </summary>
    [ApiController]
    [Route("api/complaints")]
    [Produces("application/json", "application/xml")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintRepository complaintRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Konstruktor kontrolera žalbe
        /// </summary>
        /// <param name="complaintRepository">Repozitorijum žalbe </param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        public ComplaintController(IComplaintRepository complaintRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.complaintRepository = complaintRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca sve žalbe
        /// </summary>
        /// <returns>Lista žalbi</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public  ActionResult<List<ComplaintDto>> GetComplaints()
        {
            //Treba integrirati sa Kupac servisom 
            var complaints = complaintRepository.GetAllComplaints();

            if (complaints == null || complaints.Count == 0) 
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ComplaintDto>>(complaints));
        }

        /// <summary>
        /// Vraca žalbu sa traženim ID-jem
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        [HttpGet("{complaintId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<ComplaintDto> GetComplaint(Guid complaintId)
        {
            //I ovde treba integracija sa kupac servisom
            var complaint = complaintRepository.GetComplaintById(complaintId);

            if(complaint == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ComplaintDto>(complaint));
        }


        /// <summary>
        /// Kreira novu žalbu
        /// </summary>
        /// <param name="zalba">Model kreiranja žalba</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove žalbe \
        /// POST /api/complaint \
        /// {   
        ///     "dateOfComplaint": "01-01-2020", \
        ///     "dateOfProcedure": "01-05-2021", \
        ///     "complaintReason": "Nepotpuna dokumentacija", \
        ///     "elaboration": "Nevalidna dokumentacija", \
        ///     "procedureNumber": "TT3415", \
        ///     "decisionNumber": "PP341", \
        ///     "complaintStatusId": "1c989ee3-13b2-4d3b-abeb-c4e6343eace7" \
        ///     "complaintTypeId": "1c989ee3-13b2-4d3b-abeb-c4e6343eace7" \
        ///     "actionTakenId": "1c989ee3-13b2-4d3b-abeb-c4e6343eace7" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju žalbe</returns>
        /// <response code="201">Vraća kreiranu žalbu</response>
        /// <response code="400">Uneta žalba se već nalazi u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa nove žalbe</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ComplaintConfirmationDto> CreateComplaint([FromBody] ComplaintCreateDto complaint)
        {
            try
            {

                Complaint complaintToCreate = mapper.Map<Complaint>(complaint);
                var validComplaint = complaintRepository.isValidComplaint(complaintToCreate);

                if (!validComplaint)
                {
                    return BadRequest();
                }

                ComplaintConfirmation confirmation = complaintRepository.CreateComplaint(mapper.Map<Complaint>(complaintToCreate));

                string location = linkGenerator.GetPathByAction(action: "GetComplaintById", controller: "Complaint", values: new { complaintId = confirmation.complaintId });
                return Created(location, mapper.Map<ComplaintConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Complaint error");
            }
        }

        /// <summary>
        /// Brisanje žalbe na osnovu prosleđenog ID-ja
        /// </summary>
        /// <param name="complaintId">ID žalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Žalba je uspešno izbrisana</response>
        /// <response code="404">Nije pronađena žalba sa unetim ID-jem</response>
        /// <response code="500">Serverska greška u toku brisanja žalbe</response>
        [HttpDelete("{zalbaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteComplaint(Guid complaintId)
        {
            try { 
                var complaint = complaintRepository.GetComplaintById(complaintId);

                if(complaint == null)
                {
                    return NotFound();
                }

                complaintRepository.DeleteComplaint(complaintId);
                    return NoContent();
            }
            catch(Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete complaint error");
            }
        }

        /// <summary>
        /// Izmena  zalbe
        /// </summary>
        /// <param name="complaintId">ID žalbe</param>
        /// <param name="complaint">Model izmene žalbe</param>
        /// <returns>Potvrda o modifikaciji žalbe</returns>
        /// <response code="200">Izmenjena zalba</response>
        /// <response code="400">Uneti podaci već postoje</response>
        /// <response code="404">Nije pronađena ni jedna žalba sa traženim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [HttpPut("{zalbaId}")]
        public ActionResult<ComplaintUpdateDto> UpdateComplaint(Guid complaintId, [FromBody] ComplaintUpdateDto complaint)
        {
            try
            {
                Complaint complaintToUpdate = mapper.Map<Complaint>(complaint);
                var validComplaint = complaintRepository.isValidComplaint(complaintToUpdate);

                if (!validComplaint)
                {
                    return BadRequest();
                }

                var complaintEntity = complaintRepository.GetComplaintById(complaintId);

                if(complaintEntity == null)
                {
                    return NotFound();
                }

                mapper.Map(complaint, complaintEntity);
                complaintRepository.UpdateComplaint(mapper.Map<Complaint>(complaint));
                return Ok(complaint);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update complaint error");
            }
        }
    }
}
