using AppUserWebAPI.Data;
using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
    [Authorize]
    [ApiController]
    [Route("/api/appUser")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public AppUserController(IAppUserRepository appUserRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.appUserRepository = appUserRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<AppUserDto>> GetAppUsers(string firstName, string lastName, string typeOfUser)
        {
            var users = appUserRepository.GetAppUsers(firstName, lastName, typeOfUser);
            if (users == null || users.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<AppUserDto>>(users));
        } 

        [HttpGet("{appUserId}")]
        public ActionResult<AppUserDto> GetUser(Guid appUserId)
        {
            var user = appUserRepository.GetAppUser(appUserId);
            if (user == null)
                return NoContent();
            return Ok(mapper.Map<AppUserDto>(user));
        }

        [HttpGet("/username/{username}")]
        public ActionResult<AppUserDto> GetUserByUsername(string username)
        {
            var user = appUserRepository.GetAppUserByUsername(username);
            if (user == null)
                return NoContent();
            return Ok(mapper.Map<AppUserDto>(user));
        }

        [HttpPost]
        public ActionResult<AppUserConfirmationDto> CreateAppUser(AppUserCreationDto user)
        {
            AppUser userToCreate = mapper.Map<AppUser>(user);
            var temp = appUserRepository.validateUserData(userToCreate);
            if (temp == false)
                return Conflict(new { mesage = $"There's an existing App User with provided username field: {user.appUserUsername} !" });
            AppUserConfirmation confirmation = appUserRepository.CreateAppUser(userToCreate);
            appUserRepository.SaveChanges();

            string location = linkGenerator.GetPathByAction("GetUser", "AppUser", new { appUserId = confirmation.appUserId });
            return Created(location, mapper.Map<AppUserConfirmationDto>(confirmation));

        }
    }
}
