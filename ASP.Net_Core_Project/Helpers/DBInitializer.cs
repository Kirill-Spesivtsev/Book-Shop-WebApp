using ASP.Net_Core_Project.Data;
using ASP.Net_Core_Project.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Helpers
{
    public static class DBInitializer
    {
        public static async Task DBInit(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                };
                await roleManager.CreateAsync(roleAdmin);
            }
            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@gmail.com",
                    UserName = "user@gmail.com"
                };
                await userManager.CreateAsync(user, "userpass");
            }
            if (!context.Users.Any())
            {
                var admin = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com"
                };
                await userManager.CreateAsync(admin, "adminpass");
                admin = await userManager.FindByEmailAsync("admin@gmail.com");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.BookAuthors.Any())
            {
                context.BookAuthors.AddRange(
                    new List<BookAuthor>
                    {
                        new BookAuthor{AuthorPenName = "Стивен Кинг" },
                        new BookAuthor{AuthorPenName = "Дж. К. Роулинг" },
                        new BookAuthor{AuthorPenName = "Дж. Р. Толкин" },
                        new BookAuthor{AuthorPenName = "Уильям Шекспир" }
                    });
                await context.SaveChangesAsync();
            }
            if (!context.BookGenres.Any())
            {
                context.BookGenres.AddRange(
                    new List<BookGenre>
                    {
                        new BookGenre{GenreName = "Детектив"},
                        new BookGenre{GenreName = "Фантастика"},
                        new BookGenre{GenreName = "Фэнтези"},
                        new BookGenre{GenreName = "Ужасы"},
                        new BookGenre{GenreName = "Романтика"},
                        new BookGenre{GenreName = "Комедия"},
                        new BookGenre{GenreName = "Трагедия"},
                        new BookGenre{GenreName = "Драма"},
                        new BookGenre{GenreName = "Историческая литература"},
                        new BookGenre{GenreName = "Научная литература"},
                        new BookGenre{GenreName = "Религиозная литература"}
                    });
                await context.SaveChangesAsync();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new List<Book>
                    {
                        new Book{AuthorId = 1, GenreId = 4, Pages = 1248, Price = 31, Title = "Оно", ImageName = "it.jpg", Description = "В маленьком провинциальном городке Дерри много лет назад семерым подросткам пришлось столкнуться с кромешным ужасом – живым воплощением ада..."},
                        new Book{AuthorId = 1, GenreId = 4, Pages = 544, Price = 26, Title = "Сияние", ImageName = "shining.jpg", Description = "Из роскошного отеля выезжают на зиму все... кроме призраков, и самые невообразимые кошмары становятся явью..."},
                        new Book{AuthorId = 1, GenreId = 4, Pages = 416, Price = 28, Title = "Кладбище домашних животных", ImageName = "pet_sematary.jpg", Description = "Казалось бы, семейство Крид — это настоящее воплощение американской мечты..."},
                        new Book{AuthorId = 4, GenreId = 7, Pages = 173, Price = 17, Title = "Ромео и Джульетта", ImageName = "romeo_and_juliet.png", Description = "Ромео и Джульетте было суждено примирить два враждующих дома, но, увы..."},
                        new Book{AuthorId = 4, GenreId = 7, Pages = 192, Price = 18, Title = "Гамлет", ImageName = "hamlet.jpg", Description = "Трагическая истоория о Гамлете, приинце датском..."},
                        new Book{AuthorId = 3, GenreId = 3, Pages = 1707, Price = 99.9, Title = "Властелин Колец", ImageName = "lord_of_the_rings.jpg", Description = "Там, в Среднеземье, в стране, управляемой советом волшебников, где..."},
                        new Book{AuthorId = 3, GenreId = 3, Pages = 923, Price = 64.25, Title = "Хоббит. Туда и обратно", ImageName = "hobbit.jpg", Description = "Первое знакомство с прекрасным миром Средиземья, населенного эльфами, магами, гномами, драконами и другими..."},
                        new Book{AuthorId = 2, GenreId = 3, Pages = 432, Price = 38, Title = "Гарри Поттер и философский камень", ImageName = "hp_philosopher's_stone.jpg", Description = "Жизнь десятилетнего Гарри Поттера нельзя назвать сладкой..."},
                        new Book{AuthorId = 2, GenreId = 3, Pages = 457, Price = 43.8, Title = "Гарри Поттер и тайная комната", ImageName = "hp_chamber_of_secrets.jpg", Description = "Гарри Поттер переходит на второй курс Школы чародейства и волшебства Хогвартс..."},
                        new Book{AuthorId = 2, GenreId = 3, Pages = 515, Price = 41.2, Title = "Гарри Поттер и узник азкабана", ImageName = "hp_prisoner_of_azkaban.jpg", Description = "В третьей части истории о юном волшебнике, полюбившиеся всем герои..."}
                    });
                await context.SaveChangesAsync();
            }


        }
    }
}
