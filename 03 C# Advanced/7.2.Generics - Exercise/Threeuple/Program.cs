

using Threeuple;

string[] personAndAdress = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] personAndBeer = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] personAndBank = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Threeuple<string, string, string> nameAndAdress = new($"{personAndAdress[0]} {personAndAdress[1]}", personAndAdress[2], string.Join(" ",personAndAdress[3..]));

Threeuple<string, int, bool> nameAndBeer = new(personAndBeer[0], int.Parse(personAndBeer[1]), personAndBeer[2] == "drunk");

Threeuple<string, double, string> nameAndBank = new(personAndBank[0], double.Parse(personAndBank[1]), personAndBank[2]);

Console.WriteLine(nameAndAdress.ToString());
Console.WriteLine(nameAndBeer.ToString());
Console.WriteLine(nameAndBank.ToString());
