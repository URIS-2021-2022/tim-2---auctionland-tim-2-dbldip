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
    /// <summary>
    /// Kontroler za tip garancije
    /// </summary>
    [ApiController]
    [Route("api/leaseAgreement/guaranteeType")]
    public class GuaranteeTypeController : ControllerBase
    {
        private readonly IGuaranteeTypeRepository guaranteeTypeRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Konstruktor za tip garancije - DI
        /// </summary>
        /// <param name="guaranteeTypeRepository">Repository oglasa/param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger servis</param>
        public GuaranteeTypeController(IGuaranteeTypeRepository guaranteeTypeRepository, IMapper mapper, ILoggerService loggerService)
        {
            this.guaranteeTypeRepository = guaranteeTypeRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraća sve tipove garancija
        /// </summary>
        /// <returns>Lista tipova garancija</returns>
        /// <response code="200">Vraća listu tipova garancija</response>
        /// <response code="404">Nije pronađen ni jedan tip garancije</response>
        /// 
        [HttpGet]
        public ActionResult<List<GuaranteeTypeDto>> GetGuaranteeTypes()
        {
            var guaranteeTypes = guaranteeTypeRepository.GetGuaranteeTypes();
            this.loggerService.LogMessage("List of guarantee types is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<GuaranteeTypeDto>>(guaranteeTypes));
        }

       
        
    }
}
