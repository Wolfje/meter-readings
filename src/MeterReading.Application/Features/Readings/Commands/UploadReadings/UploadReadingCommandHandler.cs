using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using MeterReading.Application.Features.Readings.Models;
using System.Globalization;

namespace MeterReading.Application.Features.Readings.Commands.UploadReadings
{
    public class UploadReadingCommandHandler : IRequestHandler<UploadReadingCommand, List<MeterReadingDto>>
    {
        public async Task<List<MeterReadingDto>> Handle(UploadReadingCommand request, CancellationToken cancellationToken)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
            {
                HasHeaderRecord = true,
                IgnoreBlankLines = true
            };

            using var reader = new StreamReader(request.File.OpenReadStream());
            using var csvReader = new CsvReader(reader, csvConfig);

            var records = csvReader.GetRecords<MeterReadingDto>();

            return records.ToList();
        }
    }
}
