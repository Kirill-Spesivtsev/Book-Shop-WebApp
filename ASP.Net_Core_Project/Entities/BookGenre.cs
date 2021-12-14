using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Entities
{
    public class BookGenre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}
