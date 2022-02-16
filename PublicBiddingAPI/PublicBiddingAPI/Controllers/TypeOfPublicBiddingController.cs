using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PublicBiddingAPI.Data;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Controllers
{
    [ApiController]
    [Route("/api/publicbidding/type")]
    public class TypeOfPublicBiddingController : ControllerBase
    {
        private readonly ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository;
        private readonly IMapper mapper;

        public TypeOfPublicBiddingController(ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository, IMapper mapper)
        {
            this.typeOfPublicBiddingRepository = typeOfPublicBiddingRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<TypeOfPublicBiddingDto>> getAllTypes()
        {
            var types = this.typeOfPublicBiddingRepository.getAllTypesOfPublicBidding();
            if (types == null || types.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<TypeOfPublicBiddingDto>>(types));
        }

        [HttpGet("{typeId}")]
        public ActionResult<TypeOfPublicBiddingDto> getTypeById(Guid typeId)
        {
            var type = this.typeOfPublicBiddingRepository.getTypeOfPublicBiddingById(typeId);
            if (type == null)
                return NoContent();
            return Ok(mapper.Map<TypeOfPublicBiddingDto>(type));
        }
    }
}
