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
    /// <summary>
    /// Kontroler za učesnika ugovora
    /// </summary>
    [ApiController]
    [Route("api/leaseAgreement/contractParty")]
    public class ContractPartyController : ControllerBase
    {
        private readonly IContractPartyRepository contractPartyRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor učesnika ugovora - DI
        /// </summary>
        /// <param name="contractPartyRepository">Repository oglasa/param>
        /// <param name="linkGenerator">Link generator za učesnika ugovora</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public ContractPartyController(IContractPartyRepository contractPartyRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.contractPartyRepository = contractPartyRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve učesnike ugovora
        /// </summary>
        /// <returns>Lista učesnika ugovora</returns>
        /// <response code="200">Vraća listu učesnika ugovora</response>
        /// <response code="404">Nije pronađen ni jedan učesnik ugovora</response>
        /// 
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

        /// <summary>
        /// Vraća jednog učesnika ugovora na osnovu ID-a
        /// </summary>
        /// <param name="contractPartyId">ID učesnika ugovora</param>
        /// <returns>Učesnik ugovora</returns>
        /// <response code="200">Vraća učesnika ugovora</response>
        /// <response code="404">Nije pronađen učesnik ugovora za uneti ID</response>
        ///
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

        /// <summary>
        /// Kreira novog učesnika ugovora
        /// </summary>
        /// <param name="contractPartyDto">Model učesnika ugovora</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog učesnika ugovora \
        /// POST /api/leaseAgreement/contractParty \
        /// {   
        ///     "contractPartyId": "f84a055c-7ae0-44e7-9207-c3bb66deb14a", \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju učesnika ugovora</returns>
        /// <response code="201">Vraća kreiranog učesnika ugovora</response>
        /// <response code="500">Desila se greška prilikom unosa novog učesnika ugovora</response>
        ///
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

        /// <summary>
        /// Modifikacija učesnika ugovora
        /// </summary>
        /// <param name="contractPartyDto">Model učesnik ugovoa</param>
        /// <returns>Potvrda o modifikaciji učesnika ugovora</returns>
        /// <response code="200">Izmenjen učesnik ugovora</response>
        /// <response code="404">Nije pronađen učesnik ugovora za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije učesnika ugovora</response>
        ///
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

        /// <summary>
        /// Brisanje učesnika ugovora na osnovu ID-a
        /// </summary>
        /// <param name="contractPartyId">ID učesnika ugovora</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Učesnika ugovora je uspešno obrisan</response>
        /// <response code="404">Nije pronađen učesnik ugovora za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja učesnika ugovora</response>
        /// 
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
