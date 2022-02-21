using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using CommissionWebAPI.Data;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Controllers
{
    [ApiController]
    [Route("api/commissions")]
    public class CommissionController : ControllerBase
    {
        private readonly ICommissionRepository commissionRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public CommissionController(ICommissionRepository commissionRepository, IMapper mapper, LinkGenerator link)
        {
            this.commissionRepository = commissionRepository;
            this.mapper = mapper;
            this.linkGenerator = link;
        }

        //WORKS
        [HttpGet]
        public ActionResult<List<CommissionDto>> GetCommissions()
        {
            var commissions = commissionRepository.GetCommissions();
            if(commissions.Count == 0 || commissions == null)
                return NoContent();
            return Ok(mapper.Map<List<CommissionDto>>(commissions));
        }

        //WORKS
        [HttpGet("{commissionId}")]
        public ActionResult<CommissionDto> GetCommissionById(Guid commissionId)
        {
            var commission = commissionRepository.GetCommissionById(commissionId);
            if(commission == null)
                return NotFound();
            return Ok(mapper.Map<CommissionDto>(commission));
        }
        
        //WORKS
        [HttpPost]
        public ActionResult<CommissionConfirmationDto> CreateCommission([FromBody]CommissionCreationDto commissionDto)
        {
            CommissionCreation commission = mapper.Map<CommissionCreation>(commissionDto);
            CommissionConfirmation confirmation = commissionRepository.CreateCommission(commission);
            commissionRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetCommissionById", "Commission", new { commissionId = confirmation.CommissionId });
            return Created(location, mapper.Map<CommissionConfirmationDto>(confirmation));
        }

        ///WORKS
        [HttpDelete("{commissionId}")]
        public ActionResult<String> DeleteCommission(Guid commissionId)
        {
            commissionRepository.DeleteCommission(commissionId);
            commissionRepository.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPut]
        public ActionResult<CommissionDto> UpdateCommission(CommissionUpdateDto commission)
        {
            try
            {
                var oldCommission = commissionRepository.GetCommissionById(commission.CommissionId);
                if (oldCommission == null)
                    return NotFound();
                Commission commissionEntity = mapper.Map<Commission>(commission);
                mapper.Map(commissionEntity, oldCommission); //update
                commissionRepository.SaveChanges();
                return Ok(mapper.Map<CommissionDto>(oldCommission));
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
