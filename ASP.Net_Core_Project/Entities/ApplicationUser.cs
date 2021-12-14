using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
