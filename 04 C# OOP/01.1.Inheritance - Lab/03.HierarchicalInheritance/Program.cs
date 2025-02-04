

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new();
            Cat cat = new();

            cat.Eat();
            dog.Eat();
            cat.Meow();
            dog.Bark();
        }
    }
}