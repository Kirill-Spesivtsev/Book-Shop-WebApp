using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ASP.Net_Core_Project.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ASP.Net_Core_Project.Entities;
using ASP.Net_Core_Project.ViewModels;

namespace ASP.Net_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private List<ListDemo> _list;
        public IFormFile avatar { get; set; }

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _list = new List<ListDemo>
            {
                new ListDemo { ListItemValue = 1, ListItemText = "Item 1" },
                new ListDemo { ListItemValue = 2, ListItemText = "Item 2" },
                new ListDemo { ListItemValue = 3, ListItemText = "Item 3" },
                new ListDemo { ListItemValue = 4, ListItemText = "Item 4" }
            };

        }
        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 6";
            ViewData["ListData"] = new SelectList(_list, "ListItemValue", "ListItemText");
            return View("Index");
        }

        public async Task<IActionResult> Special()
        {
            if (avatar != null)
            {
                var user = await _userManager.GetUserAsync(User);
                user.AvatarImage = new byte[(int)avatar.Length];
                await avatar.OpenReadStream().ReadAsync(user.AvatarImage, 0, (int)avatar.Length);
                await _userManager.UpdateAsync(user);
                
            }
            else
            {
                _logger.LogInformation("No avatar was selected");
            }
            return View("Index");
        }



    }
}
