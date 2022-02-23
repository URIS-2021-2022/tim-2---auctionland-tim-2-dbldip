using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using PublicBiddingAPI.Data;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using PublicBiddingAPI.ServiceCalls;
using System;
using System.Collections.Generic;

namespace PublicBiddingAPI.Controllers
{
    /// <summary>
    /// Controller class that manages Public Biddings, provides multiple GET methods, POST, PUT and DELETE endpoints also.
    /// </summary>
    [ApiController]
    [Route("/api/publicbidding")]
    public class PublicBiddingController : ControllerBase
    {
        private readonly IPublicBiddingRepository publicBiddingRepository;
        private readonly ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Constructor of a PublicBiddingController, 
        /// </summary>
        /// <param name="publicBiddingRepository">Public bidding repository</param>
        /// <param name="linkGenerator">Link generator for create request</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="typeOfPublicBiddingRepository">Repository that manages types data</param>
        public PublicBiddingController(IPublicBiddingRepository publicBiddingRepository, ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.publicBiddingRepository = publicBiddingRepository;
            this.typeOfPublicBiddingRepository = typeOfPublicBiddingRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Returns all PublicBidding data when requested
        /// </summary>
        /// <returns>List of public biddings</returns>
        /// <response code="200">Returns list of types</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet]
        public ActionResult<List<PublicBiddingDto>> GetAllPublicBiddings()
        {
            var biddings = this.publicBiddingRepository.getAllPublicBiddings();
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("List of public biddings is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of public biddings is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        /// Returns certain public bidding when requested, which type is specified with correct id param in the request url
        /// </summary>
        /// <param name="biddingId">Buyer Id</param>
        /// <returns>public bidding</returns>
        /// <response code="200">Returns public bidding</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("{biddingId}")]
        public ActionResult<PublicBiddingDto> GetPublicBidding(Guid biddingId)
        {
            var bidding = this.publicBiddingRepository.getPublicBidding(biddingId);
            if (bidding == null)
            {
                this.loggerService.LogMessage("There is no public bidding with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Bidding is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<PublicBiddingDto>(bidding));
        }

        /// <summary>
        ///Endpoint that manages creating public bidding
        /// </summary>
        /// <param name="publicBidding">Public bidding wiht new values</param>
        /// /// <remarks>
        /// Example of POST request\
        /// POST /api/publicBidding \
        /// {   
        /// "date":"2018-12-10T00:00:00.000Z",\
        ///"startingTime": "2018-12-10T13:45:00.000Z",\
        ///"endingTime":"2018-12-10T15:45:00.000Z",\
        ///"plotIds":["9c87cb08-dbf6-41cc-bea3-4070429867d0"],\
        ///"startingPricePerHectare":500,\
        ///"excepted": false,\
        ///"typeOfPublicBiddingName": "Javno nadmetanje",\
        ///"bestBid":600,\
        ///"bestBidderId": "5adf06b6-605c-40b2-92bc-5fff5ca3d6f8",\
        ///"cadastralMunicipalityId" : "c0bf531d-f461-4936-bba4-a5375a75bd02",\
        ///"leasePeriod":2,\
        ///"appliedBuyersId":["5adf06b6-605c-40b2-92bc-5fff5ca3d6f8"],\
        ///"biddersId":["92c0db66-b124-4eed-8d3f-ba5ce3e1db8e"],\
        ///"numbOfParticipants": 1,\
        ///"deposit":300,\
        ///"round":4 \
        ///}
        /// </remarks>
        /// <returns>Public bidding confirmation</returns>
        /// <response code="201">Public bidding confirmation</response>
        /// <response code="500">Conflict when creating</response>
        [HttpPost]
        public ActionResult<PublicBiddingConfirmationDto> CreatePublicBidding(PublicBiddingCreationDto publicBidding)
        {
            TypeOfPublicBidding type = typeOfPublicBiddingRepository.GetTypeOfPublicBiddingByName(publicBidding.typeOfPublicBiddingName);
            if (type == null)
                return NoContent();

            PublicBiddingCreation publicBiddingToCreate = mapper.Map<PublicBiddingCreation>(publicBidding);
            if (!publicBiddingRepository.validatePublicBiddingData(publicBiddingToCreate))
            {
                this.loggerService.LogMessage("Public bidding couldn't be added", "Post", LogLevel.Warning);
                return Conflict("Error validating data! Please check time values!");
            }                
            publicBiddingToCreate.typeOfPublicBidding = type;
            PublicBiddingConfirmation confirmation = publicBiddingRepository.createPublicBidding(publicBiddingToCreate);

            publicBiddingRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetPublicBidding", "PublicBidding", new { biddingId = confirmation.publicBiddingId});
            this.loggerService.LogMessage("Public Bidding is added", "Post", LogLevel.Information);
            return Created(location, mapper.Map<PublicBiddingConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Returns list of public biddings which were won by a certain buyer, specified with correct id param in the request url
        /// </summary>
        /// <param name="buyerId">Buyer Id</param>
        /// <returns>List of public bidding</returns>
        /// <response code="200">Returns list of public biddings</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("buyer/{buyerId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByBuyer(Guid buyerId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByBestBidder(buyerId);
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("Public Biddings were not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Biddings are returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        /// Returns list of public biddings in which a specified buyer is applied to, specified with correct id param in the request url
        /// </summary>
        /// <param name="buyerId">Buyer Id</param>
        /// <returns>List of public bidding</returns>
        /// <response code="200">Returns list of public biddings</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("appliedbuyer/{buyerId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByAppliedBuyer(Guid buyerId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByAppliedBuyer(buyerId);
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("Public Biddings were not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Biddings are returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        /// Returns list of public biddings in which a specified bidder is competing in, specified with correct id param in the request url
        /// </summary>
        /// <param name="bidderId">Bidder Id</param>
        /// <returns>List of public bidding</returns>
        /// <response code="200">Returns list of public biddings</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("bidder/{bidderId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByBidder(Guid bidderId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByBidder(bidderId);
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("Public Biddings were not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Biddings are returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        /// Returns list of public biddings which are held in specified cadastral municipality, specified with correct id param in the request url
        /// </summary>
        /// <param name="municipalityId">Municipality Id</param>
        /// <returns>List of public bidding</returns>
        /// <response code="200">Returns list of public biddings</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("municipality/{municipalityId}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByCadastralMunicipality(Guid municipalityId)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByCadastralMunicipality(municipalityId);
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("Public Biddings were not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Biddings are returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        /// Returns list of public biddings that have specified starting price per hectare, specified with correct id param in the request url
        /// </summary>
        /// <param name="price">Price</param>
        /// <returns>List of public bidding</returns>
        /// <response code="200">Returns list of public biddings</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("price/{price}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByStartingPricePerHectare(double price)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByStartingPricePerHectare(price);
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("Public Biddings were not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Biddings are returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        /// Returns list of public biddings that have specified lease period, specified with correct id param in the request url
        /// </summary>
        /// <param name="period">Lease period</param>
        /// <returns>List of public bidding</returns>
        /// <response code="200">Returns list of public biddings</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("leaseperiod/{period}")]
        public ActionResult<List<PublicBiddingDto>> GetPublicBiddingsByLeasePeriod(double period)
        {
            var biddings = this.publicBiddingRepository.getPublicBiddingsByLeasePeriod(period);
            if (biddings == null || biddings.Count == 0)
            {
                this.loggerService.LogMessage("Public Biddings were not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Public Biddings are returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<PublicBiddingDto>>(biddings));
        }

        /// <summary>
        ///Endpoint that manages deleting specified public bidding
        /// </summary>
        /// <param name="publicBiddingId">Public bidding Id</param>
        /// <returns>Text message</returns>
        /// <response code="200">Message</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpDelete("{publicBiddingId}")]
        public ActionResult<String> DeletePublicBidding(Guid publicBiddingId)
        {
            try
            {
                publicBiddingRepository.DeletePublicBidding(publicBiddingId);
                publicBiddingRepository.SaveChanges();
                this.loggerService.LogMessage("Public Biddings was deleted", "Get", LogLevel.Information);
                return NoContent();
            }
            catch (Exception e)
            {
                this.loggerService.LogMessage("Public Biddings couldn't be deleted", "Get", LogLevel.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        /// <summary>
        ///Endpoint that manages updating specified public bidding
        /// </summary>
        /// <param name="publicBidding">Public bidding wiht new values</param>
        /// /// <remarks>
        /// Example of PUT request\
        /// PUT /api/publicBidding \
        /// {   
        /// "publicBiddingId" : "03b08923-d9f8-4f55-9fd2-08d9f325c5e2",\
        /// "date":"2018-12-10T00:00:00.000Z",\
        ///"startingTime": "2018-12-10T13:45:00.000Z",\
        ///"endingTime":"2018-12-10T15:45:00.000Z",\
        ///"plotIds":["9c87cb08-dbf6-41cc-bea3-4070429867d0"],\
        ///"startingPricePerHectare":900,\
        ///"excepted": false,\
        ///"typeOfPublicBiddingName": "Javno nadmetanje",\
        ///"bestBid":600,\
        ///"bestBidderId": "5adf06b6-605c-40b2-92bc-5fff5ca3d6f8",\
        ///"cadastralMunicipalityId" : "c0bf531d-f461-4936-bba4-a5375a75bd02",\
        ///"leasePeriod":5,\
        ///"appliedBuyersId":["5adf06b6-605c-40b2-92bc-5fff5ca3d6f8"],\
        ///"biddersId":["92c0db66-b124-4eed-8d3f-ba5ce3e1db8e"],\
        ///"numbOfParticipants": 1,\
        ///"deposit":300,\
        ///"round":4 \
        ///}
        /// </remarks>
        /// <returns>Public bidding confirmation</returns>
        /// <response code="200">Public bidding confirmation</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found PublicBidding by ID</response>
        /// <response code="500">Server error</response>
        [HttpPut]
        public ActionResult<PublicBiddingConfirmationDto> UpdatePublicBidding(PublicBiddingUpdateDto publicBidding)
        {
            try
            {
                var publicBiddingOld = mapper.Map<PublicBiddingWithoutLists>(publicBiddingRepository.getPublicBidding(publicBidding.publicBiddingId));
                //var publicBiddingOld = publicBiddingRepository.getPublicBidding(publicBidding.publicBiddingId);
                if (publicBiddingOld == null)
                {
                    this.loggerService.LogMessage("Public Bidding was not found", "Get", LogLevel.Warning);
                    return NoContent();
                }
                //var publicBiddingNew = mapper.Map<PublicBiddingWithoutLists>(publicBidding);
                //var publicBiddingNew = mapper.Map<PublicBidding>(publicBidding);
                //mapper.Map(publicBidding, publicBiddingOld);
                publicBiddingRepository.UpdatePublicBidding(mapper.Map<PublicBiddingUpdate>(publicBidding));
                publicBiddingRepository.SaveChanges();
                this.loggerService.LogMessage("Public Bidding is changed", "Get", LogLevel.Information);
                return Ok("Changed!");
            }
            catch(Exception e)
            {
                this.loggerService.LogMessage("Public Bidding couldn't be updated", "Get", LogLevel.Error);
                return Conflict("ERROR: " + e.Message);
            }
            

        }
    }
}
