using System.Security.Cryptography.X509Certificates;

namespace _Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] nameAndMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productNameAndCost = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < nameAndMoney.Length; i++)
            {
                string[] subNameAndMoney = nameAndMoney[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = subNameAndMoney[0];
                int money = int.Parse(subNameAndMoney[1]);

                Person person = new Person(name, money, new List<string>());
                persons.Add(person);
            }

            for (int i = 0; i < productNameAndCost.Length; i++)
            {
                string[] subProductNameAndCost = productNameAndCost[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string productName = subProductNameAndCost[0];
                int cost = int.Parse(subProductNameAndCost[1]);

                Product product = new Product(productName, cost);
                products.Add(product);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "END")
                {
                    break;
                }
                string name = commands[0];
                string productName = commands[1];

                foreach (Person person in persons.Where(p => p.Name == name))
                {
                    foreach (Product product in products.Where(x => x.ProductName == productName))
                    {
                        if (person.Money >= product.Cost)
                        {
                            person.Money -= product.Cost;
                            person.ProductsBought.Add(product.ProductName);
                            Console.WriteLine($"{person.Name} bought {product.ProductName}");
                        }
                        else
                        {
                            Console.WriteLine($"{person.Name} can't afford {product.ProductName}");
                        }
                    }
                }
            }

            foreach (Person person in persons)
            {
                if (person.ProductsBought.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }

                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.ProductsBought)}");
                }
            }
        }


    }

    public class Product
    {
        public Product(string productName, int cost)
        {
            this.ProductName = productName;
            this.Cost = cost;
        }

        public string ProductName { get; set; }
        public int Cost { get; set; }
    }

    public class Person
    {
        public Person(string name, int money, List<string> productsBought)
        {
            this.Name = name;
            this.Money = money;
            this.ProductsBought = new List<string>();
        }

        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> ProductsBought { get; set; }
    }

}