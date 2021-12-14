using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Net_Core_Project.Data;
using ASP.Net_Core_Project.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ASP.Net_Core_Project.Areas.Admin.Pages
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

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
            ViewData["AuthorId"] = new SelectList(_context.BookAuthors, "AuthorId", "AuthorPenName");
           ViewData["GenreId"] = new SelectList(_context.BookGenres, "GenreId", "GenreName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                if (Image != null)
                {
                    var fileName = Book.BookId + Path.GetExtension(Image.FileName);
                    Book.ImageName = fileName;
                    var path = Path.Combine(_environment.WebRootPath, "images/products/", fileName);
                    using (var fStream = new FileStream(path, FileMode.Create))
                    {
                        await Image.CopyToAsync(fStream);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
