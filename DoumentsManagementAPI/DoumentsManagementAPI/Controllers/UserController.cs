using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Services;
using DoumentsManagementAPI.Security.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DoumentsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JWTSetting _jwtsettings;

        public UserController(IUserService userService, IOptions<JWTSetting> jwtsettings)
        {
            _userService = userService;
            _jwtsettings = jwtsettings.Value;
        }
        // GET: api/getAllUsers
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAuthors()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/getUser/1
        [HttpGet("getUserById/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        //POST : api/Users/Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] UserCred userCred)
        {
            var user = await _userService.findByUserCred(userCred);
            if (user == null)
                return Unauthorized();
            var userWithToken = new UserWithToken(user);
            userWithToken.AccessToken = GenerateAccessToken(user.UserId);
            return Ok(userWithToken);
        }
        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new Claim[]
                {
                    //new Claim(ClaimTypes.Name,user.EmailAddress)
                    new Claim(ClaimTypes.Name,Convert.ToString(userId))

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
