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
    /// Kontroler za ugovoreno javno nadmetanje
    /// </summary>
    [ApiController]
    [Route("api/leaseAgreement/contractedPublicBidding")]
    public class ContractedPublicBiddingController : ControllerBase
    {
        private readonly IContractedPublicBiddingRepository contractedPublicBiddingRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;


        /// <summary>
        /// Konstruktor za ugovoreno javno nadmetanje - DI
        /// </summary>
        /// <param name="contractedPublicBiddingRepository">Repository oglasa/param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public ContractedPublicBiddingController(IContractedPublicBiddingRepository contractedPublicBiddingRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.contractedPublicBiddingRepository = contractedPublicBiddingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sva ugovorena javna nadmetanja
        /// </summary>
        /// <returns>Lista oglasa</returns>
        /// <response code="200">Vraća listu ugovorenih javnih nadmetanja</response>
        /// <response code="404">Nije pronađeno ni jedno ugovoreno javno nadmetanje</response>
        /// 
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

        /// <summary>
        /// Vraća jedno ugovoreno javno nadmetanje na osnovu ID-a
        /// </summary>
        /// <param name="contractedPublicBiddingId">ID oglasa</param>
        /// <returns>Ugovoreno javno nadmetanje</returns>
        /// <response code="200">Vraća traženo ugovoreno javno nadmetanje</response>
        /// <response code="404">Nije pronađno ni jedno javno nadmetanje za dati ID</response>
        ///
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

        /// <summary>
        /// Kreira novo ugovoreno javno nadmetanje
        /// </summary>
        /// <param name="contractedPublicBiddingDto">Model za ugovoreno javno nadmetanje</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog oglasa \
        /// POST /api/leaseAgreement/contractedPublicBidding \
        /// {   
        ///     "additionalInfo": "Sto pre." \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju ugovorenog javnog nadmetanja</returns>
        /// <response code="201">Vraća kreirano ugovoreno javno nadmetanje</response>
        /// <response code="500">Desila se greška prilikom unosa novog ugovorenog javnog nadmetanja</response>
        ///
        [Consumes("application/json")]
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

        /// <summary>
        /// Modifikacija ugovorenog javnog nadmetanja
        /// </summary>
        /// <param name="contractedPublicBiddingDto">Model ugovorenog javnog nadmetanja</param>
        /// <returns>Potvrda o modifikaciji ugovorenog javnog nadmetanja</returns>
        /// <response code="200">Izmenjeno ugovoreno javno nadmetanje</response>
        /// <response code="404">Nije pronađeno ugovoreno javno nadmetanje za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije ugovorenog javnog nadmetanja</response>
        ///
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

        /// <summary>
        /// Brisanje oglasa na osnovu ID-a
        /// </summary>
        /// <param name="contractedPublicBiddingId">ID oglasa</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ugovoreno javno nadmetanje je uspešno obrisano</response>
        /// <response code="404">Nije pronađeno ugovoreno javno nadmetanje za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja ugovorenog javnog nadmetanja</response>
        /// 
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
