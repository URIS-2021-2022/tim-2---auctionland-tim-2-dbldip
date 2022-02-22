using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;
using UgovorOZakupuWebAPI.ServiceCalls;

namespace UgovorOZakupuWebAPI.Controllers
{
    [ApiController]
    [Route("api/leaseAgreement/contractParty")]
    public class ContractPartyController : ControllerBase
    {
        private readonly IContractPartyRepository contractPartyRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public ContractPartyController(IContractPartyRepository contractPartyRepository , LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.contractPartyRepository = contractPartyRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<ContractPartyDto>> GetContractParties()
        {
            var contractParties = contractPartyRepository.GetContractParties();
            if (contractParties == null || contractParties.Count == 0)
            {
                this.loggerService.LogMessage("List of contract parties is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of contract parties is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<ContractPartyDto>>(contractParties));
        }

        [HttpGet("{contractPartyId}")]
        public ActionResult<ContractPartyDto> GetContractPartyById(Guid contractPartyId)
        {
            var contractParty = contractPartyRepository.GetContractPartyById(contractPartyId);
            if (contractParty == null)
            {
                this.loggerService.LogMessage("There is no contract party with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Contract party is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<ContractPartyDto>(contractParty));
        }

        [HttpPost]
        public ActionResult<ContractPartyConfirmationDto> CreateContractParty(ContractPartyDto contractPartyDto)
        {
            try
            {
                ContractParty contractParty = mapper.Map<ContractParty>(contractPartyDto);
                ContractPartyConfirmation confirmation = contractPartyRepository.CreateContractParty(contractParty);
                contractPartyRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetContractPartyById", "ContractParty", new { contractPartyId = confirmation.ContractPartyId });
                this.loggerService.LogMessage("Contract party is created successfully", "Post", LogLevel.Information);
                return Created(location, mapper.Map<ContractPartyConfirmationDto>(confirmation));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with creating contract party", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {exception}");
            }
        }

        [HttpPut]
        public ActionResult<ContractPartyDto> UpdateContractParty(ContractPartyDto contractPartyDto)
        {
            try
            {
                var oldContractParty = contractPartyRepository.GetContractPartyById(contractPartyDto.ContractPartyId);
                if (oldContractParty == null)
                {
                    this.loggerService.LogMessage("There is no contract party with that id", "Update", LogLevel.Warning);
                    return NotFound();
                }
                ContractParty contractPartyEntity = mapper.Map<ContractParty>(contractPartyDto);
                mapper.Map(contractPartyEntity, oldContractParty); //update
                contractPartyRepository.SaveChanges();
                this.loggerService.LogMessage("Contract party update successfully", "Update", LogLevel.Information);
                return Ok(mapper.Map<ContractPartyDto>(oldContractParty));
            }

            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with update contract party", "Update", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        [HttpDelete("{contractPartyId}")]
        public IActionResult DeleteContractParty(Guid contractPartyId)
        {
            try
            {
                var contractPartyToDelete = contractPartyRepository.GetContractPartyById(contractPartyId);
                if (contractPartyToDelete == null)
                {
                    this.loggerService.LogMessage("There is no contract party with that id", "Delete", LogLevel.Warning);
                    return NotFound();
                }
                contractPartyRepository.DeleteContractParty(contractPartyId);
                contractPartyRepository.SaveChanges();
                this.loggerService.LogMessage("Contract party is deleted successfully", "Delete", LogLevel.Warning);
                return NoContent();
            }
            catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting contract party", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
