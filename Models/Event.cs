using System;

namespace BabyLog.Models
{
    public class Event : AuditedEntityBase
    {
        public int EventTypeId { get; set; }
        public int BabyId { get; set; }
        public DateTime OccuredAtUtc { get; set; }

        public EventType EventType{ get; set; }
        public Baby Baby { get; set; }
    }
}
