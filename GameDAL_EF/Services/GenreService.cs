using GameDAL_EF.Domain;
using GameDAL_EF.Entities;
using GameDAL_EF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Services
{
    public class GenreService : IGenreService
    {
        private DataContext _context;

        public GenreService()
        {
            _context = new DataContext();
        }
        public void Add(string genre)
        {
          _context.GenreList.Add(new Genre { Label = genre});
        }

        public void Delete(int id)
        {
            Genre toDelete = _context.GenreList.FirstOrDefault(x => x.Id == id);
            if (toDelete != null)
            {
                _context.GenreList.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.GenreList;
        }

        public Genre GetById(int id)
        {
            return _context.GenreList.First(x => x.Id == id);
        }
    }
}
