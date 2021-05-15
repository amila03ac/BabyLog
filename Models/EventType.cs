using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BabyLog.Models
{
    public class EventType : AuditedEntityBase
    {
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string ShortCode { get; set; }
        [MaxLength(6)]
        public string ColorCode { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
