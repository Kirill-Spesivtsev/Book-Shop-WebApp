using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Entities
{
    public class BookAuthor
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorPenName { get; set; }

        public List<Book> Books { get; set; }
    }
}
