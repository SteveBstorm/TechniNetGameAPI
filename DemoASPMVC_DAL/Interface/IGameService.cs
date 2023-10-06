using DemoASPMVC_DAL.Models;

namespace DemoASPMVC_DAL.Interface
{
    public interface IGameService
    {
        void Create(Game game);
        void Delete(int id);
        Game GetById(int id);
        IEnumerable<Game> GetGames();
        IEnumerable<Game> GetByUserId(int userId);
        void AddFavorite(int idUser, int idGame);
    }
}