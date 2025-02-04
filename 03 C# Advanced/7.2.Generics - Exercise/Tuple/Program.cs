


using Tuple;

string[] personAndAdress = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] personAndBeer = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


CustomTuple<string, string> nameAndAdres = new ($"{personAndAdress[0]} {personAndAdress[1]}", personAndAdress[2]);

CustomTuple<string, int> nameAndBeer = new(personAndBeer[0], int.Parse(personAndBeer[1]));

CustomTuple<int, double> nums = new(int.Parse(numbers[0]), double.Parse(numbers[1]));

Console.WriteLine(nameAndAdres.ToString());
Console.WriteLine(nameAndBeer.ToString());
Console.WriteLine(nums.ToString());