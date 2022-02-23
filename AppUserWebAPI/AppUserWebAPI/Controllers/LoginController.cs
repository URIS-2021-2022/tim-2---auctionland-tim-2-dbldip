using AppUserWebAPI.Data;
using AppUserWebAPI.Models;
using AppUserWebAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppUserWebAPI.Controllers
{
    /// <summary>
    /// Controller class that manages app user authentication and provides token for authenticated users
    /// </summary>
    [ApiController]
    [Route("/api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly ILoggerService loggerService;

        public LoginController(IAppUserRepository appUserRepository, ILoggerService loggerservice)
        {
            this.appUserRepository = appUserRepository;
            this.loggerService = loggerservice;
        }
        /// <summary>
        /// Login method that check user for his username and password, if the correct combination of two is provided it generates a token as a response!
        /// </summary>
        /// <param name="userLoginModel">Login model to authenticate</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<String> authenticateUser(LoginModel userLoginModel)
        {
            var userToAuthenticate = appUserRepository.GetAppUserByUsername(userLoginModel.userName);
            if (userToAuthenticate == null)
            {
                this.loggerService.LogMessage("Cant authenticate user", "Post", LogLevel.Warning);
                return Unauthorized("Unauthorized, wronge username/passowrd");
            }
                
            string savedPassword = userToAuthenticate.appUserPassword;            
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(userLoginModel.password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    this.loggerService.LogMessage("Cant authenticate user", "Post", LogLevel.Warning);
                    return Unauthorized("Unauthorized, wronge username/passowrd");
                }
                    

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("This is secret key for Uris 20212022");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, userToAuthenticate.appUserName + " " + userToAuthenticate.appUserLastName),
                    new Claim(ClaimTypes.Role, userToAuthenticate.typeOfUser)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            this.loggerService.LogMessage("Token provided to user!", "Post", LogLevel.Information);
            return tokenHandler.WriteToken(token);

        }
    }
}
