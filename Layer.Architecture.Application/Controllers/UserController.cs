
using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Service.Services;
using Layer.Architecture.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;



using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


using Microsoft.Extensions.Configuration;

namespace Layer.Architecture.Application.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseUserService;
        private IUserService _userService;
        private IConfiguration _config;


        public UserController(IBaseService<User> baseUserService, IUserService userService, IConfiguration Configuration)
        {
            _baseUserService = baseUserService;
            _userService = userService;
            _config = Configuration;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<CreateUserModel, UserModel, UserValidator>(user));
        }

         [HttpPost, Route("login")]
         public IActionResult Login([FromBody] LoginModel user)
         {
             if (user == null)
                 return NotFound();
             var userResponse = _userService.GetUserByLogin(user.Login, user.Passwd);
             if(userResponse == null)
             {
                 return null;
             }
             var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
             var _issuer = _config["Jwt:Issuer"];
             var _audience = _config["Jwt:Audience"];
             var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);
             var tokeOptions = new JwtSecurityToken(
                 issuer: _issuer,
                 audience: _audience,
                 claims: new List<Claim>(),
                 expires: DateTime.Now.AddMinutes(2),
                 signingCredentials: signinCredentials);
             var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
              return Ok(new { Token = tokenString });
            
         }

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserModel user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UpdateUserModel, UserModel, UserValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }
 
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get<UserModel>());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById<UserModel>(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}