using MeterReading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeterReading.Infrastructure.Persistence.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(e => e.AccountId)
                .ValueGeneratedNever();


            builder.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(256);

        }
    }
}
