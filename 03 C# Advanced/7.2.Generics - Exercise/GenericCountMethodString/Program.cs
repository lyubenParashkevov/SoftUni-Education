
using GenericCountMethodString;

Box<string> box = new Box<string>();
     

List<string> list = new List<string>(); 

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    list.Add(input);
}

string wordToCompare = Console.ReadLine();

Console.WriteLine(box.Count(list, wordToCompare));
