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
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public TypeOfPublicBiddingController(ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.typeOfPublicBiddingRepository = typeOfPublicBiddingRepository;
            this.linkGenerator = linkGenerator;
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
    }
}
