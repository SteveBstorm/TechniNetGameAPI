using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Models;
using TechniNetGameAPI.Models;

namespace TechniNetGameAPI.Tools
{
    public static class Mapper
    {
        public static Game ToDal(this GameCreate game)
        {
            return new Game
            {
                Title = game.Title,
                IdGenre = game.IdGenre,
                Description = game.Description
            };
        }

        public static GameView ToAsp(this Game game, IGenreService _gs)
        {
            return new GameView
            {
                Title = game.Title,
                Id = game.Id,
                Description = game.Description,
                Genre = _gs.GetById(game.IdGenre)
            };
        }
    }
}
