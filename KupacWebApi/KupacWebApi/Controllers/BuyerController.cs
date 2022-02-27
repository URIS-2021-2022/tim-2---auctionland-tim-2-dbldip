using AutoMapper;
using KupacWebApi.Data;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using KupacWebApi.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KupacWebApi.Controllers
{

    /// <summary>
    /// Controller for the buyer
    /// </summary>
    [ApiController]
    [Route("/api/buyer")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepository buyerRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;


        /// <summary>
        /// Buyer Controller constructor
        /// </summary>
        /// <param name="buyerRepository">Buyer repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        ///  /// <param name="loggerService">Logger Service</param>
        public BuyerController(IBuyerRepository buyerRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.buyerRepository = buyerRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all buyers
        /// </summary>
        /// <returns>List of buyers</returns>
        /// <response code="200">Returns all buyers</response>
        /// <response code="404">No buyer found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<BuyerDto>> GetBuyers()
        {
            var buyers = this.buyerRepository.GetBuyers();
            if (buyers == null || buyers.Count == 0)
            {
                this.loggerService.LogMessage("List of buyers is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            foreach (var el in buyers)
            {
                foreach (var temp in el.payments)
                {
                    var responseText = String.Empty;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:44300/payment/payment/" + temp.payerId);
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        responseText = reader.ReadToEnd();
                    }

                    Console.WriteLine(responseText);
                }
            }
                this.loggerService.LogMessage("List of buyers is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<BuyerDto>>(buyers));
        }
        /// <summary>
        /// Returns buyer by ID
        /// </summary>
        /// <param name="buyerId">Buyer ID</param>
        /// <returns>Buyer</returns>
        /// <response code="200">Returns buyer by ID</response>
        /// <response code="404">No buyer by ID found</response>
        [HttpGet("{buyerId}")]
        public ActionResult<BuyerDto> GetBuyerById(Guid buyerId)
        {
            var buyer = this.buyerRepository.GetBuyer(buyerId);
            if (buyer == null)
            {
                this.loggerService.LogMessage("There is no buyer with that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Buyer is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<BuyerDto>(buyer));
        }

        /// <summary>
        /// Create new buyer
        /// </summary>
        /// <param name="buyer">Creation buyer DTO</param>
        /// <returns>Confirmation of created buyer</returns>
        /// <response code="201">Returns confirmation of created buyer</response>
        /// <response code="500">Buyer creation error</response>
        [HttpPost]
        public ActionResult<BuyerConfirmationDto> CreateBuyer([FromBody] BuyerCreationDto buyer)
        {
            BuyerCreation buyerToCreate = mapper.Map<BuyerCreation>(buyer);
            BuyerConfirmation confirmation = buyerRepository.CreateBuyer(buyerToCreate);
            buyerRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetBuyerById", controller: "Buyer", values: new { buyerId = confirmation.buyerId });
            this.loggerService.LogMessage("Buyer is added", "Post", LogLevel.Information);
            return Created(location, mapper.Map<BuyerConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Buyer modify
        /// </summary>
        /// <param name="buyer">Update buyer DTO</param>
        /// <returns>Confirmation of updated buyer</returns>
        /// <response code="200">Returns confirmation of updated buyer</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found buyer by ID</response>
        /// <response code="500">Server error</response>
        [HttpPut]
        public ActionResult<BuyerConfirmationDto> UpdateBuyer(BuyerUpdateDto buyer)
        {
            try
            {
                var buyerOld = mapper.Map<BuyerWithoutLists>(buyerRepository.GetBuyer(buyer.buyerId));

                if (buyerOld == null)
                {
                    this.loggerService.LogMessage("Buyer can't be updated!", "Put", LogLevel.Warning);
                    return NoContent();
                }

                buyerRepository.UpdateBuyer(mapper.Map<BuyerUpdate>(buyer));
                buyerRepository.SaveChanges();
                this.loggerService.LogMessage("Buyer is updated", "Put", LogLevel.Information);

                return Ok("Changed!");
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with updating buyer", "Delete", LogLevel.Error, exception);

                return Conflict("ERROR: " + exception.Message);
            }
        }

        /// <summary>
        /// Delete buyer
        /// </summary>
        /// <param name="buyerId"> Buyer ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Buyer deleted</response>
        /// <response code="404">Buyer by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{buyerId}")]
            public ActionResult<String> DeleteBuyer(Guid buyerId)
            {
                try
                {
                    buyerRepository.DeleteBuyer(buyerId);
                    buyerRepository.SaveChanges();
                    this.loggerService.LogMessage("Buyer is deleted successfully!", "Delete", LogLevel.Warning);
                    return NoContent();
                }
                catch (Exception exception)
                {
                    this.loggerService.LogMessage("Error with deleting buyer", "Delete", LogLevel.Error, exception);
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error with deleting buyer");
                }
            }
        }
    }