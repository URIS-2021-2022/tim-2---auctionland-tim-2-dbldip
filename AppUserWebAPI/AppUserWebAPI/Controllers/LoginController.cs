using AppUserWebAPI.Data;
using AppUserWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
    [ApiController]
    [Route("/api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAppUserRepository appUserRepository;

        public LoginController(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }

        [HttpPost]
        public ActionResult<String> authenticateUser(LoginModel userLoginModel)
        {
            var userToAuthenticate = appUserRepository.GetAppUserByUsername(userLoginModel.userName);
            if (userToAuthenticate == null)
                return Unauthorized("Unauthorized, wronge username/passowrd");
            string savedPassword = userToAuthenticate.appUserPassword;            
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(userLoginModel.password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return Unauthorized("Unauthorized, wronge username/passowrd");

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
            return tokenHandler.WriteToken(token);

        }
    }
}
