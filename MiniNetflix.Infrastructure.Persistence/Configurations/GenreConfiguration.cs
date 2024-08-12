

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMinimalAPI.Core.Domain.Entities;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.HasKey(genre => genre.GenreId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
