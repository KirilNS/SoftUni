namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                

                var result = GetGoldenBooks(db);

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
    }
}
