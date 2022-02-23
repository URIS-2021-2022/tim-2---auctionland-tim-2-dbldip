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
    /// Kontroler za dokument
    /// </summary>
    [ApiController]
    [Route("api/leaseAgreement/document")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor dokumenta - DI
        /// </summary>
        /// <param name="documentRepository">Repository dokumenta/param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public DocumentController(IDocumentRepository documentRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.documentRepository = documentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve dokumente
        /// </summary>
        /// <returns>Lista dokumenata</returns>
        /// <response code="200">Vraća listu dokumenata</response>
        /// <response code="404">Nije pronađen ni jedan dokument</response>
        /// 
        [HttpGet]
        public ActionResult<List<DocumentDto>> GetDocuments(string fileNumber)
        {
            var documents = documentRepository.GetDocuments(fileNumber);
            if (documents == null)
            {
                this.loggerService.LogMessage("List of documents is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of documents is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<DocumentDto>>(documents));
        }

        /// <summary>
        /// Vraća jedan dokument na osnovu ID-a
        /// </summary>
        /// <param name="documentId">ID dokumenta</param>
        /// <returns>Dokument</returns>
        /// <response code="200">Vraća traženi dokument</response>
        /// <response code="404">Nije pronađen dokument za uneti ID</response>
        ///
        [HttpGet("{documentId}")]
        public ActionResult<DocumentDto> GetDocumentById(Guid documentId)
        {
            var document = documentRepository.GetDocumentById(documentId);
            if( document == null)
            {
                this.loggerService.LogMessage("There is no document with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Document is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<DocumentDto>(document));
        }

        /// <summary>
        /// Kreira novi dokument
        /// </summary>
        /// <param name="documentDto">Model dokument</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog oglasa \
        /// POST /api/leaseAgreement/document \
        /// {   
        ///     "fileNumber": "File001", \
        ///     "date": null, \
        ///     "documentAdoptionDate": null, \
        ///     "template": "template2", \
        ///     "documentAuthorId": "554c65b1-56af-4050-b232-c20d7197bb78" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju dokumenta</returns>
        /// <response code="201">Vraća kreirani dokument</response>
        /// <response code="500">Desila se greška prilikom unosa novog dokumenta</response>
        ///
        [HttpPost]
        public ActionResult<DocumentConfirmationDto> CreateDocument([FromBody]DocumentDto documentDto)
        {
            try
            {
                Document document = mapper.Map<Document>(documentDto);
                DocumentConfirmation confirmation = documentRepository.CreateDocument(document);
                documentRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetDocumentById", "Document", new { documentId = confirmation.DocumentId });
                this.loggerService.LogMessage("Document is created successfully", "Post", LogLevel.Information);
                return Created(location, mapper.Map<DocumentConfirmationDto>(confirmation));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with creating document", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {exception}");
            }
        }

        /// <summary>
        /// Modifikacija dokument
        /// </summary>
        /// <param name="documentDto">Model dokumenta</param>
        /// <returns>Potvrda o modifikaciji dokumenta</returns>
        /// <response code="200">Izmenjen dokument</response>
        /// <response code="404">Nije pronađen dokument za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije dokumenta</response>
        ///
        [HttpPut]
        public ActionResult<DocumentDto> UpdateDocument([FromBody]DocumentDto documentDto)
        {
            var oldDocument = documentRepository.GetDocumentById(documentDto.DocumentId);
            if(oldDocument == null)
            {
                this.loggerService.LogMessage("There is no document with that id", "Update", LogLevel.Warning);
                return NotFound();
            }
            Document documentEntity = mapper.Map<Document>(documentDto);
            mapper.Map(documentEntity, oldDocument);
            documentRepository.SaveChanges();
            this.loggerService.LogMessage("Document is updated successfully", "Update", LogLevel.Information);
            return Ok(mapper.Map<DocumentDto>(oldDocument));
        }

        /// <summary>
        /// Brisanje dokumenta na osnovu ID-a
        /// </summary>
        /// <param name=documentId">ID dokumenta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Dokument je uspešno obrisan</response>
        /// <response code="404">Nije pronađen dokument za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja dokumenta</response>
        /// 
        [HttpDelete("{documentId}")]
        public IActionResult DeleteDocument(Guid documentId)
        {
            try
            {
                var documentToDelete = documentRepository.GetDocumentById(documentId);
                if (documentToDelete == null)
                {
                    this.loggerService.LogMessage("There is no document with that id", "Delete", LogLevel.Warning);
                    return NotFound();
                }
                documentRepository.DeleteDocument(documentId);
                documentRepository.SaveChanges();
                this.loggerService.LogMessage("Document deleted successfully", "Get", LogLevel.Warning);
                return NoContent();
            }
            catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting document", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }  
    }
}
