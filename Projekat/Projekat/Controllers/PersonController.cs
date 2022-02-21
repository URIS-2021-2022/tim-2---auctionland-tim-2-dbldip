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

namespace CommissionWebAPI.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public PersonController(IPersonRepository personRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetPersons(string name, string surname, string role)
        {
            var persons = personRepository.GetPersons(name, surname, role);
            if(persons.Count == 0 || persons == null)
                return NoContent();
            return Ok(mapper.Map<List<PersonDto>>(persons));
        }

        [HttpGet("{personId}")]
        public ActionResult<PersonDto> GetPersonById(Guid personId)
        {
            Person personModel = personRepository.GetPersonById(personId);
            if(personModel == null)
                return NotFound();
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

                return Created(location, mapper.Map<PersonConfirmationDto>(confirmation));
            }
            catch(Exception ex)
            {
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
                    return NotFound();
                personRepository.DeletePerson(personId);
                personRepository.SaveChanges();
                return NoContent();
            }
            catch(Exception ex)
            {
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
                    return NotFound();
                Person personEntity = mapper.Map<Person>(person);
                mapper.Map(personEntity, oldPerson); //update
                personRepository.SaveChanges();
                return Ok(mapper.Map<PersonDto>(oldPerson));
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
