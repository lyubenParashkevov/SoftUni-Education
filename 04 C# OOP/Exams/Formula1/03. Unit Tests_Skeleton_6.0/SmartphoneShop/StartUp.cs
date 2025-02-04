namespace SmartphoneShop
{
    public class StartUp
    {
        static void Main()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(1);
            Smartphone smartphone1 = new Smartphone("LG", 40);

            shop.Add(smartphone);
            shop.Add(smartphone1);
        }
    }
}
