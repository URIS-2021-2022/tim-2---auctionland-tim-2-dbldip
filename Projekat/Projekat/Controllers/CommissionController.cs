using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Projekat.Data;
using Projekat.Entities;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Controllers
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

        [HttpHead]
        [HttpGet]
        public ActionResult<List<CommissionDto>> GetCommissions(string presidentId)
        {
            List<Commission> commissions = commissionRepository.GetCommissions(presidentId);
            if(commissions.Count() == 0 || commissions == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<CommissionDto>>(commissions));
        }

        [HttpGet("{commissionId}")]
        public ActionResult<CommissionDto> GetCommissionById(Guid commissionId)
        {
            Commission commission = commissionRepository.GetCommissionById(commissionId);
            if(commission == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommissionDto>(commission));
        }

        [HttpPost]
        public ActionResult<CommissionConfirmationDto> CreateCommission([FromBody]CommissionCreationDto commissionDto)
        {
            try
            {
                bool validate = Validate(commissionDto);
                commissionDto.CommissionId = Guid.NewGuid();
                Commission commission = mapper.Map<Commission>(commissionDto);
                CommissionConfirmation confirmation = commissionRepository.CreateCommission(commission);
                string location = linkGenerator.GetPathByAction("GetCommissionById", "Commission", new { commissionId = confirmation.CommissionId });
                return Created(location, mapper.Map<CommissionConfirmationDto>(confirmation));
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{commissionId}")]
        public IActionResult DeleteCommission(Guid commissionId)
        {
            try
            {
                Commission commission = commissionRepository.GetCommissionById(commissionId);
                if(commission == null)
                {
                    return NotFound();
                }
                commissionRepository.DeleteCommission(commissionId);
                return NoContent();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        [HttpPut]
        public ActionResult<CommissionConfirmationDto> UpdateCommission([FromBody] CommissionUpdateDto commissionDto)
        {
            try
            {
                var oldCommission = commissionRepository.GetCommissionById(commissionDto.CommissionId);
                if(oldCommission == null)
                {
                    return NotFound();
                }

                Commission commission = mapper.Map<Commission>(commissionDto);

                mapper.Map(commission, oldCommission);
                return Ok(mapper.Map<CommissionDto>(oldCommission));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        [HttpOptions]
        public IActionResult GetPersonOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
        public bool Validate(CommissionCreationDto commissionDto)
        {
            if(commissionDto.President == null)
            {
                return false;
            }
            return true;
        }
    }
}
