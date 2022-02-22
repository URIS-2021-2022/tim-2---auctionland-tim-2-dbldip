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
    [Route("api/leaseAgreement/documentAuthor")]
    public class DocumentAuthorController : ControllerBase
    {
        private readonly IDocumentAuthorRepository documentAuthorRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public DocumentAuthorController(IDocumentAuthorRepository documentAuthorRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.documentAuthorRepository = documentAuthorRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }
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
