

using System.Runtime.ExceptionServices;

List<string> list = new List<string>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    list.Add(input);

}

int[] indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int first = indices[0];
int second = indices[1];

Swap(first, second, list);

foreach (var i in list)
{
    Console.WriteLine($"{i.GetType()}: {i}");
}



static void Swap<T>(int first, int second, List<T> list)
{
    T curentItem = list[first];
    list[first] = list[second];
    list[second] = curentItem;
}