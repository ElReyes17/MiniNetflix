

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMinimalAPI.Core.Domain.Entities;

namespace PruebaMinimalAPI.Infrastructure.Persistence.Configurations
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producer");

            builder.HasKey(producer => producer.ProducerId);

            builder.HasQueryFilter(x => !x.IsDeleted);
         
        }
    }
}
