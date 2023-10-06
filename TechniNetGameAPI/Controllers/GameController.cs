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
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;

        public GameController(IGameService gameService, IGenreService genreService)
        {
            _gameService = gameService;
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gameService.GetGames());
        }
        [Authorize("AdminPolicy")]
        [HttpPost]
        public IActionResult Post([FromBody] GameCreate game) 
        { 
            if(!ModelState.IsValid) { return  BadRequest(); }

            try
            {
                _gameService.Create(game.ToDal());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            GameView game = _gameService.GetById(id).ToAsp(_genreService);
            return Ok(game);
           
        }

        [Authorize("IsConnected")]
        [HttpGet("favoris/{id}")]
        public IActionResult GetFavorite(int id)
        {
            return Ok(_gameService.GetByUserId(id));
        }

        [HttpGet("genre/{id}")]
        public IActionResult GetByGenre(int id)
        {
            return Ok(_gameService.GetGames().Where(x => x.IdGenre == id));
        }
    }
}
