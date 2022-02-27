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
    /// <summary>
    /// Kontroler za licitaciju
    /// </summary>
    [ApiController]
    [Route("api/auctions")]
    [Produces("application/json", "application/xml")]
    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository auctionRepository;
        private readonly LinkGenerator linkGenerator; 
        private readonly IMapper mapper;

        /// <summary>
        /// AuctionController konstruktor
        /// </summary>
        /// <param name="auctionRepository">Repozitorijum licitacije</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        public AuctionController(IAuctionRepository auctionRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.auctionRepository = auctionRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve  licitacije
        /// </summary>
        /// <returns>Lista licitacija</returns>
        /// <response code="200">Vraća listu licitacija</response>
        /// <response code="204">Nije pronađena ni jedna licitacija</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<AuctionDto>> GetAuctions()
        {
            var auctions = auctionRepository.GetAuctions();
            
            if (auctions == null || auctions.Count == 0)
            {
                return NoContent();
            }


            return Ok(auctions);
        }

        /// <summary>
        /// Vraća jednu licitaciju
        /// </summary>
        /// <param name="auctionId">ID licitacije</param>
        /// <returns></returns>
        /// <response code="200">Uspeh</response>
        /// <response code="404">Licitacija nije pronadjena.</response>
        [HttpGet("{auctionId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AuctionDto> GetAuctionById(Guid auctionId)
        {
            //Povezati sa servisom javno nadmetanje da izvlacis objekte tog tipa
            var auction = auctionRepository.GetAuctionById(auctionId);

            if (auction == null)
            {
                return NotFound();
            }
            
            return Ok(mapper.Map<List<AuctionDto>>(auction));
        }

        /// <summary>
        /// Kreiranje nove licitacije
        /// </summary>
        /// <param name="auctionCreation">Licitacija koja ce se kreirati</param>
        /// <returns>Rezultat kreiranja licitacije</returns>
        /// <response code="201">Kreiranje uspešno.</response>
        /// <response code="500">Serverska greška pri kreiranju licitacije.</response>
        [Consumes("application/json")] //Naznačava OpenAPI dokumentaciji da prihvata samo json tip
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AuctionConfirmationDto> CreateAuction([FromBody] CreationAuctionDto auctionCreation)
        {
            try
            {
              
                var confirmation = auctionRepository.CreateAuction(auctionCreation);
                auctionRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetAuction", "Auction", new { auctionId = confirmation.auctionId });
                
                return Created(location, mapper.Map<AuctionConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        } 


        /// <summary>
        /// Izmena licitacije
        /// </summary>
        /// <param name="auction">Licitacija za izmenu</param>
        /// <returns>Rezultat akcije</returns>
        /// <response code="200">Izmena uspešna.</response>
        /// <response code="204">Licitacija za izmenu ne postoji.</response>
        /// <response code="409">Greška pri izmeni.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<AuctionConfirmationDto> UpdateAuction(AuctionUpdateDto auction)
        {
            try
            {
                var auctionOld = mapper.Map<AuctionWithoutLists>(auctionRepository.GetAuctionById(auction.auctionId));

                if(auctionOld == null)
                {
                    return NoContent();
                }

                auctionRepository.UpdateAuction(auction);
                auctionRepository.SaveChanges();

                return Ok("Changed!");
            }
            catch (Exception exception)
            {
                return Conflict("ERROR: " + exception.Message);
            }
        }


        /// <summary>
        /// Brisanje licitacije
        /// </summary>
        /// <param name="auctionId">ID licitacije</param>
        /// <returns>Rezultat akcije</returns>
        /// <response code="204">Licitacija izbrisana.</response204>
        /// <response code="404">Licitacija za brisanje nije pronadjena.</response>
        /// <response code="500">Greška pri brisanju.</response>
        [HttpDelete("{auctionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAuctionCreation(Guid auctionId)
        {
            try
            {
                var auctionToDelete = auctionRepository.GetAuctionById(auctionId);
                if (auctionToDelete == null)
                {
                    return NotFound();
                }

                auctionRepository.DeleteAuction(auctionId);

                auctionRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}