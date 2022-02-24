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
    [ApiController]
    [Route("api/complaints")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintRepository complaintRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

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
            var complaint = complaintRepository.GetComplaintById(complaintId);

            if(complaint == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ComplaintDto>(complaint));
        }

        [HttpPost]
        public ActionResult<ComplaintConfirmationDto> CreateComplaint([FromBody] ComplaintCreateDto complaint)
        {
            Complaint complaintToCreate = mapper.Map<Complaint>(complaint);
            ComplaintConfirmation confirmation = complaintRepository.CreateComplaint(mapper.Map<Complaint>(complaintToCreate));
            complaintRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetComplaintById", controller: "Complaint", values: new { complaintId = confirmation.complaintId });
            return Created(location, mapper.Map<ComplaintConfirmationDto>(confirmation));
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
    }
}
