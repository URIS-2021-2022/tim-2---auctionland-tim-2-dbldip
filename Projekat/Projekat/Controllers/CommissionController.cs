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
        [HttpHead]
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


        [HttpDelete("{commissionId}")]
        public ActionResult<String> DeleteCommission(Guid commissionId)
        {
            commissionRepository.DeleteCommission(commissionId);
            commissionRepository.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPut]
        public ActionResult<CommissionConfirmationDto> UpdateCommission([FromBody] CommissionUpdateDto commissionDto, Guid commissionId)
        {
            var oldCommission = commissionRepository.GetCommissionById(commissionId);
            if(oldCommission == null)
                return NotFound();
            Commission commission = mapper.Map<Commission>(commissionDto);
            mapper.Map(commission, oldCommission);
            commissionRepository.SaveChanges();
            return Ok(mapper.Map<CommissionDto>(oldCommission));
        }
    }
}
