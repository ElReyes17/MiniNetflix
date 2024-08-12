

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMinimalAPI.Core.Domain.Entities;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");

            builder.HasKey(movie => movie.MovieId);

            builder.HasOne(movie => movie.Producer)
                   .WithMany(movie => movie.Movies)
                   .HasForeignKey(movie => movie.ProducerId);

            builder.HasQueryFilter(x => !x.IsDeleted);


        }
    }
}
