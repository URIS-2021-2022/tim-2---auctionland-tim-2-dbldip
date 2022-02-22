using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PublicBiddingAPI.Data;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;

namespace PublicBiddingAPI.Controllers
{
    [ApiController]
    [Route("/api/publicbidding")]
    public class PublicBiddingController : ControllerBase
    {
        private readonly IPublicBiddingRepository publicBiddingRepository;
        private readonly ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        //NEEDS SERVICES!!!

        public PublicBiddingController(IPublicBiddingRepository publicBiddingRepository, ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.publicBiddingRepository = publicBiddingRepository;
            this.typeOfPublicBiddingRepository = typeOfPublicBiddingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        //TESTED
        [HttpGet]
        public ActionResult<List<PublicBiddingDto>> GetAllPublicBiddings()
        {
            var biddings = this.publicBiddingRepository.getAllPublicBiddings();
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }
        //TESTED
        [HttpGet("{biddingId}")]
        public ActionResult<PublicBiddingDto> GetPublicBidding(Guid biddingId)
        {
            var bidding = this.publicBiddingRepository.getPublicBidding(biddingId);
            if (bidding == null)
                return NoContent();
            return Ok(mapper.Map<PublicBiddingDto>(bidding));
        }
        //TESTED
        [HttpPost]
        public ActionResult<PublicBiddingConfirmationDto> CreatePublicBidding(PublicBiddingCreationDto publicBidding)
        {
            TypeOfPublicBidding type = typeOfPublicBiddingRepository.GetTypeOfPublicBiddingByName(publicBidding.typeOfPublicBiddingName);
            if (type == null)
                return NoContent();

            PublicBiddingCreation publicBiddingToCreate = mapper.Map<PublicBiddingCreation>(publicBidding);
            if (!publicBiddingRepository.validatePublicBiddingData(publicBiddingToCreate))
                return Conflict("Error validating data! Please check time values!");
            publicBiddingToCreate.typeOfPublicBidding = type;
            PublicBiddingConfirmation confirmation = publicBiddingRepository.createPublicBidding(publicBiddingToCreate);

            publicBiddingRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetPublicBidding", "PublicBidding", new { biddingId = confirmation.publicBiddingId});
            return Created(location, mapper.Map<PublicBiddingConfirmationDto>(confirmation));
        }
        //TESTED
        [HttpGet("buyer/{buyerId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByBuyer(Guid buyerId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByBestBidder(buyerId);
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }
        //TESTED
        [HttpGet("appliedbuyer/{buyerId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByAppliedBuyer(Guid buyerId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByAppliedBuyer(buyerId);
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }
        //TESTED
        [HttpGet("bidder/{bidderId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByBidder(Guid bidderId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByBidder(bidderId);
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        [HttpGet("municipality/{municipalityId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByCadastralMunicipality(Guid municipalityId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByCadastralMunicipality(municipalityId);
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        [HttpGet("price/{price}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByStartingPricePerHectare(double price)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByStartingPricePerHectare(price);
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        [HttpGet("leaseperiod/{period}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByLeasePeriod(double period)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByLeasePeriod(period);
            if (biddings == null || biddings.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        [HttpDelete("{publicBiddingId}")]
        public ActionResult<String> DeletePublicBidding(Guid publicBiddingId)
        {
            try
            {
                publicBiddingRepository.DeletePublicBidding(publicBiddingId);
                publicBiddingRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<PublicBiddingConfirmationDto> UpdatePublicBidding(PublicBiddingUpdateDto publicBidding)
        {
            try
            {
                var publicBiddingOld = mapper.Map<PublicBiddingWithoutLists>(publicBiddingRepository.getPublicBidding(publicBidding.publicBiddingId));
                //var publicBiddingOld = publicBiddingRepository.getPublicBidding(publicBidding.publicBiddingId);
                if (publicBiddingOld == null)
                {
                    return NoContent();
                }
                //var publicBiddingNew = mapper.Map<PublicBiddingWithoutLists>(publicBidding);
                //var publicBiddingNew = mapper.Map<PublicBidding>(publicBidding);
                //mapper.Map(publicBidding, publicBiddingOld);
                publicBiddingRepository.UpdatePublicBidding(mapper.Map<PublicBiddingUpdate>(publicBidding));
                publicBiddingRepository.SaveChanges();
                return Ok("Changed!");
            }
            catch(Exception e)
            {
                return Conflict("ERROR: " + e.Message);
            }
            

        }
    }
}
