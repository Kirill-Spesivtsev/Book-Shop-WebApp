using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.Net_Core_Project.Data;
using ASP.Net_Core_Project.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ASP.Net_Core_Project.Areas.Admin.Pages
{
    [Authorize(Roles = "admin")]
    public class DetailsModel : PageModel
    {
        private readonly ASP.Net_Core_Project.Data.ApplicationDbContext _context;

        public DetailsModel(ASP.Net_Core_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
