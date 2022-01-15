using MediatR;
using MeterReading.Application.Features.Readings.Models;
using Microsoft.AspNetCore.Http;

namespace MeterReading.Application.Features.Readings.Commands.UploadReadings
{
    public class UploadReadingCommand : IRequest<List<MeterReadingDto>>
    {
        public IFormFile File { get; set; }
    }
}
