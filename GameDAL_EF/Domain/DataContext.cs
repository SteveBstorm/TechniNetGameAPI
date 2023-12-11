using GameDAL_EF.Domain.EntityConfig;
using GameDAL_EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<Game> GameList{ get; set; }
        public DbSet<Genre> GenreList { get; set; }
        public DbSet<Favorite> FavoriteList { get; set; }
        public DbSet<User> UserList{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TechniNetEFGameAPI;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new FavoriteConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
        }
    }
}
