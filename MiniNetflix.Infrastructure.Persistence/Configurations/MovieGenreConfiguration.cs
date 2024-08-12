

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMinimalAPI.Core.Domain.Entities;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Configurations
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
