using AppUserWebAPI.Data;
using AppUserWebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Controllers
{
    /// <summary>
    /// Controller class that manages type of user data
    /// </summary>
    [ApiController]
    [Route("api/typeofuser")]
    public class TypeOfUserController : ControllerBase
    {
        private readonly ITypeOfUserRepository typeOfUserRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Controller of TypeOfUserController
        /// </summary>
        /// <param name="typeOfUserRepository"></param>
        /// <param name="linkGenerator"></param>
        /// <param name="mapper"></param>
        public TypeOfUserController(ITypeOfUserRepository typeOfUserRepository, IMapper mapper)
        {
            this.typeOfUserRepository = typeOfUserRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Manages getting type data from database
        /// </summary>
        /// <returns>List of types</returns>
        [HttpGet]
        public ActionResult<List<TypeOfUserDto>> GetTypes()
        {
            var types = typeOfUserRepository.GetTypesOfUser();
            if (types == null)
                return NoContent();
            return Ok(mapper.Map<List<TypeOfUserDto>>(types));
        }
        /// <summary>
        /// Manages getting data from the database with specified id
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns>returns a type with passed id</returns>
        [HttpGet("{typeId}")]
        public ActionResult<TypeOfUserDto> GetTypeOfUserById(Guid typeId)
        {
            var type = typeOfUserRepository.GetTypeOfUserById(typeId);
            if (type == null)
                return NoContent();
            return Ok(mapper.Map<TypeOfUserDto>(type));
        }
    }
}
