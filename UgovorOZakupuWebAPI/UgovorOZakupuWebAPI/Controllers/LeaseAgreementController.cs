using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;
using UgovorOZakupuWebAPI.Models;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.ServiceCalls;
using Microsoft.Extensions.Logging;

namespace UgovorOZakupuWebAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/leaseAgreement")]
    public class LeaseAgreementController : ControllerBase
    {
        private readonly ILeaseAgreementRepository leaseAgreementRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public LeaseAgreementController(ILeaseAgreementRepository leaseAgreementRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.leaseAgreementRepository = leaseAgreementRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<LeaseAgreementDto>> GetLeaseAgreements(string serialNumber)
        {
            var leaseAgreements = leaseAgreementRepository.GetLeaseAgreements(serialNumber);
            if (leaseAgreements == null)
            {
                this.loggerService.LogMessage("List of lease agreements is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of lease agreements is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<LeaseAgreementDto>>(leaseAgreements));
        }

        [HttpGet("{leaseAgreementId}")]
        public ActionResult<LeaseAgreementDto> GetLeaseAgreementById(Guid leaseAgreementId)
        {
            var leaseAgreement = leaseAgreementRepository.GetLeaseAgreementById(leaseAgreementId);
            if (leaseAgreement == null)
            {
                this.loggerService.LogMessage("There is no lease agreement with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Lease agreement is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<LeaseAgreementDto>(leaseAgreement));
        }
        [HttpPost]
        public ActionResult<LeaseAgreementConfirmationDto> CreateLeaseAgreement(LeaseAgreementCreationDto leaseAgreementDto)
        {
            try
            {
                LeaseAgreementCreation leaseAgreement = mapper.Map<LeaseAgreementCreation>(leaseAgreementDto);
                LeaseAgreementConfirmation confirmation = leaseAgreementRepository.CreateLeaseAgreement(leaseAgreement);
                leaseAgreementRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetLeaseAgreementById", "LeaseAgreement", new { leaseAgreementId = confirmation.LeaseAgreementId });
                this.loggerService.LogMessage("Lease agreement is created successfully", "Post", LogLevel.Information);
                return Created(location, mapper.Map<LeaseAgreementConfirmationDto>(confirmation));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with creating lease agreement", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {exception}");
            }
        }

        [HttpPut]
        public ActionResult<LeaseAgreementDto> UpdateLeaseAgreement(LeaseAgreementUpdateDto leaseAgreementDto)
        {
            var oldLeaseAgreement = leaseAgreementRepository.GetLeaseAgreementById(leaseAgreementDto.LeaseAgreementId);
            if (oldLeaseAgreement == null)
            {
                this.loggerService.LogMessage("There is no lease agreement with that id", "Update", LogLevel.Warning);
                return NotFound();
            }
            LeaseAgreement leaseAgreementEntity = mapper.Map<LeaseAgreement>(leaseAgreementDto);
            mapper.Map(leaseAgreementEntity, oldLeaseAgreement);
            leaseAgreementRepository.SaveChanges();
            this.loggerService.LogMessage("Lease agreement is updated successfully", "Update", LogLevel.Information);
            return Ok(mapper.Map<LeaseAgreementDto>(oldLeaseAgreement));
        }

        [HttpDelete("{leaseAgreementId}")]
        public ActionResult<String> DeleteLeaseAgreement(Guid leaseAgreementId)
        {
            leaseAgreementRepository.DeleteLeaseAgreement(leaseAgreementId);
            leaseAgreementRepository.SaveChanges();
            this.loggerService.LogMessage("Leaase agreement is deleted successfully", "Delete", LogLevel.Information);
            return Ok("Deleted");
        }

    }
}
