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

        /// <summary>
        /// BuyerController constructor
        /// </summary>
        /// <param name="authorizedPersonRepository">Application repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        ///  /// <param name="loggerService">Logger Service</param>
        public AuthorizedPersonController(IAuthorizedPersonRepository authorizedPersonRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.authorizedPersonRepository = authorizedPersonRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }


        /// <summary>
        /// Return all authorized people
        /// </summary>
        /// <returns>List of authorized people</returns>
        /// <response code="200">Returns all authorized people</response>
        /// <response code="404">No authorized person found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

        /// <summary>
        /// Returns AuthorizedPerson by ID
        /// </summary>
        /// <param name="authorizedPersonId">AuthorizedPerson ID</param>
        /// <returns>Application</returns>
        /// <response code="200">Returns AuthorizedPerson by ID</response>
        /// <response code="404">No AuthorizedPerson by ID found</response>
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

        /// <summary>
        /// Create new  AuthorizedPerson
        /// </summary>
        /// <param name="authorizedPerson">Creation  AuthorizedPerson DTO</param>
        /// <returns>Confirmation of created  AuthorizedPerson</returns>
        /// <response code="201">Returns confirmation of created  AuthorizedPerson</response>
        /// <response code="500"> AuthorizedPerson creation error</response>
        [HttpPost]
        public ActionResult<AuthorizedPersonConfirmationDto> CreateBuyer([FromBody] AuthorizedPersonCreationDto authorizedPerson)
        {
            AuthorizedPersonCreation authorizedPersonToCreate = mapper.Map<AuthorizedPersonCreation>(authorizedPerson);
            AuthorizedPersonConfirmation confirmation = authorizedPersonRepository.CreateAuthorizedPerson(authorizedPersonToCreate);
            authorizedPersonRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetAuthorizedPersonById", controller: "AuthorizedPerson", values: new { authorizedPersonId = confirmation.authorizedPersonId });

            this.loggerService.LogMessage("Authorized person is created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<AuthorizedPersonConfirmationDto>(confirmation));
        }

        /// <summary>
        /// AuthorizedPerson modify
        /// </summary>
        /// <param name="authorizedPerson">Update AuthorizedPerson DTO</param>
        /// <returns>Confirmation of updated AuthorizedPerson</returns>
        /// <response code="200">Returns confirmation of updated AuthorizedPerson</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found AuthorizedPerson by ID</response>
        /// <response code="500">Server error</response>
        [HttpPut]
        public ActionResult<AuthorizedPersonConfirmationDto> UpdateAuthorizedPerson(AuthorizedPersonUpdateDto authorizedPerson)
        {
            try
            {
                var authorizedPersonOld = mapper.Map<AuthorizedPersonWithoutLists>(authorizedPersonRepository.GetAuthorizedPerson(authorizedPerson.authorizedPersonId));
                if (authorizedPersonOld == null)
                {
                    this.loggerService.LogMessage("Authorized person can't be updated!", "Put", LogLevel.Warning);

                    return NoContent();
                }
                authorizedPersonRepository.UpdateAuthorizedPerson(mapper.Map<AuthorizedPersonUpdate>(authorizedPerson));
                authorizedPersonRepository.SaveChanges();
                this.loggerService.LogMessage("Authorized person is updated", "Put", LogLevel.Information);

                return Ok("Changed!");
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with updating authorized person", "Delete", LogLevel.Error, exception);

                return Conflict("ERROR: " + exception.Message);
            }


        }

        /// <summary>
        /// Delete AuthorizedPerson
        /// </summary>
        /// <param name="authorizedPersonId">AuthorizedPerson ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">AuthorizedPerson deleted</response>
        /// <response code="404">AuthorizedPerson by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{authorizedPersonId}")]
        public ActionResult<String> DeleteAuthorizedPerson(Guid authorizedPersonId)
        {
            try
            {
                authorizedPersonRepository.DeleteAuthorizedPerson(authorizedPersonId);
                authorizedPersonRepository.SaveChanges();
                this.loggerService.LogMessage("Authorized person is deleted successfully!", "Delete", LogLevel.Warning);
                return NoContent();
            }
            

            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting buyer", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error with deleting buyer");
            }
        }
    }
}
