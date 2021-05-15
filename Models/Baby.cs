using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyLog.Models
{
    public class Baby : AuditedEntityBase
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public DateTime Birthday { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
