


namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new();
            stack.Push("hello");
            stack.Push("Bye");
            stack.Push("eho");

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new string[] { "a", "s", "l" });

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

        }
    }
}