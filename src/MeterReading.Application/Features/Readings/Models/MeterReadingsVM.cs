namespace MeterReading.Application.Features.Readings.Models
{
    public class MeterReadingsVM
    {
        public int Success { get; set; }
        public int InvalidRecords { get; set; }
        public int AlreadySubmittedRecords { get; set; }
        public List<MeterReadingDto> Results { get; set; } = new List<MeterReadingDto>();
    }
}
