using AutoMapper;
using ComplaintAPI.Models.ActionTaken;
using ComplaintService.Data.Interfaces;
using ComplaintService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ComplaintService.Controllers
{
    /// <summary>
    /// Kontroler radnje na osnovu žalbe
    /// </summary>
    [ApiController]
    [Route("api/actionTaken")]
    [Produces("application/json", "application/xml")]
    public class ActionTakenController : ControllerBase
    {
        private readonly IActionTakenRepository actionTakenRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Konstruktor kontrolera za radnju
        /// </summary>
        /// <param name="actionTakenRepository">Repozitorijum radnje na osnovu žalbe</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        public ActionTakenController(IActionTakenRepository actionTakenRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.actionTakenRepository = actionTakenRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu radnji na osnovu žalbe
        /// </summary>
        /// <returns>Lista radnji na žalbe</returns>
        /// <response code="200">Vraćena je lista radnji</response>
        /// <response code="404">Nije pronađena ni jedna radnja za žalbu</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ActionTakenDto>> GetAllActionTaken(string actionTaken)
        {
            var actionTakenList = actionTakenRepository.GetAllActionTaken(actionTaken);

            if(actionTakenList == null || actionTakenList.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<IEnumerable<ActionTakenDto>>(actionTakenList));
        }

        /// <summary>
        /// Vraća jednu radnju za žalbu na osnovu prosleđenog ID-ja
        /// </summary>
        /// <param name="actionTakenId">ID radnje za žalbu</param>
        /// <returns>Radnja za žalbu</returns>
        /// <response code="200">Vraća traženu radnju za žalbu</response>
        /// <response code="404">Nije pronađena radnja za žalbu sa unetim ID-jem</response>
        [HttpGet("{actionTakenId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<ActionTakenDto> GetActionTaken(Guid actionTakenid)
        {
            var actionTaken = actionTakenRepository.GetActionTakenById(actionTakenid);

            if(actionTaken == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ActionTakenDto>(actionTaken));
        }

        /// <summary>
        /// Kreira novu radnju za žalbu
        /// </summary>
        /// <param name="actionTaken">Model radnje za žalbu</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove radnje za zalbu \
        /// POST /api/actionTaken \
        /// {   
        ///     "actionTaken": "Otvorena"
        /// }
        /// </remarks>
        /// <returns>Potvrda o kreiranju radnje za žalbu</returns>
        /// <response code="201">Vraća kreiranu radnju za žalbu</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa nove radnje za žalbu</response>
        [HttpPost]
        [Consumes("applicatoin/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ActionTakenCreateDto> CreateActionTaken([FromBody] ActionTakenCreateDto actionTaken)
        {
            try
            {
                var validActionTaken = actionTakenRepository.isValidActionTaken(actionTaken.actionTaken);

                if (!validActionTaken)
                {
                    return BadRequest();
                }

                ActionTaken createdActionTaken = actionTakenRepository.CreateActionTaken(mapper.Map<ActionTaken>(actionTaken));

                string location = linkGenerator.GetPathByAction("GetActionTaken", "ActionTaken", new { actionTakenId = createdActionTaken.actionTakenId });

                return Created(location, mapper.Map<ActionTakenCreateDto>(createdActionTaken));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Action Taken error");
            }
        }

        /// <summary>
        /// Izmena radnje za žalbu
        /// </summary>
        /// <param name="actionTakenId">ID radnje za žalbu</param>
        /// <param name="actionTaken">Model radnje za žalbu</param>
        /// <returns>Potvrda o izmeni radnje za žalbu</returns>
        /// <response code="200">Izmenjena radnja za zalbu</response>
        /// <response code="400">Uneti podaci već postoje u bazi</response>
        /// <response code="404">Nije pronađena radnja za žalbu sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene radnje za žalbu</response>
        [HttpPut("{actionTakenId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ActionTakenUpdateDto> UpdateActionTaken(Guid actionTakenId, [FromBody] ActionTakenUpdateDto actionTaken)
        {
            try
            {
                var validActionTaken = actionTakenRepository.isValidActionTaken(actionTaken.actionTaken);

                if (!validActionTaken)
                {
                    return BadRequest();
                }

                var actionTakenEntity = actionTakenRepository.GetActionTakenById(actionTakenId);

                if(actionTakenEntity == null)
                {
                    return NotFound();
                }

                mapper.Map(actionTaken, actionTakenEntity);

                actionTakenRepository.UpdateActionTaken(mapper.Map<ActionTaken>(actionTaken));
                return Ok(actionTaken);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Action Taken error");
            }
        }

        /// <summary>
        /// Brisanje radnje za žalbu na osnovu prosleđenog ID-ja
        /// </summary>
        /// <param name="actionTakenId">ID radnje za žalbu</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Radnja za zalbu je uspešno obrisana</response>
        /// <response code="404">Nije pronađena radnja za žalbu sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja radnje za zalbu</response>
        [HttpDelete("{actionTakenId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteActionTaken(Guid actionTakenId)
        {
            try
            {
                var actionTakenToDelete = actionTakenRepository.GetActionTakenById(actionTakenId);

                if (actionTakenToDelete == null)
                {
                    return NotFound();
                }

                actionTakenRepository.deleteActionTaken(actionTakenId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Action Taken error");
            }
        }
    }
}
