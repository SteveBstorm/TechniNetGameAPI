using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string PwdHash { get; set; }
        public int RoleId { get; set; }

        public List<Favorite> FavoriteGames { get; set; }
    }
}
