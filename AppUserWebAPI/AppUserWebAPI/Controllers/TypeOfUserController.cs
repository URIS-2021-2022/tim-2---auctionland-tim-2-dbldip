using AppUserWebAPI.Data;
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

        //POKRENUTI MIGRACIJE, DOVRSITI ENDPOINTE!
    }
}
