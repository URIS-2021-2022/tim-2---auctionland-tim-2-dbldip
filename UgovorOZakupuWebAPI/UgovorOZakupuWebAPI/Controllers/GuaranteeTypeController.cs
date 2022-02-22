using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;
using UgovorOZakupuWebAPI.ServiceCalls;

namespace UgovorOZakupuWebAPI.Controllers
{
    [ApiController]
    [Route("api/leaseAgreement/guaranteeType")]
    public class GuaranteeTypeController : ControllerBase
    {
        private readonly IGuaranteeTypeRepository guaranteeTypeRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        public GuaranteeTypeController(IGuaranteeTypeRepository guaranteeTypeRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.guaranteeTypeRepository = guaranteeTypeRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<GuaranteeTypeDto>> GetGuaranteeTypes()
        {
            var guaranteeTypes = guaranteeTypeRepository.GetGuaranteeTypes();
            this.loggerService.LogMessage("List of guarantee types is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<GuaranteeTypeDto>>(guaranteeTypes));
        }

       
        
    }
}
