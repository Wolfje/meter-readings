using FluentValidation;

namespace MeterReading.Application.Features.Readings.Commands.UploadReadings
{
    public class UploadReadingCommandValidator : AbstractValidator<UploadReadingCommand>
    {
        public UploadReadingCommandValidator()
        {
            RuleFor(e => e.File)
                .NotNull()
                .WithMessage("A file is required");

            RuleFor(e => e.File.FileName)
                .Must(HaveSupportedFileType)
                .When(f => f.File != null);
        }

        private bool HaveSupportedFileType(string filename)
        {
            var fileParts = filename.Split('.');

            return fileParts[1].Equals("csv", StringComparison.OrdinalIgnoreCase);
        }
    }
}
