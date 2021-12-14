using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net_Core_Project.Models;

namespace ASP.Net_Core_Project.Components
{

    public class MenuViewComponent : ViewComponent
    {
        List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 3"},
            new MenuItem{ Controller="Product", Action="Index", Text="Каталог"},
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];
            foreach (var item in _menuItems)
            {

                var _matchController = controller?.Equals(item.Controller) ?? false;

                var _matchArea = area?.Equals(item.Area) ?? false;

                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
}

