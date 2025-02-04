

namespace CarManufacturer
{


    public class StarUp
    {
        static void Main()
        {

            List<Tire> tires = new List<Tire>();

            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                string[] tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tireInfo.Length / 2; j++)
                {
                    string[] oneTire = 
                }
                
                

                Tire tire = new Tire(year, pressure);
                tires.Add(tire);

            }
            


        }
    }

}