using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net_Core_Project.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ASP.Net_Core_Project.Controllers
{
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;
        public ImageController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.AvatarImage != null) 
            {
                return File(user.AvatarImage, "images/...");
            }
            else
            {
                var avatarPath = "/Images/avatar_default.png";
                return File(_env.WebRootFileProvider.GetFileInfo(avatarPath).CreateReadStream(), "image/...");
            }
        }

            public IActionResult Index()
        {
            return View();
        }
    }
}
