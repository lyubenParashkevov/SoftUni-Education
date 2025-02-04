
using System.Reflection.PortableExecutable;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            string name = "Pesho";
            int age = 23;

            Person person = new Person(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
