

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(movie => movie.MovieId);

            builder.Property(genre => genre.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(genre => genre.CoverImage)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(genre => genre.Link)
                   .IsRequired()
                   .HasMaxLength(200);
          

            builder.HasQueryFilter(x => !x.IsDeleted);

            
            //Relationships

            builder.HasOne(movie => movie.Producer)
                   .WithMany(movie => movie.Movies)
                   .HasForeignKey(movie => movie.ProducerId)
                   .OnDelete(DeleteBehavior.Restrict);

            


        }
    }
}
