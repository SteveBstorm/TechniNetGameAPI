using DemoASPMVC_DAL.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoASPMVC_DAL.Services
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
    {
        protected readonly string _connectionString;
        public BaseRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        protected abstract TModel Mapper(IDataReader reader);

        public virtual IEnumerable<TModel> GetAll(string tablename = "")
        {
            if (string.IsNullOrWhiteSpace(tablename))
            {
                tablename = typeof(TModel).Name;
            }
            List<TModel> list = new List<TModel>();
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                cnx.Open();
                string sql = "SELECT * FROM " + tablename;

                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(Mapper(reader));
                        }
                    }
                }
            }
            return list;
        }

        public virtual TModel GetById(int id, string tablename = "")
        {
            if(string.IsNullOrWhiteSpace(tablename)) {
                tablename = typeof(TModel).Name;
            }
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                cnx.Open();
                string sql = "SELECT * FROM " + tablename + " WHERE Id = @id";

                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandText = sql;
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        reader.Read();  
                        return Mapper(reader);

                    }
                }
            }

        }

        public virtual void Delete(int id, string tablename = "")
        {
            if (string.IsNullOrWhiteSpace(tablename))
            {
                tablename = typeof(TModel).Name;
            }
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    string sql = $"DELETE FROM {tablename} WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandText = sql;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
