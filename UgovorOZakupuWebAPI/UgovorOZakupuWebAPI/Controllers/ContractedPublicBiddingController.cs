using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Controllers
{
    [ApiController]
    [Route("api/lease-agreement/contracted-public-bidding")]
    public class ContractedPublicBiddingController : ControllerBase
    {
        private readonly IContractedPublicBiddingRepository contractedPublicBiddingRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ContractedPublicBiddingController(IContractedPublicBiddingRepository contractedPublicBiddingRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.contractedPublicBiddingRepository = contractedPublicBiddingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ContractedPublicBiddingDto>> GetContractedPublicBiddings()
        {
            var contractedPublicBiddings = contractedPublicBiddingRepository.GetContractedPublicBiddings();
            if(contractedPublicBiddings == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ContractedPublicBiddingDto>>(contractedPublicBiddings));
        }

        [HttpGet("{contractedPublicBiddingId}")]
        public ActionResult<ContractedPublicBiddingDto> GetContractedPublicBiddingById(Guid contractedPublicBiddingId)
        {
            var contractedPublicBidding = contractedPublicBiddingRepository.GetContractedPublicBiddingById(contractedPublicBiddingId);
            if (contractedPublicBidding == null)
            {
                return NoContent();
            }
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

                string location = linkGenerator.GetPathByAction("GetContractedPublicBidding", " ContractedPublicBidding", new { contractedPublicBiddingId = confirmation.ContractedPublicBiddingId });

                return Created(location, mapper.Map<ContractedPublicBiddingConfirmationDto>(confirmation));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {e}");
            }
        }

        [HttpPut]
        public ActionResult<ContractedPublicBiddingDto> UpdateContractedPublicBidding([FromBody] ContractedPublicBiddingDto contractedPublicBiddingDto)
        {
            var oldContractedPublicBidding = contractedPublicBiddingRepository.GetContractedPublicBiddingById(contractedPublicBiddingDto.ContractedPublicBiddingId);
            if (oldContractedPublicBidding == null)
            {
                return NotFound();
            }
            ContractedPublicBidding contractedPublicBiddingEntity = mapper.Map<ContractedPublicBidding>(contractedPublicBiddingDto);
            mapper.Map(contractedPublicBiddingEntity, oldContractedPublicBidding);
            contractedPublicBiddingRepository.SaveChanges();
            return Ok(mapper.Map<ContractedPublicBiddingDto>(oldContractedPublicBidding));
        }

        [HttpDelete("{contractedPublicBiddingId}")]
        public IActionResult DeleteContractedPublicBidding(Guid contractedPublicBiddingId)
        {
            try
            {
                var contractedPublicBiddingToDelete = contractedPublicBiddingRepository.GetContractedPublicBiddingById(contractedPublicBiddingId);
                if (contractedPublicBiddingToDelete == null)
                    return NotFound();
                contractedPublicBiddingRepository.DeleteContractedPublicBidding(contractedPublicBiddingId);
                contractedPublicBiddingRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
