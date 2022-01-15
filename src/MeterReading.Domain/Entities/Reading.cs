using MeterReading.Domain.Common;

namespace MeterReading.Domain.Entities
{
    public class Reading : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime ReadingDateTime { get; set; }
        public string ReadingValue { get; set; }

        public Account Account { get; set; }
    }
}
