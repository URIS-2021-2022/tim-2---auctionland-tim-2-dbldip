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
    [Route("api/lease-agreement/contract-party")]
    public class ContractPartyController : ControllerBase
    {
        private readonly IContractPartyRepository contractPartyRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ContractPartyController(IContractPartyRepository contractPartyRepository , LinkGenerator linkGenerator, IMapper mapper)
        {
            this.contractPartyRepository = contractPartyRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ContractPartyDto>> GetContractParties()
        {
            var contractParties = contractPartyRepository.GetContractParties();
            if (contractParties == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ContractPartyDto>>(contractParties));
        }

        [HttpGet("{contractPartyId}")]
        public ActionResult<ContractPartyDto> GetContractPartyById(Guid contractPartyId)
        {
            var contractParty = contractPartyRepository.GetContractPartyById(contractPartyId);
            if (contractParty == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<ContractPartyDto>(contractParty));
        }

        [HttpPost]
        public ActionResult<ContractPartyConfirmationDto> CreateContractParty([FromBody] ContractPartyDto contractPartyDto)
        {
            try
            {
                ContractParty contractParty = mapper.Map<ContractParty>(contractPartyDto);
                ContractPartyConfirmation confirmation = contractPartyRepository.CreateContractParty(contractParty);
                contractPartyRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetContractParty", "ContractParty", new { contractPartyId = confirmation.ContractPartyId });

                return Created(location, mapper.Map<ContractPartyConfirmationDto>(confirmation));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {e}");
            }
        }

        [HttpPut]
        public ActionResult<ContractPartyDto> UpdateContractParty([FromBody] ContractPartyDto contractPartyDto)
        {
            var oldContractParty = contractPartyRepository.GetContractPartyById(contractPartyDto.ContractPartyId);
            if (oldContractParty == null)
            {
                return NotFound();
            }
            ContractParty contractPartyEntity = mapper.Map<ContractParty>(contractPartyDto);
            mapper.Map(contractPartyEntity, oldContractParty);
            contractPartyRepository.SaveChanges();
            return Ok(mapper.Map<ContractPartyDto>(oldContractParty));
        }

        [HttpDelete("{contractPartyId}")]
        public IActionResult DeleteContractParty(Guid contractPartyId)
        {
            try
            {
                var contractPartyToDelete = contractPartyRepository.GetContractPartyById(contractPartyId);
                if (contractPartyToDelete == null)
                    return NotFound();
                contractPartyRepository.DeleteContractParty(contractPartyId);
                contractPartyRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
