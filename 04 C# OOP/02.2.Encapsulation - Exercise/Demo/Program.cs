using Demo.Models;

List<Person> list = new List<Person>();
string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
string[] peopleAndMoney = input
Person person = new Person()