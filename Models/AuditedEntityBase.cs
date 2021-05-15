using System;
using System.ComponentModel.DataAnnotations;

namespace BabyLog.Models
{
    public class AuditedEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        [MaxLength(450)]
        public string CreatedByUserId { get; set; }
        public DateTime LastUpdatedAtUtc { get; set; }
        [MaxLength(450)]
        public string LastUpdatedByUserId { get; set; }
    }
}
