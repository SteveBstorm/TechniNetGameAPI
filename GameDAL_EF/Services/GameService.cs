using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDAL_EF.Domain;
using GameDAL_EF.Entities;
using GameDAL_EF.Interface;
using Microsoft.EntityFrameworkCore;

namespace GameDAL_EF.Services
{
    public class GameService : IGameService
    {
        private DataContext _context;

        public GameService() { 
            _context = new DataContext();
        }
        public void AddFavorite(int idUser, int idGame)
        {
            if(_context.FavoriteList.First(x => x.GameId == idGame && x.UserId == idUser) != null) 
            { 
                _context.FavoriteList.Add(new Favorite { GameId = idGame, UserId = idUser });
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Favoris existant");
            }
        }

        public void Create(Game game)
        {
            _context.GameList.Add(game);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Game toDelete = _context.GameList.FirstOrDefault(x => x.Id == id);
            if(toDelete != null)
            {
                _context.GameList.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public Game GetById(int id)
        {
            return _context.GameList.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Game> GetByUserId(int userId)
        {
            return _context.GameList.Include(x => x.IsFavorite.Where(x => x.UserId == userId));
        }

        public IEnumerable<Game> GetGames()
        {
            return _context.GameList;
        }
    }
}
