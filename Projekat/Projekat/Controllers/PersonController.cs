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
    /// <summary>
    /// Kontroler za ličnost
    /// </summary>
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor kontrolera ličnosti - DI
        /// </summary>
        /// <param name="personRepository">Repository ličnosti</param>
        /// <param name="linkGenerator">Link generator za create zahtev</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public PersonController(IPersonRepository personRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve ličnosti
        /// </summary>
        /// <returns>Lista ličnosti</returns>
        /// <response code="200">Vraća listu ličnosti</response>
        /// <response code="404">Nije pronađena ni jedna ličnost</response>
        /// 
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

        /// <summary>
        /// Vraća jednu ličnost na osnovu ID-a
        /// </summary>
        /// <param name="personId">ID ličnosti</param>
        /// <returns>Ličnost</returns>
        /// <response code="200">Vraća traženu ličnost</response>
        /// <response code="404">Nije pronađena ličnost za uneti ID</response>
        /// 
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

        /// <summary>
        /// Kreira novu ličnost
        /// </summary>
        /// <param name="personDto">Model ličnosti</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove ličnosti \
        /// POST /api/person \
        /// {   
        ///     "Name": "Jovana", \
        ///     "Surname": "Miscevic", \
        ///     "Role": "Ministar" \
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju ličnosti</returns>
        /// <response code="201">Vraća kreiranu ličnost</response>
        /// <response code="500">Desila se greška prilikom unosa nove ličnosti</response>
        /// 
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

        /// <summary>
        /// Brisanje ličnosti na osnovu ID-a
        /// </summary>
        /// <param name="personId">ID ličnosti</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ličnost je uspešno obrisana</response>
        /// <response code="404">Nije pronađena ličnost za uneti ID</response>
        /// <response code="500">Serverska greška tokom brisanja ličnosti</response>
        /// 
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

        /// <summary>
        /// Modifikacija ličnosti
        /// </summary>
        /// <param name="person">Model ličnosti</param>
        /// <returns>Potvrda o modifikaciji ličnosti</returns>
        /// <response code="200">Izmenjena ličnost</response>
        /// <response code="404">Nije pronađena ličnost za uneti ID</response>
        /// <response code="500">Serverska greška tokom modifikacije ličnosti</response>
        ///
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
