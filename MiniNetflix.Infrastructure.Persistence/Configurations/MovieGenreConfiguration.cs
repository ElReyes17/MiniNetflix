

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Infrastructure.Persistence.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");

            builder.HasOne(mg => mg.Movie)
                   .WithMany(mg => mg.MovieGenres)
                   .HasForeignKey(mg => mg.MovieId);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }

       
    }
}
