using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Entities
{
    public class Favorite
    {
        public int GameId { get; set; }
        public Game FGame { get; set; }
        public int UserId { get; set; }
        public User FUser { get; set; }
    }
}
