

using _03.ShoppingSpree.Models;
using System.Diagnostics.Metrics;

List<Person> people = new List<Person>();

List<Product> products = new List<Product>();


try
{

    string[] peopleAndMoney = Console.ReadLine()
    .Split(';', StringSplitOptions.RemoveEmptyEntries);

    foreach (var item in peopleAndMoney)
    {
        string[] personWithMoney = item.Split('=', StringSplitOptions.RemoveEmptyEntries);

        //Person person = new(personWithMoney[0], decimal.Parse(personWithMoney[1]));
        string personName = personWithMoney[0];
        decimal pesonMoney = decimal.Parse(personWithMoney[1]);
        Person person = new Person(personName, pesonMoney);
        people.Add(person);
    }

    string[] productsAndCost = Console.ReadLine()
        .Split(';', StringSplitOptions.RemoveEmptyEntries);

    foreach (var item in productsAndCost)
    {
        string[] productWithCost = item.Split('=', StringSplitOptions.RemoveEmptyEntries);

        Product product = new(productWithCost[0], decimal.Parse(productWithCost[1]));

        products.Add(product);
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

string input;
while((input = Console.ReadLine()) != "END")
{
    string[] nameAndProduct = input
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string name = nameAndProduct[0];
    string productToBuy = nameAndProduct[1];

    Person person = people.FirstOrDefault(p => p.Name == name);
    Product product = products.FirstOrDefault(p => p.Name == productToBuy);
    if (person is not null && product is not null)
    {
        Console.WriteLine(person.AddProduct(product));
    }
    

}

foreach (Person person in people)
{
    Console.WriteLine(person);
}