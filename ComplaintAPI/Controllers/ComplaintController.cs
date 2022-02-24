using AutoMapper;
using ComplaintAPI.Models;
using ComplaintService.Data.Interfaces;
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
        public  ActionResult<List<ComplaintDto>> GetComplaints()
        {
            var complaints = complaintRepository.GetAllComplaints();

            if (complaints == null || complaints.Count == 0) 
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ComplaintDto>>(complaints));
        }

        [HttpGet("{complaintId}")]
        public ActionResult<ComplaintDto> GetComplaint(Guid complaintId)
        {
            var complaint = complaintRepository.GetComplaintById(complaintId);

            if(complaint == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ComplaintDto>(complaint));
        }
    }
}
