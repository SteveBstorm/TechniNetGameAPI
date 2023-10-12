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
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre { Id = 1, Label = "Action"},
                new Genre { Id = 2, Label = "RPG"},
                new Genre { Id = 3, Label = "Meuporg"},
                new Genre { Id = 4, Label = "FPS"}
                );
        }
    }
}
