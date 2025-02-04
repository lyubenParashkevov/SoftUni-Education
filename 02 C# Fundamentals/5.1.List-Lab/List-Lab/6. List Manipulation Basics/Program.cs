namespace _6._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            

            while(true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] token = input.Split();

                if (token[0] == "Add")
                {
                    numbers.Add(int.Parse(token[1]));
                }
                else if (token[0] == "Remove")
                {
                    numbers.Remove(int.Parse(token[1]));
                }
                else if (token[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(token[1]));
                }
                else if (token[0] == "Insert")
                {
                    numbers.Insert(int.Parse(token[2]), int.Parse(token[1]));
                }
            }
            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}