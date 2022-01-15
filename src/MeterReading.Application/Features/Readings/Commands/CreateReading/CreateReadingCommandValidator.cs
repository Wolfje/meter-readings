using FluentValidation;
using MeterReading.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MeterReading.Application.Features.Readings.Commands.CreateReading
{
    public class CreateReadingCommandValidator : AbstractValidator<CreateReadingCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateReadingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(e => e.Reading.AccountId)
                .MustAsync(ValidateAccountId);

            RuleFor(e => e.Reading.MeterReadValue)
                .NotEmpty()
                .NotNull()
                .MustAsync(ValidateReadingValue);


        }

        private async Task<bool> ValidateAccountId(int accountId, CancellationToken cancellationToken)
        {
            return await _context.Accounts
                .CountAsync(e => e.AccountId.Equals(accountId), cancellationToken)
                .ConfigureAwait(false) > 0;
        }

        private async Task<bool> ValidateReadingValue(string readingValue, CancellationToken cancellationToken)
        {
            return Regex.IsMatch(readingValue, @"^[0-9]{5}$");
        }
    }
}
