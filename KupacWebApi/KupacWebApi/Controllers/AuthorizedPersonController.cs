using AutoMapper;
using KupacWebApi.Data;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using KupacWebApi.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Controllers
{
    [ApiController]
    [Route("/api/authorizedPerson")]
    public class AuthorizedPersonController : ControllerBase
    {
        private readonly IAuthorizedPersonRepository authorizedPersonRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        public AuthorizedPersonController(IAuthorizedPersonRepository authorizedPersonRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.authorizedPersonRepository = authorizedPersonRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<AuthorizedPersonDto>> GetBuyers()
        {
            var authorizedPeople = authorizedPersonRepository.GetAuthorizedPersons();
            if (authorizedPeople == null || authorizedPeople.Count == 0)
            {
                this.loggerService.LogMessage("List of authorized people is empty", "Get", LogLevel.Warning);
                return NoContent();

            }
            this.loggerService.LogMessage("List of authorized people is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<AuthorizedPersonDto>>(authorizedPeople));
        }

        [HttpGet("{authorizedPersonId}")]
        public ActionResult<AuthorizedPersonDto> GetAuthorizedPersonById(Guid authorizedPersonId)
        {
            var authorizedPerson = authorizedPersonRepository.GetAuthorizedPerson(authorizedPersonId);
            if (authorizedPerson == null)
            {
                this.loggerService.LogMessage("There is no authorized person with that id", "Get", LogLevel.Warning);
                return NoContent();

            }
            this.loggerService.LogMessage("Authorized person is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<AuthorizedPersonDto>(authorizedPerson));
        }

        [HttpPost]
        public ActionResult<AuthorizedPersonConfirmationDto> CreateBuyer([FromBody] AuthorizedPersonCreationDto authorizedPerson)
        {

            /*AuthorizedPerson authorizedPersonCheck = authorizedPersonRepository.GetAuthorizedPerson(authorizedPersonId);
            if (authorizedPersonCheck == null)
            {
                this.loggerService.LogMessage("There is no authorized person with that id", "Post", LogLevel.Warning);
                return NoContent();

            }*/

            AuthorizedPersonCreation authorizedPersonToCreate = mapper.Map<AuthorizedPersonCreation>(authorizedPerson);
            AuthorizedPersonConfirmation confirmation = authorizedPersonRepository.CreateAuthorizedPerson(authorizedPersonToCreate);
            authorizedPersonRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetAuthorizedPersonById", controller: "AuthorizedPerson", values: new { authorizedPersonId = confirmation.authorizedPersonId });

            this.loggerService.LogMessage("Authorized person is created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<AuthorizedPersonConfirmationDto>(confirmation));
        }

        [HttpDelete("{authorizedPersonId}")]
        public ActionResult<String> DeleteAuthorizedPerson(Guid authorizedPersonId)
        {
            try
            {
                authorizedPersonRepository.DeleteAuthorizedPerson(authorizedPersonId);
                authorizedPersonRepository.SaveChanges();
                this.loggerService.LogMessage("Authorized person is deleted successfully!", "Delete", LogLevel.Warning);
                return Ok("Deleted?");
            }
            

            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting buyer", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error with deleting buyer");
            }
        }
    }
}
