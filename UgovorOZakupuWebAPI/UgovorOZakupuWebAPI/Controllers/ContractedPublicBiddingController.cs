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
    [Route("api/leaseAgreement/contractedPublicBidding")]
    public class ContractedPublicBiddingController : ControllerBase
    {
        private readonly IContractedPublicBiddingRepository contractedPublicBiddingRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public ContractedPublicBiddingController(IContractedPublicBiddingRepository contractedPublicBiddingRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.contractedPublicBiddingRepository = contractedPublicBiddingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<ContractedPublicBiddingDto>> GetContractedPublicBiddings()
        {
            var contractedPublicBiddings = contractedPublicBiddingRepository.GetContractedPublicBiddings();
            if(contractedPublicBiddings == null || contractedPublicBiddings.Count == 0)
            {
                this.loggerService.LogMessage("List of contracted public biddings is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of contracted public biddings is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<ContractedPublicBiddingDto>>(contractedPublicBiddings));
        }

        [HttpGet("{contractedPublicBiddingId}")]
        public ActionResult<ContractedPublicBiddingDto> GetContractedPublicBiddingById(Guid contractedPublicBiddingId)
        {
            var contractedPublicBidding = contractedPublicBiddingRepository.GetContractedPublicBiddingById(contractedPublicBiddingId);
            if (contractedPublicBidding == null)
            {
                this.loggerService.LogMessage("There is no contracted public bidding with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Contracted public bidding is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<ContractedPublicBiddingDto>(contractedPublicBidding));
        }

        [HttpPost]
        public ActionResult<ContractedPublicBiddingConfirmationDto> CreateContractedPublicBidding([FromBody] ContractedPublicBiddingDto contractedPublicBiddingDto)
        {
            try
            {
                ContractedPublicBidding contractedPublicBidding = mapper.Map<ContractedPublicBidding>(contractedPublicBiddingDto);
                ContractedPublicBiddingConfirmation confirmation = contractedPublicBiddingRepository.CreateContractedPublicBidding(contractedPublicBidding);
                contractedPublicBiddingRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetContractedPublicBiddingById", "ContractedPublicBidding", new { contractedPublicBiddingId = confirmation.ContractedPublicBiddingId });
                this.loggerService.LogMessage("Contracted public bidding is created", "Post", LogLevel.Information);
                return Created(location, mapper.Map<ContractedPublicBiddingConfirmationDto>(confirmation));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with creating contracted public bidding", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {exception}");
            }
        }

        [HttpPut]
        public ActionResult<ContractedPublicBiddingDto> UpdateContractedPublicBidding([FromBody] ContractedPublicBiddingDto contractedPublicBiddingDto)
        {
            try
            {
                var oldContractedPublicBidding = contractedPublicBiddingRepository.GetContractedPublicBiddingById(contractedPublicBiddingDto.ContractedPublicBiddingId);
                if (oldContractedPublicBidding == null)
                {
                    this.loggerService.LogMessage("There is no contracted public bidding with that id", "Update", LogLevel.Warning);
                    return NotFound();
                }
                ContractedPublicBidding contractedPublicBiddingEntity = mapper.Map<ContractedPublicBidding>(contractedPublicBiddingDto);
                mapper.Map(contractedPublicBiddingEntity, oldContractedPublicBidding);
                contractedPublicBiddingRepository.SaveChanges();
                this.loggerService.LogMessage("Contracted public bidding updated successfully", "Update", LogLevel.Information);
                return Ok(mapper.Map<ContractedPublicBiddingDto>(oldContractedPublicBidding));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with updating contracted public bidding", "Update", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        [HttpDelete("{contractedPublicBiddingId}")]
        public IActionResult DeleteContractedPublicBidding(Guid contractedPublicBiddingId)
        {
            try
            {
                var contractedPublicBiddingToDelete = contractedPublicBiddingRepository.GetContractedPublicBiddingById(contractedPublicBiddingId);
                if (contractedPublicBiddingToDelete == null)
                {
                    this.loggerService.LogMessage("There is no contracted public bidding with that id", "Delete", LogLevel.Warning);
                    return NotFound();
                }
                contractedPublicBiddingRepository.DeleteContractedPublicBidding(contractedPublicBiddingId);
                contractedPublicBiddingRepository.SaveChanges();
                this.loggerService.LogMessage("Contracted public bidding is deleted successfully", "Delete", LogLevel.Warning);
                return NoContent();
            }
            catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting contracted public bidding", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
