using GameDAL_EF.Entities;

namespace GameDAL_EF.Interface
{
    public interface IUserService : IBaseRepository<User>
    {
        User Login(string email);
        bool Register(string email, string pwd, string nickname);
        void SetRole(int idUser, int idRole);
        string CheckPassword(string email);
    }
}