using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Infrastructure.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.HasKey(genre => genre.GenreId);

            builder.Property(genre => genre.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasQueryFilter(x => !x.IsDeleted);           

        }
    }
}
