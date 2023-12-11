using GameDAL_EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL_EF.Domain.EntityConfig
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
                new Game { Id = 1, Title = "Rocket League", Description = "Best jeu de foot ever", IdGenre = 1},
                new Game { Id = 2, Title = "Baldur's Gate", Description = "Anne PC Killer", IdGenre = 2},
                new Game { Id = 3, Title = "CS:GO", Description = "Pour les fan de panpan", IdGenre = 3},
                new Game { Id = 4, Title = "World of Warcraft", Description = "Best perte de temps ever", IdGenre = 4}
                );
        }
    }
}
