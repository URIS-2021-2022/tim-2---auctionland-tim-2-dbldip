using AutoMapper;
using KupacWebApi.Data;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

        public BuyerController(IBuyerRepository buyerRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.buyerRepository = buyerRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<BuyerDto>> GetBuyers()
        {
            var buyers = this.buyerRepository.GetBuyers();
            if (buyers == null || buyers.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<BuyerDto>>(buyers));
        }

        [HttpGet("{buyerId}")]
        public ActionResult<BuyerDto> GetBuyerById(Guid buyerId)
        {
            var buyer = this.buyerRepository.GetBuyer(buyerId);
            if (buyer == null)
                return NoContent();
            return Ok(mapper.Map<BuyerDto>(buyer));
        }

        [HttpPost]
        public ActionResult<BuyerConfirmationDto> CreateBuyer([FromBody] BuyerCreationDto buyer, Guid buyerId)
        {

            Buyer buyerCheck = buyerRepository.GetBuyer(buyerId);
            if (buyerCheck == null)
                return NoContent();

            BuyerCreation buyerToCreate = mapper.Map<BuyerCreation>(buyer);
            BuyerConfirmation confirmation = buyerRepository.CreateBuyer(buyerToCreate);
            buyerRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetBuyer", controller: "Buyer", values: new { buyerId = confirmation.buyerId });
            return Created(location, mapper.Map<BuyerConfirmationDto>(confirmation));
        }


        [HttpDelete("{buyerId}")]
        public ActionResult<String> DeleteBuyer(Guid buyerId)
        {
            buyerRepository.DeleteBuyer(buyerId);
            buyerRepository.SaveChanges();
            return Ok("Deleted?");
        }
    }
}
