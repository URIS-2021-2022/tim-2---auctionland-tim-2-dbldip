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
    [Route("api/lease-agreement/document")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public DocumentController(IDocumentRepository documentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.documentRepository = documentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<DocumentDto>> GetDocuments(string fileNumber)
        {
            var documents = documentRepository.GetDocuments(fileNumber);
            if (documents == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<DocumentDto>>(documents));
        }

        [HttpGet("{documentId}")]
        public ActionResult<DocumentDto> GetDocumentById(Guid documentId)
        {
            var document = documentRepository.GetDocumentById(documentId);
            if( document == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<DocumentDto>(document));
        }

        [HttpPost]
        public ActionResult<DocumentConfirmationDto> CreateDocument([FromBody]DocumentDto documentDto)
        {
            try
            {
                Document document = mapper.Map<Document>(documentDto);
                DocumentConfirmation confirmation = documentRepository.CreateDocument(document);
                documentRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetDocument", "Document", new { documentId = confirmation.DocumentId });

                return Created(location, mapper.Map<DocumentConfirmationDto>(confirmation));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {e}");
            }
        }

        [HttpPut]
        public ActionResult<DocumentDto> UpdateDocument([FromBody]DocumentDto documentDto)
        {
            var oldDocument = documentRepository.GetDocumentById(documentDto.DocumentId);
            if(oldDocument == null)
            {
                return NotFound();
            }
            Document documentEntity = mapper.Map<Document>(documentDto);
            mapper.Map(documentEntity, oldDocument);
            documentRepository.SaveChanges();
            return Ok(mapper.Map<DocumentDto>(oldDocument));
        }

        [HttpDelete("{documentId}")]
        public IActionResult DeleteDocument(Guid documentId)
        {
            try
            {
                var documentToDelete = documentRepository.GetDocumentById(documentId);
                if (documentToDelete == null)
                    return NotFound();
                documentRepository.DeleteDocument(documentId);
                documentRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }  
    }
}
