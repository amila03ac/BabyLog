using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BabyLog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Baby> Babies { get; set; }
    }
}
