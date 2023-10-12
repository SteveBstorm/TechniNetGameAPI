using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<Game> GameList { get; set; }
    }
}
