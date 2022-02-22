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
using CommissionWebAPI.ServiceCalls;
using Microsoft.Extensions.Logging;

namespace CommissionWebAPI.Controllers
{
    [ApiController]
    [Route("api/commissions")]
    public class CommissionController : ControllerBase
    {
        private readonly ICommissionRepository commissionRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;

        public CommissionController(ICommissionRepository commissionRepository, IMapper mapper, LinkGenerator link, ILoggerService loggerService)
        {
            this.commissionRepository = commissionRepository;
            this.mapper = mapper;
            this.linkGenerator = link;
            this.loggerService = loggerService;
        }

        //WORKS
        [HttpGet]
        public ActionResult<List<CommissionDto>> GetCommissions()
        {
            var commissions = commissionRepository.GetCommissions();
            if (commissions.Count == 0 || commissions == null)
            {
                this.loggerService.LogMessage("List of commissions is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of commissions is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<CommissionDto>>(commissions));
        }

        //WORKS
        [HttpGet("{commissionId}")]
        public ActionResult<CommissionDto> GetCommissionById(Guid commissionId)
        {
            var commission = commissionRepository.GetCommissionById(commissionId);
            if (commission == null)
            {
                this.loggerService.LogMessage("There is no commission with that id", "Get", LogLevel.Warning);
                return NotFound();
            }
            this.loggerService.LogMessage("Commission is returned", "Get", LogLevel.Information);
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
            this.loggerService.LogMessage("Commission successfully created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<CommissionConfirmationDto>(confirmation));
        }

        ///WORKS
        [HttpDelete("{commissionId}")]
        public ActionResult<String> DeleteCommission(Guid commissionId)
        {
            try {
                commissionRepository.DeleteCommission(commissionId);
                commissionRepository.SaveChanges();
                this.loggerService.LogMessage("Commission successfully deleted", "Delete", LogLevel.Information);
                return Ok("Deleted");

            }
            catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting commission", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error with deleting commission");
            }
        }
        [HttpPut]
        public ActionResult<CommissionDto> UpdateCommission(CommissionUpdateDto commission)
        {
            try
            {
                var oldCommission = commissionRepository.GetCommissionById(commission.CommissionId);
                if (oldCommission == null)
                {
                    this.loggerService.LogMessage("There is no commission with that id", "Update", LogLevel.Warning);
                    return NotFound();
                }
                Commission commissionEntity = mapper.Map<Commission>(commission);
                mapper.Map(commissionEntity, oldCommission); //update
                commissionRepository.SaveChanges();
                this.loggerService.LogMessage("Commission successfully updated", "Update", LogLevel.Information);
                return Ok(mapper.Map<CommissionDto>(oldCommission));
            }

            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with updating   commission", "Update", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
