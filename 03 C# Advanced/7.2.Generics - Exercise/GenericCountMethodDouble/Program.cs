using GenericCountMethodDouble;

Box<double> box = new Box<double>();


List<double> list = new List<double>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    double input = double.Parse(Console.ReadLine());

    list.Add(input);
}

double wordToCompare = double.Parse(Console.ReadLine());

Console.WriteLine(box.Count(list, wordToCompare));