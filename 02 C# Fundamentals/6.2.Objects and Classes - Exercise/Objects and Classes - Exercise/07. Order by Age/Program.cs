namespace _07._Order_by_Age5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> list = new List<People>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] peopleInfoData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = peopleInfoData[0];
                string id = peopleInfoData[1];
                int age = int.Parse(peopleInfoData[2]);

                People people = new People
                {
                    Name = name,
                    ID = id,
                    Age = age,
                };
                list.Add(people);

            }
            foreach (People people in list.OrderBy(people => people.Age))
            {
               people.PrintInfo();
            }
        }

        public class People
        {

            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public void PrintInfo()
            {
                Console.WriteLine($"{Name} with ID: {ID} is {Age} years old.");
            }
        }
    }
}