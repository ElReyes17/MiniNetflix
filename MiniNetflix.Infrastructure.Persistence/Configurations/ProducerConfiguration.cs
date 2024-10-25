

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Domain.Entities;

namespace MiniNetflix.Infrastructure.Persistence.Configurations
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producers");

            builder.HasKey(producer => producer.ProducerId);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(genre => genre.Name)
                   .IsRequired()
                   .HasMaxLength(100);

        }
    }
}
