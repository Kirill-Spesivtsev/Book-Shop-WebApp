using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net_Core_Project.Data;
using ASP.Net_Core_Project.Entities;
using ASP.Net_Core_Project.Extensions;
using ASP.Net_Core_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.Net_Core_Project.Controllers
{
    public class ProductController : Controller
    {

        private readonly ILogger<ProductController> _logger;
        ApplicationDbContext _context;

        private int _pageSize;


        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _context = context;
            logger = _logger;
            _pageSize = 4;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNumber}")]
        public IActionResult Index(int? genre, int pageNumber = 1)
        {
            ViewData["Genres"] = _context.BookGenres;
            ViewData["CurrentGenre"] = genre ?? 0;
            ViewData["PageSize"] = _pageSize;

            var booksFiltered = _context.Books
                .Where(d => !genre.HasValue || d.GenreId == genre.Value);

            var model = ListViewModel<Book>.GetModel(booksFiltered, pageNumber, _pageSize);

            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

        public IActionResult UserProducts()
        {
            return View();
        }

        private void InitData() 
        {
            

            new List<BookAuthor>
            {
                new BookAuthor{AuthorId = 1, AuthorPenName = "Стивен Кинг" },
                new BookAuthor{AuthorId = 2, AuthorPenName = "Дж. К. Роулинг" },
                new BookAuthor{AuthorId = 3, AuthorPenName = "Дж. Р. Толкин" },
                new BookAuthor{AuthorId = 4, AuthorPenName = "Уильям Шекспир" }
            };

            new List<BookGenre>
            {
                new BookGenre{GenreId = 1, GenreName = "Детектив"},
                new BookGenre{GenreId = 2, GenreName = "Фантастика"},
                new BookGenre{GenreId = 3, GenreName = "Фэнтези"},
                new BookGenre{GenreId = 4, GenreName = "Ужасы"},
                new BookGenre{GenreId = 5, GenreName = "Романтика"},
                new BookGenre{GenreId = 6, GenreName = "Комедия"},
                new BookGenre{GenreId = 7, GenreName = "Трагедия"},
                new BookGenre{GenreId = 8, GenreName = "Драма"},
                new BookGenre{GenreId = 9, GenreName = "Историческая литература"},
                new BookGenre{GenreId = 10, GenreName = "Научная литература"},
                new BookGenre{GenreId = 11, GenreName = "Религиозная литература"}
            };

            new List<Book>
            {
                new Book{BookId = 1, AuthorId = 1, GenreId = 4, Pages = 1248, Title = "Оно", ImageName = "it.jpg", Description = "В маленьком провинциальном городке Дерри много лет назад семерым подросткам пришлось столкнуться с кромешным ужасом – живым воплощением ада..."},
                new Book{BookId = 2, AuthorId = 1, GenreId = 4, Pages = 544, Title = "Сияние", ImageName = "shining.jpg", Description = "Из роскошного отеля выезжают на зиму все... кроме призраков, и самые невообразимые кошмары становятся явью..."},
                new Book{BookId = 3, AuthorId = 1, GenreId = 4, Pages = 416, Title = "Кладбище домашних животных", ImageName = "pet_sematary.jpg", Description = "Казалось бы, семейство Крид — это настоящее воплощение американской мечты..."},
                new Book{BookId = 4, AuthorId = 4, GenreId = 7, Pages = 173, Title = "Ромео и Джульетта", ImageName = "romeo_and_juliet.png", Description = "Ромео и Джульетте было суждено примирить два враждующих дома, но, увы..."},
                new Book{BookId = 5, AuthorId = 4, GenreId = 7, Pages = 192, Title = "Гамлет", ImageName = "hamlet.jpg", Description = "Трагическая истоория о Гамлете, приинце датском..."},
                new Book{BookId = 6, AuthorId = 3, GenreId = 3, Pages = 1707, Title = "Властелин Колец", ImageName = "lord_of_the_rings.jpg", Description = "Там, в Среднеземье, в стране, управляемой советом волшебников, где..."},
                new Book{BookId = 7, AuthorId = 3, GenreId = 3, Pages = 923, Title = "Хоббит. Туда и обратно", ImageName = "hobbit.jpg", Description = "Первое знакомство с прекрасным миром Средиземья, населенного эльфами, магами, гномами, драконами и другими..."},
                new Book{BookId = 8, AuthorId = 2, GenreId = 3, Pages = 432, Title = "Гарри Поттер и философский камень", ImageName = "hp_philosopher's_stone.jpg", Description = "Жизнь десятилетнего Гарри Поттера нельзя назвать сладкой..."},
                new Book{BookId = 9, AuthorId = 2, GenreId = 3, Pages = 457, Title = "Гарри Поттер и тайная комната", ImageName = "hp_chamber_of_secrets.jpg", Description = "Гарри Поттер переходит на второй курс Школы чародейства и волшебства Хогвартс..."},
                new Book{BookId = 10, AuthorId = 2, GenreId = 3, Pages = 515, Title = "Гарри Поттер и узник азкабана", ImageName = "hp_prisoner_of_azkaban.jpg", Description = "В третьей части истории о юном волшебнике, полюбившиеся всем герои..."}
            };
        }
    }
}
