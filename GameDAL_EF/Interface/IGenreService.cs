using GameDAL_EF.Entities;


namespace GameDAL_EF.Interface
{
    public interface IGenreService : IBaseRepository<Genre>
    {
        void Add(string genre);
    }
}