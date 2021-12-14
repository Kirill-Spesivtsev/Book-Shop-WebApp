using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net_Core_Project.Data;
using ASP.Net_Core_Project.Extensions;
using ASP.Net_Core_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.Net_Core_Project.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private string cartKey = "cart";
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var _cart = HttpContext.Session.Get<Cart>(cartKey);
            return View(_cart.Items.Values);
        }
        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            var _cart = HttpContext.Session.Get<Cart>(cartKey);
            var item = _context.Books.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
                HttpContext.Session.Set<Cart>(cartKey, _cart);
            }
            return Redirect(returnUrl);
        }
    }
}
