namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string substring = string.Empty;

            Stack<int> stack = new Stack<int>();
            int startIndex = 0;


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    startIndex = stack.Pop();
                    int endIndex = i;
                    substring = input.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(substring);

                }





            }

        }
    }
}