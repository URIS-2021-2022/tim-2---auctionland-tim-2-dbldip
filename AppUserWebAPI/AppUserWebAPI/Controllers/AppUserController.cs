using AppUserWebAPI.Data;
using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using AppUserWebAPI.ServiceCalls;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppUserWebAPI.Controllers
{
    /// <summary>
    /// Controller class that manages app user data, provides GET, POST, PUT, DELETE methods.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("/api/appUser")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ILoggerService loggerService;

        /// <summary>
        /// Constructor of a AppUserController, 
        /// </summary>
        /// <param name="appUserRepository">Public bidding repository</param>
        /// <param name="linkGenerator">Link generator for create request</param>
        /// <param name="mapper">AutoMapper</param>
        /// <param name="loggerService"></param>
        public AppUserController(IAppUserRepository appUserRepository, IMapper mapper, LinkGenerator linkGenerator, ILoggerService loggerService)
        {
            this.appUserRepository = appUserRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Returns all AppUser data when requested
        /// </summary>
        /// <returns>List of app users</returns>
        /// <response code="200">Returns list of app users</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet]
        public ActionResult<List<AppUserDto>> GetAppUsers(string firstName, string lastName, string typeOfUser)
        {
            var users = appUserRepository.GetAppUsers(firstName, lastName, typeOfUser);
            if (users == null || users.Count == 0)
            {
                this.loggerService.LogMessage("List of app users is empty", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("List of public biddings is returned", "Get", LogLevel.Information);
            return Ok(mapper.Map<List<AppUserDto>>(users));
        }

        /// <summary>
        /// Returns certain app user when requested, which type is specified with correct id param in the request url
        /// </summary>
        /// <param name="appUserId">Buyer Id</param>
        /// <returns>appUser</returns>
        /// <response code="200">Returns App user</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("{appUserId}")]
        public ActionResult<AppUserDto> GetUser(Guid appUserId)
        {
            var user = appUserRepository.GetAppUser(appUserId);
            if (user == null)
            {
                this.loggerService.LogMessage("Couldnt find user wiht that id", "Get", LogLevel.Warning);
                return NoContent();
            }
            this.loggerService.LogMessage("App user with specified Id", "Get", LogLevel.Information);
            return Ok(mapper.Map<AppUserDto>(user));
        }

        /// <summary>
        /// Returns certain app user when requested, which user is specified with correct username param in the request url
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>app user</returns>
        /// <response code="200">Returns app user</response>
        /// <response code="404">Could not find any stored data</response>
        [HttpGet("/username/{username}")]
        public ActionResult<AppUserDto> GetUserByUsername(string username)
        {
            var user = appUserRepository.GetAppUserByUsername(username);
            if (user == null)
            {
                this.loggerService.LogMessage("Couldnt find user wiht that username", "Get", LogLevel.Warning);
                return NoContent();

            }
            this.loggerService.LogMessage("App user with specified username", "Get", LogLevel.Information);
            return Ok(mapper.Map<AppUserDto>(user));
        }


        [HttpPost]
        public ActionResult<AppUserConfirmationDto> CreateAppUser(AppUserCreationDto user)
        {
            AppUser userToCreate = mapper.Map<AppUser>(user);
            var temp = appUserRepository.validateUserData(userToCreate);
            if (temp == false)
            {
                this.loggerService.LogMessage("User didnt pass validation", "Post", LogLevel.Warning);
                return Conflict(new { mesage = $"There's an existing App User with provided username field: {user.appUserUsername} !" });
            }
            AppUserConfirmation confirmation = appUserRepository.CreateAppUser(userToCreate);
            appUserRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetUser", "AppUser", new { appUserId = confirmation.appUserId });
            this.loggerService.LogMessage("App user created!", "Post", LogLevel.Information);
            return Created(location, mapper.Map<AppUserConfirmationDto>(confirmation));

        }
    }
}
