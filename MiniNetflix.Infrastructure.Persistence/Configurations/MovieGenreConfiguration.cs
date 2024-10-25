

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Infrastructure.Persistence.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenres");

            builder.HasKey(mg => new {mg.MovieId, mg.GenreId});

            builder.HasQueryFilter(x => !x.IsDeleted);

            //Relationships

            builder.HasOne(mg => mg.Movie)
                   .WithMany(mg => mg.MovieGenres)
                   .HasForeignKey(mg => mg.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mg => mg.Genre)
                   .WithMany(mg => mg.MovieGenres)
                   .HasForeignKey(mg => mg.GenreId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
       
    }
}
