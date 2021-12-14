using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
        public string MimeType { get; set; }
        public int GenreId { get; set; }
        public BookGenre Genre { get; set; }

        public int AuthorId { get; set; }
        public BookAuthor Author { get; set; }

    }
}
