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
using Microsoft.Extensions.Logging;
using CommissionWebAPI.ServiceCalls;

namespace CommissionWebAPI.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;

        public PersonController(IPersonRepository personRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetPersons(string name, string surname, string role)
        {
            var persons = personRepository.GetPersons(name, surname, role);
            if (persons.Count == 0 || persons == null)
            {
                this.loggerService.LogMessage("List of persons is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of persons is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PersonDto>>(persons));
        }

        [HttpGet("{personId}")]
        public ActionResult<PersonDto> GetPersonById(Guid personId)
        {
            Person personModel = personRepository.GetPersonById(personId);
            if (personModel == null)
            {
                this.loggerService.LogMessage("There is no person with that id", "Get", LogLevel.Warning);
                return NotFound();
            }
            this.loggerService.LogMessage("Person is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<PersonDto>(personModel));
        }

        [HttpPost]
        public ActionResult<PersonConfirmationDto> CreatePerson(PersonCreationDto personDto)
        {
            try
            {
                Person person = mapper.Map<Person>(personDto);
                PersonConfirmation confirmation = personRepository.CreatePerson(person);
                personRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetPersonById", "Person", new { personId = confirmation.PersonId });
                this.loggerService.LogMessage("Commission successfully created", "Post", LogLevel.Information);
                return Created(location, mapper.Map<PersonConfirmationDto>(confirmation));
            }
            catch(Exception ex)
            {
                this.loggerService.LogMessage("Error with creating person", "Post", LogLevel.Error, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {ex}");
            }
        }

        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(Guid personId)
        {
            try
            {
                var person = personRepository.GetPersonById(personId);
                if (person == null)
                {
                    this.loggerService.LogMessage("There is no person with that id", "Delete", LogLevel.Warning);
                    return NotFound();
                }
                personRepository.DeletePerson(personId);
                personRepository.SaveChanges();
                this.loggerService.LogMessage("Person successfully deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch(Exception ex)
            {
                this.loggerService.LogMessage("Error with deleting person", "Delete", LogLevel.Error, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Delete Error {ex}");
            }
        }

        [HttpPut]
        public ActionResult<PersonDto> UpdatePerson(PersonUpdateDto person)
        {
            try
            {
                var oldPerson = personRepository.GetPersonById(person.PersonId);
                if (oldPerson == null)
                {
                    this.loggerService.LogMessage("There is no person with that id", "Update", LogLevel.Warning);
                    return NotFound();
                }
                Person personEntity = mapper.Map<Person>(person);
                mapper.Map(personEntity, oldPerson); //update
                personRepository.SaveChanges();
                this.loggerService.LogMessage("Person successfully updated", "Update", LogLevel.Information);
                return Ok(mapper.Map<PersonDto>(oldPerson));
            }

            catch (Exception ex)
            {
                this.loggerService.LogMessage("Error with updating person","Update", LogLevel.Error, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
