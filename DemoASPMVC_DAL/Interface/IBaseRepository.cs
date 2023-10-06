namespace DemoASPMVC_DAL.Interface
{
    public interface IBaseRepository<TModel>
    {
        void Delete(int id, string tablename = "");
        IEnumerable<TModel> GetAll(string tablename = "");
        TModel GetById(int id, string tablename = "");
    }
}