using AuctionAPI.Data;
using AuctionAPI.Entities;
using AuctionAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Controllers
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiController]
    [Route("api/auctionCreations")]
    [Produces("application/json", "application/xml")]
    public class AuctionController : ControllerBase //Daje nam pristup korisnim poljima i metodama
    {
        private readonly IAuctionRepository auctionCreationRepository;
        private readonly LinkGenerator linkGenerator; //Generise putanje do neke akcije
        private readonly IMapper mapper;

        public AuctionController(IAuctionRepository auctionCreationRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.auctionCreationRepository = auctionCreationRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kreirane licitacije
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AuctionDto>> GetAuctionCreations()
        {
            var creations = auctionCreationRepository.GetAuctionCreations();
            if (creations == null || creations.Count == 0)
            {
                return NoContent();
            }

            return Ok(creations);
        }

        /// <summary>
        /// Vraća jednu licitaciju
        /// </summary>
        /// <param name="auctionId">ID licitacije</param>
        /// <returns></returns>
        /// <response code="200">Uspeh</response>
        [HttpGet("{auctionId})")]
        public ActionResult<AuctionDto> GetAuctionCreationById(Guid auctionId)
        {
            var creation = auctionCreationRepository.GetAuctionCreationById(auctionId);

            if (creation == null)
            {
                return NotFound();
            }
            //Ukoliko je pronadjeno kreiranje, vraca se status 200 i listu pronadjenih kreiranja
            return Ok(mapper.Map<List<AuctionDto>>(creation));
        }

        [Consumes("application/json")] //Naznačava OpenAPI dokumentaciji da prihvata samo json tip
        [HttpPost]
        public ActionResult<AuctionDto> CreateAuctionCreation([FromBody] CreationAuctionDto auctionCreation)
        {
            try
            {
                bool modelValid = ValidateAuctionCreation(auctionCreation);

                if (!modelValid)
                {
                    return BadRequest("The auction created is not valid.");
                }

               // var auctionCreationEntity = mapper.Map<AuctionCreationDto>(auctionCreation);

                var confirmation = auctionCreationRepository.CreateAuctionCreation(auctionCreation);
                string location = linkGenerator.GetPathByAction("GetAuctionCreation", "AuctionCreation", new { auctionCreationId = confirmation.auctionCreationId });
                return Created(location, confirmation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        private bool ValidateAuctionCreation(CreationAuctionDto auctionCreation)
        {
            throw new NotImplementedException();
            // PLACEHOLDER  
        }

        [HttpDelete("{auctionCreationId")]
        public IActionResult DeleteAuctionCreation(Guid auctionCreationId)
        {
            try
            {
                var creation = auctionCreationRepository.GetAuctionCreationById(auctionCreationId);
                //Ukoliko nije pronadjena ni jedna kreacija aukcije vratiti status 204 (NoContent)
                if (creation == null)
                {
                    return NotFound();
                }
                auctionCreationRepository.DeleteAuctionCreation(auctionCreationId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}