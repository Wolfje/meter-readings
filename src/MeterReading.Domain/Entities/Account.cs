using MeterReading.Domain.Common;

namespace MeterReading.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual List<Reading> Readings { get; set; }

    }
}
