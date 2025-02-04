using DefiningClasses;

public class StartUp
{
    static void Main()
    {
        Family family = new Family();
  
        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);

            Person person = new Person(name, age);

            family.AddMember(person);
        }

        family.GetOver30Members();
    }
}






