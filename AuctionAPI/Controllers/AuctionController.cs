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
    
    [ApiController]
    [Route("api/auctionCreations")]
    [Produces("application/json", "application/xml")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class AuctionController : ControllerBase //Daje nam pristup korisnim poljima i metodama
    {
        private readonly IAuctionRepository auctionRepository;
        private readonly LinkGenerator linkGenerator; //Generise putanje do neke akcije
        private readonly IMapper mapper;

        public AuctionController(IAuctionRepository auctionRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.auctionRepository = auctionRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kreirane licitacije
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AuctionDto>> GetAuctions()
        {
            var creations = auctionRepository.GetAuctions();
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
        public ActionResult<AuctionDto> GetAuctionById(Guid auctionId)
        {
            var creation = auctionRepository.GetAuctionById(auctionId);

            if (creation == null)
            {
                return NotFound();
            }
            //Ukoliko je pronadjeno kreiranje, vraca se status 200 i listu pronadjenih kreiranja
            return Ok(mapper.Map<List<AuctionDto>>(creation));
        }

        /*
        [Consumes("application/json")] //Naznačava OpenAPI dokumentaciji da prihvata samo json tip
        [HttpPost]
        public ActionResult<AuctionDto> CreateAuction([FromBody] CreationAuctionDto auctionCreation)
        {
            try
            {
                bool modelValid = ValidateAuction(auctionCreation);

                if (!modelValid)
                {
                    return BadRequest("The auction created is not valid.");
                }

                //var auctionCreationEntity = mapper.Map<AuctionDto>(auctionCreation);

                var confirmation = auctionRepository.CreateAuction(auctionCreation);
                string location = linkGenerator.GetPathByAction("GetAuction", "Auction", new { auctionId = confirmation.auctionId });
                return Created(location, confirmation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        } */

        private bool ValidateAuction(CreationAuctionDto auctionCreation)
        {
            throw new NotImplementedException();
            // PLACEHOLDER  
        }

        [HttpDelete("{auctionId")]
        public IActionResult DeleteAuctionCreation(Guid auctionId)
        {
            try
            {
                var creation = auctionRepository.GetAuctionById(auctionId);
                //Ukoliko nije pronadjena ni jedna aukcija vratiti status 204 (NoContent)
                if (creation == null)
                {
                    return NotFound();
                }
                auctionRepository.DeleteAuction(auctionId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}