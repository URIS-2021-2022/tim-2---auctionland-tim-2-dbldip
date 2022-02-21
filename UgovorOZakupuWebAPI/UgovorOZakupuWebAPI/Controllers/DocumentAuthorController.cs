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
    [Route("api/lease-agreement/document-author")]
    public class DocumentAuthorController : ControllerBase
    {
        private readonly IDocumentAuthorRepository documentAuthorRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public DocumentAuthorController(IDocumentAuthorRepository documentAuthorRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<DocumentAuthorDto>> GetDocumentAuthors()
        {
            var documentAuthors = documentAuthorRepository.GetDocumentAuthors();
            if (documentAuthors == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<DocumentAuthorDto>>(documentAuthors));
        }

        [HttpGet("{documentAuthorId}")]
        public ActionResult<DocumentAuthorDto> GetDocumentAuthorById(Guid documentAuthorId)
        {
            var documentAuthor = documentAuthorRepository.GetDocumentAuthorById(documentAuthorId);
            if (documentAuthor == null)
            {
                return NoContent();
            }
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

                string location = linkGenerator.GetPathByAction("GetDocumentAuthor", "DocumentAuthor", new { documentAuthorId = confirmation.DocumentAuthorId });

                return Created(location, mapper.Map<DocumentAuthorConfirmationDto>(confirmation));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {e}");
            }
        }

        [HttpPut]
        public ActionResult<DocumentAuthorDto> UpdateDocumentAuthor([FromBody] DocumentAuthorDto documentAuthorDto)
        {
            var oldDocumentAuthor = documentAuthorRepository.GetDocumentAuthorById(documentAuthorDto.DocumentAuthorId);
            if (oldDocumentAuthor == null)
            {
                return NotFound();
            }
            DocumentAuthor documentAuthorEntity = mapper.Map<DocumentAuthor>(documentAuthorDto);
            mapper.Map(documentAuthorEntity, oldDocumentAuthor);
            documentAuthorRepository.SaveChanges();
            return Ok(mapper.Map<DocumentDto>(oldDocumentAuthor));
        }

        [HttpDelete("{documentAuthorId}")]
        public IActionResult DeleteDocumentAuthor(Guid documentAuthorId)
        {
            try
            {
                var documentAuthorToDelete = documentAuthorRepository.GetDocumentAuthorById(documentAuthorId);
                if (documentAuthorToDelete == null)
                    return NotFound();
                documentAuthorRepository.DeleteDocumentAuthor(documentAuthorId);
                documentAuthorRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
