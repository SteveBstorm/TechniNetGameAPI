using GameDAL_EF.Domain;
using GameDAL_EF.Entities;
using GameDAL_EF.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;
        public UserService() {
            _context = new DataContext();
        }
        public void Delete(int id)
        {
            User toDelete = _context.UserList.FirstOrDefault(x => x.Id == id);
            if (toDelete != null)
            {
                _context.UserList.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.UserList;
        }

        public User GetById(int id)
        {
            return _context.UserList.First(x => x.Id == id);
        }

        public string CheckPassword(string email)
        {
            return _context.UserList.FirstOrDefault(x => x.Email == email).PwdHash;
        }

        public User Login(string email)
        {
            return _context.UserList.First(x => x.Email == email);
        }

        public bool Register(string email, string pwd, string nickname)
        {
            try
            {
            _context.UserList.Add(new User { Email = email, PwdHash = pwd, NickName = nickname, RoleId = 1 });
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public void SetRole(int idUser, int idRole)
        {
            _context.UserList.First(x => x.Id == idUser).RoleId  = idRole;
            _context.SaveChanges();
        }
    }
}
