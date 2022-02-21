using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Controllers
{
    [ApiController]
    [Route("api/lease-agreement/guarantee-type")]
    public class GuaranteeTypeController : ControllerBase
    {
        private readonly IGuaranteeTypeRepository guaranteeTypeRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public GuaranteeTypeController(IGuaranteeTypeRepository guaranteeTypeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.guaranteeTypeRepository = guaranteeTypeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GuaranteeTypeDto>> GetGuaranteeTypes()
        {
            var guaranteeTypes = guaranteeTypeRepository.GetGuaranteeTypes();
            if (guaranteeTypes == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<GuaranteeTypeDto>>(guaranteeTypes));
        }

        [HttpGet("{guaranteeTypeId}")]
        public ActionResult<GuaranteeTypeDto> GetGuaranteeTypeId(Guid guaranteeTypeId)
        {
            var guaranteeType = guaranteeTypeRepository.GetGuaranteeTypeById(guaranteeTypeId);
            if (guaranteeType == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<GuaranteeTypeDto>(guaranteeType));
        }

        [HttpPost]
        public ActionResult<GuaranteeTypeConfirmationDto> CreateGuaranteeType([FromBody] GuaranteeTypeDto guaranteeTypeDto)
        {
            try
            {
                GuaranteeType guaranteeType = mapper.Map<GuaranteeType>(guaranteeTypeDto);
                GuaranteeTypeConfirmation confirmation = guaranteeTypeRepository.CreateGuaranteeType(guaranteeType);
                guaranteeTypeRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetGuaranteeType", "GuaranteeType", new { guaranteeTypeId = confirmation.GuaranteeTypeId });

                return Created(location, mapper.Map<GuaranteeTypeConfirmationDto>(confirmation));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Create error {e}");
            }
        }

        [HttpPut]
        public ActionResult<GuaranteeTypeDto> UpdateGuaranteeType([FromBody] GuaranteeTypeDto guaranteeTypeDto)
        {
            var oldGuaranteeType = guaranteeTypeRepository.GetGuaranteeTypeById(guaranteeTypeDto.GuaranteeTypeId);
            if(oldGuaranteeType == null)
            {
                return NotFound();
            }
            GuaranteeType guaranteeTypeEntity = mapper.Map<GuaranteeType>(guaranteeTypeDto);
            mapper.Map(guaranteeTypeEntity, oldGuaranteeType);
            guaranteeTypeRepository.SaveChanges();
            return Ok(mapper.Map<GuaranteeTypeDto>(oldGuaranteeType));
        }

        [HttpDelete("{guaranteeTypeId}")]
        public IActionResult DeleteGuaranteeType(Guid guaranteeTypeId)
        {
            try
            {
                var guaranteeTypeToDelete = guaranteeTypeRepository.GetGuaranteeTypeById(guaranteeTypeId);
                if (guaranteeTypeToDelete == null)
                    return NotFound();
                guaranteeTypeRepository.DeleteGuaranteeType(guaranteeTypeId);
                guaranteeTypeRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
    }
}
