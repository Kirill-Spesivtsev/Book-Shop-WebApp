using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.ViewModels
{
    public class UserProfileModel
    {
        public IFormFile avatar { get; set; }
    }
}
