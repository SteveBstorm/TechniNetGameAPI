using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdGenre { get; set; }
        public Genre? Genre { get; set; }

        public List<Favorite> IsFavorite { get; set; }
    }
}
