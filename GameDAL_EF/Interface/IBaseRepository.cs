namespace GameDAL_EF.Interface
{
    public interface IBaseRepository<TModel>
    {
        void Delete(int id);
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
    }
}