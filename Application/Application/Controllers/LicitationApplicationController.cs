using Application.Data;
using Application.Entities;
using Application.Models;
using Application.ServiceCalls;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
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
        private readonly IPriorityRepository priorityRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// ApplicationController constructor
        /// </summary>
        /// <param name="applicationRepository">Application repository</param>
        /// /// <param name="priorityRepository">Priority repository</param>
        /// <param name="linkGenerator">Link generator</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService">Logger service</param>
        public LicitationApplicationController(IApplicationRepository applicationRepository, IPriorityRepository priorityRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.applicationRepository = applicationRepository;
            this.priorityRepository = priorityRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Return all applications
        /// </summary>
        /// <returns>List of applications</returns>
        /// <response code="200">Returns all applications</response>
        /// <response code="404">No application found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicitationApplicationDto>> GetApplications()
        {
            var applications = applicationRepository.GetApplications();
            if (applications == null || applications.Count == 0)
            {
                loggerService.LogMessage("List of applications is empty", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("List of applications returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<LicitationApplicationDto>>(applications));
        }

        /// <summary>
        /// Returns application by ID
        /// </summary>
        /// <param name="applicationId">Application ID</param>
        /// <returns>Application</returns>
        /// <response code="200">Returns application by ID</response>
        /// <response code="404">No application by ID found</response>
        [HttpGet("{applicationId}")]
        public ActionResult<LicitationApplicationDto> GetApplication(Guid applicationId)
        {
            var application = applicationRepository.GetApplicationById(applicationId);
            if (application == null)
            {
                loggerService.LogMessage("There is no application with that id", "Get", LogLevel.Warning);
                return NoContent();
            }

            loggerService.LogMessage("Application returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<LicitationApplicationDto>(application));
        }

        /// <summary>
        /// Create new application
        /// </summary>
        /// <param name="application">Creation application DTO</param>
        /// <returns>Confirmation of created application</returns>
        /// <response code="201">Returns confirmation of created application</response>
        /// <response code="500">Application creation error</response>
        /// 
        [HttpPost]
        public ActionResult<LicitationApplicationConfirmationDto> CreateApplication([FromBody] LicitationApplicationCreationDto application)
        {
            Priority priority = priorityRepository.GetPriorityById(application.priorityId);
            if (priority == null)
                return NoContent();

            LicitationApplication applicationToCreate = mapper.Map<LicitationApplication>(application);
            applicationToCreate.priorityName = priority.priorityDescription;
            LicitationApplicationConfirmation confirmation = applicationRepository.CreateApplication(applicationToCreate);
            applicationRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction(action: "GetApplication", controller: "LicitationApplication", values: new { applicationId = confirmation.applicationId });
            loggerService.LogMessage("Application created", "Post", LogLevel.Information);
            return Created(location, mapper.Map<LicitationApplicationConfirmationDto>(confirmation));
        }

        /// <summary>
        /// Application modify
        /// </summary>
        /// <param name="application">Update application DTO</param>
        /// <returns>Confirmation of updated application</returns>
        /// <response code="200">Returns confirmation of updated application</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found application by ID</response>
        /// <response code="500">Server error</response>
        [HttpPut]
        public ActionResult<LicitationApplicationDto> UpdateApplication(LicitationApplicationUpdateDto application)
        {
            var oldApplication = applicationRepository.GetApplicationById(application.applicationId);
            if (oldApplication == null)
            {
                loggerService.LogMessage("There is no application with that id", "Get", LogLevel.Warning);
                return NotFound();
            }

            LicitationApplication applicationEntity = mapper.Map<LicitationApplication>(application);
            mapper.Map(applicationEntity, oldApplication);
            applicationRepository.SaveChanges();
            loggerService.LogMessage("Application updated", "Put", LogLevel.Information);
            return Ok(mapper.Map<LicitationApplicationDto>(oldApplication));
        }

        /// <summary>
        /// Delete application
        /// </summary>
        /// <param name="applicationId">Application ID</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Application deleted</response>
        /// <response code="404">Application by ID not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{applicationId}")]
        public IActionResult DeleteApplication(Guid applicationId)
        {
            try
            {
                var applicationToDelete = applicationRepository.GetApplicationById(applicationId);
                if (applicationToDelete == null)
                {
                    loggerService.LogMessage("There is no application with that id", "Get", LogLevel.Warning);
                    return NotFound();
                }

                applicationRepository.DeleteApplication(applicationId);
                applicationRepository.SaveChanges();
                loggerService.LogMessage("Application deleted", "Delete", LogLevel.Information);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error: " + e.Message);
            }
        }
    }
}
