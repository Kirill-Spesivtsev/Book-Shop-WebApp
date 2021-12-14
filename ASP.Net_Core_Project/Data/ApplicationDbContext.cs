using System;
using System.Collections.Generic;
using System.Text;
using ASP.Net_Core_Project.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Core_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
