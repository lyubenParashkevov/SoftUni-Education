
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    string namePatern = "@[A-Za-z]*\\|";
    string agePatern = "#[0-9]*\\*";
    Regex regex = new Regex(namePatern);

    string name = regex.Match(input).Value;
    name = name.Substring(1, name.Length - 2);

    Regex regex1 = new Regex(agePatern);
    string age = regex1.Match(input).Value;
    age = age.Substring(1, age.Length - 2);
    

    Console.WriteLine($"{name} is {age} years old.");
}