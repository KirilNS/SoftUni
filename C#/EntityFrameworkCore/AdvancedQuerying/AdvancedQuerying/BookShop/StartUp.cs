namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                string input = Console.ReadLine();

                var result = GetBooksByCategory(db,input);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var age = Enum.Parse<AgeRestriction>(command, true);
            var bookTitle = context.Books.Where(x => x.AgeRestriction == age)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in bookTitle)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksTitles = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType==EditionType.Gold)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x=>x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in booksTitles)
            {
                sb.AppendLine($"{item.Title}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x=>x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} - ${item.Price:F2}");
            }

            return sb.ToString().TrimEnd();

        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title}");
            }

            return sb.ToString().TrimEnd();

        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            List<string> items = input
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> booksTitles = new List<string>();

            foreach (var item in items)
            {
                var books = context.Books
                    .Where(b => b.BookCategories
                    .Any(c => c.Category.Name.ToLower() == item.ToLower()))
                    .Select(b => new
                    {
                        b.Title
                    })
                    .ToList();

                foreach (var book in books)
                {
                    booksTitles.Add(book.Title);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var title in booksTitles.OrderBy(x => x))
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
