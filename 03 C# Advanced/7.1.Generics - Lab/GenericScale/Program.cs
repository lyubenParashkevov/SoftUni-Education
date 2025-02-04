namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            EqualityScale<string> scale = new EqualityScale<string>("2", "2");

            Console.WriteLine(scale.AreEqual());
        }
    }
}