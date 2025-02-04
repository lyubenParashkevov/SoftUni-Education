

using Demo;

namespace GenericArrayCreator;
public class StartUp
{
    static void Main(string[] args)
    {
        EqualityScale<int> scale = new(4, 2);
        Console.WriteLine(scale.AreEqual());
    }
}