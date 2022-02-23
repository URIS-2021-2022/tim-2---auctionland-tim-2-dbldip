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
    /// <summary>
    /// Kontroler za komisije
    /// </summary>
    [ApiController]
    [Route("api/commissions")]
    public class CommissionController : ControllerBase
    {
        private readonly ICommissionRepository commissionRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor kontrolera komisije - DI
        /// </summary>
        /// <param name="commissionRepository">Repository komisije</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="link">Link generator za create zahtev</param>
        /// <param name="loggerService">Logger servis</param>
        public CommissionController(ICommissionRepository commissionRepository, IMapper mapper, LinkGenerator link, ILoggerService loggerService)
        {
            this.commissionRepository = commissionRepository;
            this.mapper = mapper;
            this.linkGenerator = link;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve komisije
        /// </summary>
        /// <returns>Lista fizičkih lica</returns>
        /// <response code="200">Vraća listu komisija</response>
        /// <response code="404">Nije pronađena ni jedna komisija</response>
        /// 
        [HttpGet]
        public ActionResult<List<CommissionsFilledDto>> GetCommissions()
        {
            var commissions = commissionRepository.GetCommissions();
            if (commissions.Count == 0 || commissions == null)
            {
                this.loggerService.LogMessage("List of commissions is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of commissions is returned", "Get", LogLevel.Information);
            return Ok(commissions);
        }

        /// <summary>
        /// Vraća jednu komisiju osnovu ID-a
        /// </summary>
        /// <param name="commissionId">ID komisije</param>
        /// <returns>Komisija</returns>
        /// <response code="200">Vraća tražena komisija</response>
        /// <response code="404">Nije pronađena komisija za uneti ID</response>
        /// 
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

        /// <summary>
        /// Kreira novu komisiju
        /// </summary>
        /// <param name="commissionDto">Model komisija</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove komisije \
        /// POST /api/commission \
        /// {
        ///     "president": {
        ///     "personId": "0d63898d-f929-4ba6-b676-cf9ce3ef4ae7",
        ///     "name": "Milan",
        ///     "surname": "Novcic",
        ///     "role": "Minstar"
        /// },
        ///     "members": [
        ///     {
        ///         "commissionId": "949506c9-bb02-4f6b-8026-07b33e3e6722",
        ///         "personId": "1499bf05-df8c-465d-895c-bcc5633a40dd"
        ///     }
        ///     ]
        /// }
        /// </remarks>
        /// <returns>Potvrda o kreiranju komisije</returns>
        /// <response code="201">Vraća kreiranu komisiju</response>
        /// <response code="500">Desila se greška prilikom unosa nove komisije</response>
        /// 
        [HttpPost]
        public ActionResult<CommissionConfirmationDto> CreateCommission([FromBody]CommissionCreationDto commissionDto)
        {
            try
            {
                var commission = mapper.Map<Commission>(commissionDto);
                var confirmation = commissionRepository.CreateCommission(commission);
                commissionRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetCommissionById", "Commission", new { commissionId = confirmation.CommissionId });
                this.loggerService.LogMessage("Commission successfully created", "Post", LogLevel.Information);
                return Created(location, mapper.Map<CommissionConfirmationDto>(confirmation));
            }catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with creating commission", "Create", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error with creating commission");
            }
        }

        /// <summary>
        /// Brisanje komisije na osnovu ID-a
        /// </summary>
        /// <param name="commissionId">ID komisije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Komisija je uspešno obrisana</response>
        /// <response code="404">Nije pronađena komisija za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja komisije</response>
        /// 
        [HttpDelete("{commissionId}")]
        public IActionResult DeleteCommission(Guid commissionId)
        {
           try {
                var commission = commissionRepository.GetCommissionById(commissionId);
                if(commission == null)
                {
                    this.loggerService.LogMessage("There is no commission with that id", "Get", LogLevel.Warning);
                    return NotFound();
                }
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

        /// <summary>
        /// Modifikacija komisije
        /// </summary>
        /// <param name="commission">Update model komisije</param>
        /// <returns>Potvrda o modifikaciji komisije</returns>
        /// <response code="200">Izmenjena komisija</response>
        /// <response code="404">Nije pronađena komisija za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije komisije</response>
        ///
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
                commissionRepository.UpdateMembers(commissionEntity.Members, oldCommission.CommissionId);
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
