using System.ComponentModel.DataAnnotations;

namespace _02._1._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articles = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string title = articles[0];
            string content = articles[1];
            string author = articles[2];

            Article article = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commands[0];
                string newValue = commands[1];

                if (command == "Edit")
                {
                    article.Edit(newValue);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(newValue);
                }
                else if (command == "Rename")
                {
                    article.Rename(newValue);
                }

            }

            article.ToString();
            Console.WriteLine(article);
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }

}