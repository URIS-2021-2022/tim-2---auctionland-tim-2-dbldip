using AutoMapper;
using KupacWebApi.Data;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

        public AuthorizedPersonController(IAuthorizedPersonRepository authorizedPersonRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.authorizedPersonRepository = authorizedPersonRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<AuthorizedPersonDto>> GetBuyers()
        {
            var authorizedPeople = authorizedPersonRepository.GetAuthorizedPersons();
            if (authorizedPeople == null || authorizedPeople.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<AuthorizedPersonDto>>(authorizedPeople));
        }

        [HttpGet("{authorizedPersonId}")]
        public ActionResult<AuthorizedPersonDto> GetAuthorizedPersonById(Guid authorizedPersonId)
        {
            var authorizedPerson = authorizedPersonRepository.GetAuthorizedPerson(authorizedPersonId);
            if (authorizedPerson == null)
                return NoContent();
            return Ok(mapper.Map<AuthorizedPersonDto>(authorizedPerson));
        }

        [HttpPost]
        public ActionResult<AuthorizedPersonConfirmationDto> CreateBuyer([FromBody] AuthorizedPersonDto authorizedPerson, Guid authorizedPersonId)
        {

            AuthorizedPerson authorizedPersonCheck = authorizedPersonRepository.GetAuthorizedPerson(authorizedPersonId);
            if (authorizedPersonCheck == null)
                return NoContent();

            AuthorizedPersonCreation authorizedPersonToCreate = mapper.Map<AuthorizedPersonCreation>(authorizedPerson);
            AuthorizedPersonConfirmation confirmation = authorizedPersonRepository.CreateAuthorizedPerson(authorizedPersonToCreate);
            authorizedPersonRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetAuthorizedPerson", controller: "AuthorizedPerson", values: new { authorizedPersonId = confirmation.authorizedPersonId });
            return Created(location, mapper.Map<BuyerConfirmationDto>(confirmation));
        }

        [HttpDelete("{authorizedPersonId}")]
        public ActionResult<String> DeleteAuthorizedPerson(Guid authorizedPersonId)
        {
            authorizedPersonRepository.DeleteAuthorizedPerson(authorizedPersonId);
            authorizedPersonRepository.SaveChanges();
            return Ok("Deleted?");
        }
    }
}
