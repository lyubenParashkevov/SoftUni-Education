using System.Text;

namespace _01_01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);
            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "Decode")
                {
                    text = sb.ToString();
                    Console.WriteLine($"The decrypted message is: {text}");
                    break;
                }
                string[] commandsInfo = input.Split('|');
                string command = commandsInfo[0];
                
                if (command == "Move")
                {
                    text = sb.ToString();
                    int numsOfLetters = int.Parse(commandsInfo[1]);
                    string substring = text.Substring(0, numsOfLetters);
                   
                    sb.Remove(0, numsOfLetters);
                    sb.Append(substring);
                }
                else if (command =="Insert")
                {
                    int index = int.Parse(commandsInfo[1]);
                    string value = commandsInfo[2];

                    sb.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = commandsInfo[1];
                    string replacement = commandsInfo[2];

                    sb.Replace(substring, replacement);
                }
            }
            
        }
    }
}