namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> courseAndPasswords = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }

                string[] courseAndPasswordToAdd = input.Split(':',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = courseAndPasswordToAdd[0];
                string pssword = courseAndPasswordToAdd[1];

                if (!courseAndPasswords.ContainsKey(courseName))
                {
                    courseAndPasswords.Add(courseName, pssword);
                }
            }

            while (true)
            {
                string input = Console.ReadLine() ;
                if (input == "end of submissions")
                {
                    break;
                }
                string[] fullUsersData = input.Split("=>",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string newCourseName = fullUsersData[0];
                string newPassword = fullUsersData[1];
                string student = fullUsersData[2];
                int points = int.Parse(fullUsersData[3]);

                if (!courseAndPasswords.ContainsKey (newCourseName))
                {
                    continue;
                }
                if (courseAndPasswords[newCourseName] != newPassword)
                {
                    continue;
                }
                
            }
        }
    }
}