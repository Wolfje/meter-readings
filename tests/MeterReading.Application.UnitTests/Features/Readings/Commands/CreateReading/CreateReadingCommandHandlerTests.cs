using FluentAssertions;
using MeterReading.Application.Common.Exceptions;
using MeterReading.Application.Features.Readings.Commands.CreateReading;
using MeterReading.Application.Features.Readings.Models;
using MeterReading.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using static FluentAssertions.FluentActions;


namespace MeterReading.Application.UnitTests.Features.Readings.Commands.CreateReading
{
    public class CreateReadingCommandHandlerTests
    {
        private DbContextOptions _dbContextOptions;
        public CreateReadingCommandHandlerTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Ensek")
                .Options;

            using var context = new ApplicationDbContext(_dbContextOptions);
            context.Accounts.Add(new Domain.Entities.Account
            {
                AccountId = 1,
                Firstname = "Lex",
                Lastname = "Test"
            });

            context.Readings.Add(new Domain.Entities.Reading
            {
                AccountId = 1,
                ReadingDateTime = DateTime.Now.AddDays(-1),
                ReadingValue = "00011"
            });

            context.SaveChanges();
        }


        [Test]
        public async Task CreateReadingCommand_Validate_ValidCreateOnDatabase()
        {


            using var context = new ApplicationDbContext(_dbContextOptions);
            var handler = new CreateReadingCommandHandler(context);

            var command = new CreateReadingCommand
            {
                Reading = new MeterReadingDto { AccountId = 1, MeterReadingDateTime = DateTime.Now, MeterReadValue = "00110" }
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().BeGreaterThanOrEqualTo(0);
        }


        [Test]
        public async Task CreateReadingCommand_Validate_ThrowAlreadySubmittedException()
        {

            using var context = new ApplicationDbContext(_dbContextOptions);
            var handler = new CreateReadingCommandHandler(context);

            var command = new CreateReadingCommand
            {
                Reading = new MeterReadingDto { AccountId = 1, MeterReadingDateTime = DateTime.Now.AddDays(-2), MeterReadValue = "00110" }
            };

            await Awaiting(() => handler.Handle(command, CancellationToken.None)).Should().ThrowAsync<AlreadySubmittedException>();
        }

    }
}
