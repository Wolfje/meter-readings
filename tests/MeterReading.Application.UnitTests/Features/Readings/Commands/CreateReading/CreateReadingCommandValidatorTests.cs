using FluentValidation.TestHelper;
using MeterReading.Application.Features.Readings.Commands.CreateReading;
using MeterReading.Application.Features.Readings.Models;
using MeterReading.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace MeterReading.Application.UnitTests.Features.Readings.Commands.CreateReading
{
    public class CreateReadingCommandValidatorTests
    {
        private DbContextOptions _dbContextOptions;

        public CreateReadingCommandValidatorTests()
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
        public async Task CreateReadingCommandValidator_Validate_ValidAccountAndReading()
        {

            using var context = new ApplicationDbContext(_dbContextOptions);
            var validator = new CreateReadingCommandValidator(context);

            var model = new CreateReadingCommand { Reading = new MeterReadingDto { AccountId = 1, MeterReadingDateTime = DateTime.Now.AddDays(-1), MeterReadValue = "00110" } };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public async Task CreateReadingCommandValidator_Validate_InvalidAccount()
        {

            using var context = new ApplicationDbContext(_dbContextOptions);
            var validator = new CreateReadingCommandValidator(context);

            var model = new CreateReadingCommand { Reading = new MeterReadingDto { AccountId = 2, MeterReadingDateTime = DateTime.Now.AddDays(-1), MeterReadValue = "00110" } };

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(e => e.Reading.AccountId);
        }

        [Test]
        public async Task CreateReadingCommandValidator_Validate_InvalidReading()
        {
            using var context = new ApplicationDbContext(_dbContextOptions);
            var validator = new CreateReadingCommandValidator(context);

            var model = new CreateReadingCommand { Reading = new MeterReadingDto { AccountId = 1, MeterReadingDateTime = DateTime.Now, MeterReadValue = "001dafa10" } };

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(e => e.Reading.MeterReadValue);
        }
    }
}
