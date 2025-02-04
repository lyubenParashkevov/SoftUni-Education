

using Demo;

string[] nameAndAddres = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Threeuple<string, string, string> n = new($"{nameAndAddres[0]} {nameAndAddres[1]}", nameAndAddres[2], string.Join(" ",nameAndAddres[3..]));
Console.WriteLine(n.ToString());

string[] nameAndBeers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
 ;
Threeuple<string, int, bool> b = new(nameAndBeers[0], int.Parse(nameAndBeers[1]), nameAndBeers[2] == "drunk");
Console.WriteLine(b.ToString());

string[] intAndDouble = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Threeuple<string, double, string> x = new(intAndDouble[0], double.Parse(intAndDouble[1]), intAndDouble[2]);
Console.WriteLine(x.ToString());