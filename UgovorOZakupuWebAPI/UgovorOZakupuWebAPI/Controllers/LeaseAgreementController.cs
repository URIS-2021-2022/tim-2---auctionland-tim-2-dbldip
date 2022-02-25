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
    /// <summary>
    /// Kontroler za ugovor o zakupu
    /// </summary>
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/leaseAgreement")]
    public class LeaseAgreementController : ControllerBase
    {
        private readonly ILeaseAgreementRepository leaseAgreementRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor kontrolera ugovore o zakupu - DI
        /// </summary>
        /// <param name="leaseAgreementRepository">Repository ugovora u zakupu/param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public LeaseAgreementController(ILeaseAgreementRepository leaseAgreementRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.leaseAgreementRepository = leaseAgreementRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća ugovore o zakupu
        /// </summary>
        /// <returns>Lista ugovora o zakupu</returns>
        /// <response code="200">Vraća listu ugovora o zakupu</response>
        /// <response code="404">Nije pronađen ni jedan ugovor o zakupu</response>
        /// 
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

        /// <summary>
        /// Vraća jedan ugovor o zakupu na osnovu ID-a
        /// </summary>
        /// <param name="leaseAgreementId">ID oglasa</param>
        /// <returns>Ugovor o zakupu</returns>
        /// <response code="200">Vraća traženi ugovor o zakupu</response>
        /// <response code="404">Nije pronađen ugovor o zakupu za uneti ID</response>
        ///
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

        /// <summary>
        /// Kreira novi ugovor o zakupu
        /// </summary>
        /// <param name="leaseAgreementDto">Model ugovora u zakupu</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog oglasa \
        /// POST /api/leaseAgreement \
        /// {   
        ///     "serialNumber": "012392", \
        ///     "recordDate": "2022-01-31T18:32:34.4441329",\
        ///     "landReturnDeadline": "2022-01-31T18:32:34.4441329",\
        ///     "placeOfSigning": "Novi Sad", \
        ///     "dateOfSigning": "2022-01-31T18:32:34.4441329", \
        ///     "contractedPublicBidding": { "additionalInfo": "Sto pre."}, \
        ///     "contractParty":{}, \
        ///     "guaranteeType": {"type": "Žirantska"}, \
        ///     "decision": {  \
        ///         "fileNumber": "File002",\
        ///         "date": null,
        ///         "documentAdoptionDate": null, \
        ///         "template": "template2", \
        ///         "documentAuthor" : { \
        ///             "agencyInfo": "Agencija zaa zavod 025" \
        ///             } \
        ///      }, \
        ///      "maturityDeadlines" : [ \
        ///      { \
        ///          "maturityDeadlineId": "4546fd1d-aebf-4423-9d11-0a5908ce1aa8", \ \
        ///          "deadline": 1 \
        ///      } \
        ///      ] \ 
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju ugovora o zakupu</returns>
        /// <response code="201">Vraća kreirani ugovor o zakupu</response>
        /// <response code="500">Desila se greška prilikom unosa novog ugovora o zakupu</response>
        ///
        [HttpPost]
        public ActionResult<LeaseAgreementConfirmationDto> CreateLeaseAgreement(LeaseAgreementCreationDto leaseAgreementDto)
        {
           // try
           // {
                LeaseAgreement leaseAgreement = mapper.Map<LeaseAgreement>(leaseAgreementDto);
                LeaseAgreementConfirmation confirmation = leaseAgreementRepository.CreateLeaseAgreement(leaseAgreement);
                leaseAgreementRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetLeaseAgreementById", "LeaseAgreement", new { leaseAgreementId = confirmation.LeaseAgreementId });
                this.loggerService.LogMessage("Lease agreement is created successfully", "Post", LogLevel.Information);
                return Created(location, mapper.Map<LeaseAgreementConfirmationDto>(confirmation));
           // }
           // catch (Exception exception)
            //{
               // this.loggerService.LogMessage("Error with creating lease agreement", "Post", LogLevel.Error, exception);
               // return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {exception}");
            //}
        }

        /// <summary>
        /// Modifikacija ugovora o zakupu
        /// </summary>
        /// <param name="leaseAgreementDto">Model ugovora o zakupu</param>
        /// <returns>Potvrda o modifikaciji ugovora o zakupu</returns>
        /// <response code="200">Izmenjen ugovor o zakupu</response>
        /// <response code="404">Nije pronađen ugovor o zakupu za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije ugovora o zakupu</response>
        ///
        [HttpPut]
        public ActionResult<LeaseAgreementDto> UpdateLeaseAgreement(LeaseAgreementUpdateDto leaseAgreementDto)
        {
            try
            {
                var oldLeaseAgreement = leaseAgreementRepository.GetLeaseAgreementById(leaseAgreementDto.LeaseAgreementId);
                if (oldLeaseAgreement == null)
                {
                    this.loggerService.LogMessage("There is no lease agreement with that id", "Update", LogLevel.Warning);
                    return NotFound();
                }
                LeaseAgreement leaseAgreementEntity = mapper.Map<LeaseAgreement>(leaseAgreementDto);
                leaseAgreementRepository.UpdateMaturityDeadlines(leaseAgreementEntity.MaturityDeadlines, oldLeaseAgreement.LeaseAgreementId);
                leaseAgreementEntity.LeaseAgreementId = oldLeaseAgreement.LeaseAgreementId;
                mapper.Map(leaseAgreementEntity, oldLeaseAgreement);
                leaseAgreementRepository.SaveChanges();
                this.loggerService.LogMessage("Lease agreement is updated successfully", "Update", LogLevel.Information);
                return Ok(mapper.Map<LeaseAgreementDto>(leaseAgreementEntity));
            }
            catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with updating lease agreement", "Update", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }

        }

        /// <summary>
        /// Brisanje ugovora o zakupu na osnovu ID-a
        /// </summary>
        /// <param name="leaseAgreementId">ID ugovora o zakupu</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ugovor o zakupu je uspešno obrisan</response>
        /// <response code="404">Nije pronađen ugovor o zakupu za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja ugovora o zakupu</response>
        /// 
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
