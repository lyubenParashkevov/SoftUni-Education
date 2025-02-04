using System.Security.Cryptography.X509Certificates;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string username in usernames.Where(x => x.Length >= 3 && x.Length <= 16))
            {
                bool isValid = true;
                foreach (char ch in username)
                {

                    if (!Char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                    {
                        isValid = false;
                    }

                }
                if (isValid)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}