﻿using AutoMapper;
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
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Controllers
{
    [ApiController]
    [Route("/api/buyer")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepository buyerRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public BuyerController(IBuyerRepository buyerRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.buyerRepository = buyerRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<BuyerDto>> GetBuyers()
        {
            var buyers = this.buyerRepository.GetBuyers();
            if (buyers == null || buyers.Count == 0)
            {
                this.loggerService.LogMessage("List of buyers is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            this.loggerService.LogMessage("List of buyers is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<BuyerDto>>(buyers));
        }

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

        [HttpPost]
        public ActionResult<BuyerConfirmationDto> CreateBuyer([FromBody] BuyerCreationDto buyer, Guid buyerId)
        {
            Buyer buyerCheck = buyerRepository.GetBuyer(buyerId);
            if (buyerCheck == null)
            {
                this.loggerService.LogMessage("Adding new buyer did not happen", "Get", LogLevel.Warning);
                return NoContent();
            }

            BuyerCreation buyerToCreate = mapper.Map<BuyerCreation>(buyer);
            BuyerConfirmation confirmation = buyerRepository.CreateBuyer(buyerToCreate);
            buyerRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetBuyer", controller: "Buyer", values: new { buyerId = confirmation.buyerId });
            this.loggerService.LogMessage("Buyer is added", "Post", LogLevel.Information);
            return Created(location, mapper.Map<BuyerConfirmationDto>(confirmation));
        }


        [HttpDelete("{buyerId}")]
        public ActionResult<String> DeleteBuyer(Guid buyerId)
        {
            try
            {
                buyerRepository.DeleteBuyer(buyerId);
                buyerRepository.SaveChanges();
                this.loggerService.LogMessage("Buyer is deleted successfully!", "Get", LogLevel.Warning);
                return Ok("Deleted?");
            }
            catch (Exception exception)
            {
                this.loggerService.LogMessage("Error with deleting buyer", "Delete", LogLevel.Error, exception);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error with deleting buyer");
            }
        }
    }
}
