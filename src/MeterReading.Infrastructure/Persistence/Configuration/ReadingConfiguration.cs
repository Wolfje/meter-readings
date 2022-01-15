using MeterReading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeterReading.Infrastructure.Persistence.Configuration
{
    public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
    {
        public void Configure(EntityTypeBuilder<Reading> builder)
        {
            builder.Property(e => e.ReadingDateTime)
                .IsRequired();

            builder.HasOne(e => e.Account)
                .WithMany(e => e.Readings)
                .HasForeignKey(e => e.AccountId);

            builder.Property(e => e.ReadingValue)
                .HasMaxLength(5)
                .IsFixedLength()
                .IsRequired();
        }
    }
}
