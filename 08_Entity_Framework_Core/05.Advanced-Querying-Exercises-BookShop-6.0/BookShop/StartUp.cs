namespace BookShop
{
    using BookShop.Models.Enums;
    using Castle.Core.Internal;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(dbContext, command));
            //Console.WriteLine(GetGoldenBooks(dbContext));
            //Console.WriteLine(GetBooksByPrice(dbContext));
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(dbContext, year));
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(dbContext, input));
            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(dbContext, date));
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(dbContext, input));
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(dbContext, input));
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(dbContext, input));
            //int input = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(dbContext, input));
            //Console.WriteLine(CountCopiesByAuthor(dbContext));
            //Console.WriteLine(GetTotalProfitByCategory(dbContext));
            //Console.WriteLine(GetMostRecentBooks(dbContext));


        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)  //Problem 2
        {
            bool IsValidCommand = Enum.TryParse(command, true, out AgeRestriction ageRestriction);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    b.Title,

                })
                .OrderBy(t => t.Title)
                .ToList();

            List<string> titles = new List<string>();
            foreach (var book in books)
            {
                titles.Add(book.Title);
            }

            string result = string.Join(Environment.NewLine, titles);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)   // Problem 3
        {
            bool isGoldenType = Enum.TryParse("Gold", false, out EditionType goldType);

            string[] titles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            string result = string.Join(Environment.NewLine, titles);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)  // Problem 4
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40.00m)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year) // Problem 5
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,

                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByCategory(BookShopContext context, string input) // Problem 6
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)  // Problem 7
        {
            StringBuilder sb = new StringBuilder();

            bool isValid = DateTime.TryParseExact(date, "dd-MM-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,

                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)  // Problem 8
        {
            StringBuilder sb = new();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                })
                .ToArray();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input) // Problem 9
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .ToArray();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)  // Problem 10
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                })
                .ToArray();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} ({b.AuthorFirstName} {b.AuthorLastName})");
            }
            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)   // Problem  11
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return books.Length;
        }

        public static string CountCopiesByAuthor(BookShopContext context)  // Problem 12
        {
            StringBuilder sb = new();

            var authors = context.Authors

                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    a.Books,
                    Copies = a.Books.Sum(c => c.Copies)

                })
                .ToArray();

            foreach (var a in authors.OrderByDescending(x => x.Copies))
            {
                sb.AppendLine($"{a.FirstName} {a.LastName} - {a.Copies}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)   // Problem 13
        {
            StringBuilder sb = new();

            var categories = context.Categories

                .Select(c => new
                {
                    c.Name,
                    Total = c.CategoryBooks.Sum(sb => sb.Book.Price * sb.Book.Copies)

                })
                .OrderByDescending(c => c.Total)
                .ThenBy(c => c.Name)
                .ToArray();

            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.Total:f2}");
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetMostRecentBooks(BookShopContext context)   // Problem 14
        {
            StringBuilder sb = new StringBuilder();

            var recentBooksByCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Title,
                            ReleaseYear = b.ReleaseDate.Value.Year
                        })
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            foreach (var category in recentBooksByCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }




    }

}


