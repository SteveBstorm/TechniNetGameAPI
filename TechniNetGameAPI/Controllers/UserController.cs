using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService, TokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegister user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                _userService.Register(user.Email, user.Password, user.Nickname);
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
                User u = _userService.Login(user.Email, user.Password);

                return Ok(_tokenManager.GenerateToken(u));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("byid/{id}")]
        public IActionResult GetById(int id) {
            return Ok(_userService.GetById(id, "Users"));
        }

        [Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult SetRole(SetRoleForm model)
        {
            return Ok(_userService.SetRole(model.IdUser, model.IdRole));
        }
        [Authorize("AdminPolicy")]
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_userService.GetAll("users"));
        }
        
    }
}
