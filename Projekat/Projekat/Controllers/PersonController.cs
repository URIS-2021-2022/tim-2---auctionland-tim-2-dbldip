using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Projekat.Data;
using Projekat.Entities;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Controllers
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
        [HttpHead]
        public ActionResult<List<PersonDto>> GetPersons(string name, string surname, string role)
        {
            List<Person> persons = personRepository.GetPersons(name, surname, role);
            if(persons.Count == 0 || persons == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<PersonDto>>(persons));
        }

        [HttpGet("{personId}")]
        public ActionResult<PersonDto> GetPersonById(Guid personId)
        {
            Person personModel = personRepository.GetPersonById(personId);
            if(personModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PersonDto>(personModel));
        }

        [HttpPost]
        public ActionResult<PersonConfirmationDto> CreatePerson([FromBody]PersonCreationDto personDto)
        {
            try
            {
                bool personValid = ValidatePerson(personDto);

                if (!personValid)
                {
                    return BadRequest("You need to fill all of the fields");
                }

                Person person = mapper.Map<Person>(personDto);
                PersonConfirmation confirmation = personRepository.CreatePerson(person);
                string location = linkGenerator.GetPathByAction("GetPersonById", "Person", new { personId = confirmation.PersonId });
                return Created(location, mapper.Map<PersonConfirmationDto>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(Guid personId)
        {
            try
            {
                Person person = personRepository.GetPersonById(personId);
                if (person == null)
                {
                    return NotFound();
                }
                personRepository.DeletePerson(personId);
                return NoContent();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        [HttpPut]
        public ActionResult<PersonUpdateDto> UpdatePerson([FromBody]PersonUpdateDto personDto)
        {
            try
            {
                var oldPerson = personRepository.GetPersonById(personDto.PersonId);
                if(oldPerson == null)
                {
                    return NotFound();
                }
                
                Person person = mapper.Map<Person>(personDto);

                mapper.Map(person, oldPerson);
                return Ok(mapper.Map<PersonDto>(oldPerson));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        [HttpOptions]
        public IActionResult GetPersonOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

        private bool ValidatePerson(PersonCreationDto person)
        {
            if (person.Name != null & person.Surname != null && person.Role != null)
                return true;
            else return false;
        }
    }
}
