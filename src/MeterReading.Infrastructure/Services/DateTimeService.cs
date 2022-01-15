using MeterReading.Application.Interfaces;

namespace MeterReading.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
