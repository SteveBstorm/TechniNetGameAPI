//using DemoASPMVC_DAL.Interface;
//using DemoASPMVC_DAL.Models;
using BCrypt.Net;
using GameDAL_EF.Entities;
using GameDAL_EF.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechniNetGameAPI.Hubs;
using TechniNetGameAPI.Models;
using TechniNetGameAPI.Tools;

namespace TechniNetGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenManager _tokenManager;
        private readonly ChatHub _hub;

        public UserController(IUserService userService, TokenManager tokenManager, ChatHub hub)
        {
            _userService = userService;
            _tokenManager = tokenManager;
            _hub = hub;
        }

        [HttpGet("testhub")]
        public async Task<IActionResult> GetHub() {
            await _hub.SendMessage(new ChatModel { Username = "Controller", Message = "Test Controller Ok" });
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegister user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _userService.Register(user.Email, hash, user.Nickname);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                if(!BCrypt.Net.BCrypt.Verify(user.Password, _userService.CheckPassword(user.Email)))
                {
                    return BadRequest("Mot de passe invalide");
                }
                User u = _userService.Login(user.Email);
                return Ok(_tokenManager.GenerateToken(u));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("byid/{id}")]
        public IActionResult GetById(int id) {
            return Ok(_userService.GetById(id));
        }

        [Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult SetRole(SetRoleForm model)
        {
            _userService.SetRole(model.IdUser, model.IdRole);
            return Ok();
        }
        [Authorize("AdminPolicy")]
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_userService.GetAll());
        }
        
    }
}
