using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using PublicBiddingAPI.Data;
using PublicBiddingAPI.Models;
using PublicBiddingAPI.ServiceCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Controllers
{
    /// <summary>
    /// Controller class that manages Types of Public Biddings, only provides GET methods since these are permanent values for types..
    /// </summary>
    [ApiController]
    [Route("/api/publicbidding/type")]
    public class TypeOfPublicBiddingController : ControllerBase
    {
        private readonly ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Constructor of a TypeOfPublicBiddingController
        /// </summary>
        /// <param name="typeOfPublicBiddingRepository">Repository that manages types data</param>
        /// <param name="mapper">AutoMapper</param>
        public TypeOfPublicBiddingController(ITypeOfPublicBiddingRepository typeOfPublicBiddingRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.typeOfPublicBiddingRepository = typeOfPublicBiddingRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }
        /// <summary>
        /// Returns all types data when requested
        /// </summary>
        /// <returns>List of types of public bidding</returns>
        /// <response code="200">Returns list of types</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet]
        public ActionResult<List<TypeOfPublicBiddingDto>> getAllTypes()
        {
            var types = this.typeOfPublicBiddingRepository.getAllTypesOfPublicBidding();
            if (types == null || types.Count == 0)
            {
                this.loggerService.LogMessage("List of types of public biddings is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of public biddings is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<TypeOfPublicBiddingDto>>(types));
        }

        /// <summary>
        /// Returns certain type when requested, which type is specified with correct id param in the request url
        /// </summary>
        /// <param name="typeId">ID of type</param>
        /// <returns>Type of public bidding</returns>
        /// <response code="200">Returns type</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("{typeId}")]
        public ActionResult<TypeOfPublicBiddingDto> getTypeById(Guid typeId)
        {
            var type = this.typeOfPublicBiddingRepository.getTypeOfPublicBiddingById(typeId);
            if (type == null)
            {
                this.loggerService.LogMessage("List of types of public biddings was not found", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("Type of public biddings was returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<TypeOfPublicBiddingDto>(type));
        }
    }
}
