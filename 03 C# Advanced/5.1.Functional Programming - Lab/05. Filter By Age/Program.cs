namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            string filterType = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());
            string formatType = Console.ReadLine();

            Func<Person, bool> filter = GetFilter(filterType, ageToFilter);

            people = people.Where(filter).ToList();

            Action<Person> printer = GetPrinter(formatType);
            foreach (Person person in people)
            {
                printer(person);
            }

            Func<Person, bool> GetFilter(string filterType, int age)
            {
                if (filterType == "older")
                {
                    return person => person.Age >= age;
                }
                else if (filterType == "younger")
                {
                    return person => person.Age < age;
                }
                else
                {
                    return null;
                }
            }   

            Action<Person> GetPrinter(string formatType)
            {
                if (formatType == "name age")
                {
                    return p => Console.WriteLine($"{p.Name}, {p.Age}");

                }

                else if (formatType == "name") 
                {
                    return p => Console.WriteLine($"{p.Name}");
                }

                else if (formatType == "age")
                {
                    return p => Console.WriteLine($"{p.Age}");
                }

                else
                {
                    return null;
                }
            }
        }
    }

    public class Person
    {
        public Person( string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}