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
    /// Kontroler za autora dokumenta
    /// </summary>
    [ApiController]
    [Route("api/leaseAgreement/documentAuthor")]
    public class DocumentAuthorController : ControllerBase
    {
        private readonly IDocumentAuthorRepository documentAuthorRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor autora dokumenta - DI
        /// </summary>
        /// <param name="documentAuthorRepository">Repository oglasa/param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        /// 
        public DocumentAuthorController(IDocumentAuthorRepository documentAuthorRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.documentAuthorRepository = documentAuthorRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća autore dokumenta
        /// </summary>
        /// <returns>Lista autora dokumenta</returns>
        /// <response code="200">Vraća listu autora dokumenta</response>
        /// <response code="404">Nije pronađen ni autor dokumenta</response>
        /// 
        [HttpGet]
        public ActionResult<List<DocumentAuthorDto>> GetDocumentAuthors()
        {
            var documentAuthors = documentAuthorRepository.GetDocumentAuthors();
            if (documentAuthors == null || documentAuthors.Count == 0)
            {
                this.loggerService.LogMessage("List of document authors is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of document authors is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<DocumentAuthorDto>>(documentAuthors));
        }

        /// <summary>
        /// Vraća jednog autora dokumenta osnovu ID-a
        /// </summary>
        /// <param name="documentAuthorId">ID autora dokumenta</param>
        /// <returns>Autor dokumenta</returns>
        /// <response code="200">Vraća traženog autora dokumenta</response>
        /// <response code="404">Nije pronađen autor dokumenta za uneti ID</response>
        ///
        [HttpGet("{documentAuthorId}")]
        public ActionResult<DocumentAuthorDto> GetDocumentAuthorById(Guid documentAuthorId)
        {
            var documentAuthor = documentAuthorRepository.GetDocumentAuthorById(documentAuthorId);
            if (documentAuthor == null)
            {
                this.loggerService.LogMessage("There is no document authors with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Document author is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<DocumentAuthorDto>(documentAuthor));
        }

        /// <summary>
        /// Kreira novog autora dokumenta
        /// </summary>
        /// <param name="documentAuthorDto">Model oglas</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog oglasa \
        /// POST /api/leaseAgreement/documentAuthor \
        /// {   
        ///     "documentAuthorId": "dea67985-ced6-4af2-a0df-fcfc21e947fe", \
        ///     "agencyInfo": "Agencija za zavod 021" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju autora dokumenta</returns>
        /// <response code="201">Vraća kreiranog autora dokumenta</response>
        /// <response code="500">Desila se greška prilikom unosa novog autora dokumenta</response>
        ///
        [HttpPost]
        public ActionResult<DocumentAuthorConfirmationDto> CreateDocument([FromBody] DocumentAuthorDto documentAuthorDto)
        {
            try
            {
                DocumentAuthor documentAuthor = mapper.Map<DocumentAuthor>(documentAuthorDto);
                DocumentAuthorConfirmation confirmation = documentAuthorRepository.CreateDocumentAuthor(documentAuthor);
                documentAuthorRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetDocumentAuthorById", "DocumentAuthor", new { documentAuthorId = confirmation.DocumentAuthorId });
                this.loggerService.LogMessage("Document author is created successfully", "Post", LogLevel.Information);
                return Created(location, mapper.Map<DocumentAuthorConfirmationDto>(confirmation));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with creating document author", "Post", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {exception}");
            }
        }

        /// <summary>
        /// Modifikacija autora dokumenta
        /// </summary>
        /// <param name="documentAuthorDto">Model autora dokumenta</param>
        /// <returns>Potvrda o modifikaciji autora dokumenta</returns>
        /// <response code="200">Izmenjen autor dokumenta</response>
        /// <response code="404">Nije pronađen autor dokumenta za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije autora dokumenta</response>
        ///
        [HttpPut]
        public ActionResult<DocumentAuthorDto> UpdateDocumentAuthor(DocumentAuthorDto documentAuthorDto)
        {
            try
            {
                var oldDocumentAuthor = documentAuthorRepository.GetDocumentAuthorById(documentAuthorDto.DocumentAuthorId);
                if (oldDocumentAuthor == null)
                {
                    this.loggerService.LogMessage("There is no document authors with that id", "Update", LogLevel.Warning);
                    return NotFound();
                }
                DocumentAuthor documentAuthorEntity = mapper.Map<DocumentAuthor>(documentAuthorDto); 
                mapper.Map(documentAuthorEntity, oldDocumentAuthor);
                documentAuthorRepository.SaveChanges();
                this.loggerService.LogMessage("Document author updated successfully", "Update", LogLevel.Information);
                return Ok(mapper.Map<DocumentAuthorDto>(oldDocumentAuthor));
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with updating document author", "Update", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Brisanje autora dokumenta na osnovu ID-a
        /// </summary>
        /// <param name="documentAuthorId">ID autora dokumenta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Autor dokumenta je uspešno obrisan</response>
        /// <response code="404">Nije pronađen autora dokumenta za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja oautora dokumenta</response>
        /// 
        [HttpDelete("{documentAuthorId}")]
        public IActionResult DeleteDocumentAuthor(Guid documentAuthorId)
        {
            try
            {
                var documentAuthorToDelete = documentAuthorRepository.GetDocumentAuthorById(documentAuthorId);
                if (documentAuthorToDelete == null)
                {
                    this.loggerService.LogMessage("There is no document author with that id", "Delete", LogLevel.Warning);
                    return NotFound();
                }
                documentAuthorRepository.DeleteDocumentAuthor(documentAuthorId);
                documentAuthorRepository.SaveChanges();
                this.loggerService.LogMessage("Document author is deleted successfully", "Delete", LogLevel.Warning);
                return NoContent();
            }
            catch(Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting document author", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
