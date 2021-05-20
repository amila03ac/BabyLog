using System;
using System.ComponentModel.DataAnnotations;

namespace BabyLog.Models
{
    public class Event : AuditedEntityBase
    {
        public int EventTypeId { get; set; }
        public int BabyId { get; set; }
        public DateTime OccuredAtUtc { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }

        public EventType EventType { get; set; }
        public Baby Baby { get; set; }
    }
}
