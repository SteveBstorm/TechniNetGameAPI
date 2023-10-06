using DemoASPMVC_DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechniNetGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_genreService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] string  genre)
        {
            _genreService.Add(genre);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return Ok();
        }
    }
}
