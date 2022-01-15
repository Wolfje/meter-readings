using MeterReading.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeterReading.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; }

        DbSet<Reading> Readings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
