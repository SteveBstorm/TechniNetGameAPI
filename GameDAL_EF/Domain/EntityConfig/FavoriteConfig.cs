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
    public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(nameof(Favorite.GameId), nameof(Favorite.UserId));
            
            builder.HasOne(x => x.FGame).WithMany(x => x.IsFavorite).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.FUser).WithMany(x => x.FavoriteGames).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
