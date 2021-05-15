using System;

namespace BabyLog.Models
{
    public class AuditedEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedAtUtc { get; set; }
        public int ModifiedByUserId { get; set; }
    }
}
