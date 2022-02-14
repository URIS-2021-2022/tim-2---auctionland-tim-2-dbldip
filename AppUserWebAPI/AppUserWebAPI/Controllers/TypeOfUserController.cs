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
    [ApiController]
    [Route("api/typeofuser")]
    public class TypeOfUserController : ControllerBase
    {
        private readonly ITypeOfUserRepository typeOfUserRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public TypeOfUserController(ITypeOfUserRepository typeOfUserRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.typeOfUserRepository = typeOfUserRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<TypeOfUserDto>> GetTypes()
        {
            var types = typeOfUserRepository.GetTypesOfUser();
            if (types == null)
                return NoContent();
            return Ok(mapper.Map<List<TypeOfUserDto>>(types));
        }

        [HttpGet("{typeId}")]
        public ActionResult<TypeOfUserDto> GetTypeOfUserById(Guid typeId)
        {
            var type = typeOfUserRepository.GetTypeOfUserById(typeId);
            if (type == null)
                return NoContent();
            return Ok(mapper.Map<TypeOfUserDto>(type));
        }
        //POKRENUTI MIGRACIJE, DOVRSITI ENDPOINTE!
    }
}
