using MediatR;
using MeterReading.Application.Features.Readings.Models;

namespace MeterReading.Application.Features.Readings.Commands.CreateReading
{
    public class CreateReadingCommand : IRequest<int>
    {
        public MeterReadingDto Reading { get; set; }
    }
}
