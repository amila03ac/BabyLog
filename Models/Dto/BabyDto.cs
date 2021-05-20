using System;

namespace BabyLog.Models.Dto
{
    public class BabyDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
