using MediatR;
using MeterReading.Application.Common.Exceptions;
using MeterReading.Application.Interfaces;
using MeterReading.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeterReading.Application.Features.Readings.Commands.CreateReading
{
    public class CreateReadingCommandHandler : IRequestHandler<CreateReadingCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateReadingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReadingCommand request, CancellationToken cancellationToken)
        {
            var lastEntry = await _context.Readings
                .OrderByDescending(e => e.ReadingDateTime)
                .FirstOrDefaultAsync(e =>
                    e.AccountId.Equals(request.Reading.AccountId))
                .ConfigureAwait(false);

            // Check if there is a last entry, and if there is, make sure that the new submitted record is later then the one already existing
            if (lastEntry != null && request.Reading.MeterReadingDateTime <= lastEntry.ReadingDateTime)
            {
                throw new AlreadySubmittedException(request.Reading.AccountId);
            }

            var entity = new Reading
            {
                AccountId = request.Reading.AccountId,
                ReadingDateTime = request.Reading.MeterReadingDateTime,
                ReadingValue = request.Reading.MeterReadValue,
            };

            _context.Readings.Add(entity);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return entity.Id;
        }
    }
}
