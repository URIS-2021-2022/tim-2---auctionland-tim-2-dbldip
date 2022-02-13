using Application.Data;
using Application.Entities;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class LicitationApplicationController : ControllerBase
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public LicitationApplicationController(IApplicationRepository applicationRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.applicationRepository = applicationRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicitationApplicationDto>> GetApplications()
        {
            var applications = applicationRepository.GetApplications();
            return Ok(mapper.Map<List<LicitationApplicationDto>>(applications));
        }

        [HttpGet("{applicationId}")]
        public ActionResult<LicitationApplicationDto> GetApplication(Guid applicationId)
        {
            var application = applicationRepository.GetApplicationById(applicationId);
            if (application == null)
                return NoContent();

            return Ok(mapper.Map<LicitationApplicationDto>(application));
        }

        [HttpPost]
        public ActionResult<LicitationApplicationConfirmationDto> CreateApplication([FromBody] LicitationApplicationCreationDto application)
        {
            LicitationApplication applicationToCreate = mapper.Map<LicitationApplication>(application);
            LicitationApplicationConfirmation confirmation = applicationRepository.CreateApplication(applicationToCreate);
            applicationRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetApplication", controller: "LicitationApplication", values: new { applicationId = confirmation.applicationId });
            return Created(location, mapper.Map<LicitationApplicationConfirmationDto>(confirmation));
        }

        [HttpPut]
        public ActionResult<LicitationApplicationDto> UpdateApplication(Guid applicationId, LicitationApplicationUpdateDto application)
        {
            var oldApplication = applicationRepository.GetApplicationById(application.applicationId);
            if (oldApplication == null)
                return NotFound();

            LicitationApplication applicationEntity = mapper.Map<LicitationApplication>(application);
            mapper.Map(applicationEntity, oldApplication);
            applicationRepository.SaveChanges();
            return Ok(mapper.Map<LicitationApplicationDto>(oldApplication));
        }

        [HttpDelete("{applicationId}")]
        public IActionResult DeleteApplication(Guid applicationId)
        {
            try
            {
                var applicationToDelete = applicationRepository.GetApplicationById(applicationId);
                if (applicationToDelete == null)
                    return NotFound();

                applicationRepository.DeleteApplication(applicationId);
                applicationRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
    }
}
