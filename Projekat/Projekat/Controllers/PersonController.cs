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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<PersonDto>> GetPersons(string name, string surname, string role)
        {
            var persons = personRepository.GetPersons(name, surname, role);
            if(persons.Count == 0 || persons == null)
                return NoContent();
            return Ok(mapper.Map<List<PersonDto>>(persons));
        }

        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonDto> GetPersonById(Guid personId)
        {
            Person personModel = personRepository.GetPersonById(personId);
            if(personModel == null)
                return NotFound();
            return Ok(mapper.Map<PersonDto>(personModel));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonConfirmationDto> CreatePerson([FromBody]PersonCreationDto personDto)
        {
            try
            {
                Person person = mapper.Map<Person>(personDto);
                PersonConfirmation confirmation = personRepository.CreatePerson(person);

                string location = linkGenerator.GetPathByAction("GetPersonById", "Person", new { personId = confirmation.PersonId });

                return Created(location, mapper.Map<PersonConfirmationDto>(confirmation));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {ex}");
            }
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonDto> UpdatePerson([FromBody]PersonDto personDto)
        {
           var oldPerson = personRepository.GetPersonById(personDto.PersonId);
            if(oldPerson == null)
                return NotFound();
            Person person = mapper.Map<Person>(personDto);
            mapper.Map(person, oldPerson);
            return Ok(mapper.Map<PersonDto>(oldPerson));    
        }
    }
}
