namespace _02._Tax_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> vehicles = Console.ReadLine().Split(">>", StringSplitOptions.RemoveEmptyEntries).ToList();

            int initialTax = 0;
            int every3000kmExtraTax = 0;
            double familyTaxToPay = 0;
            double heavyDutyTaxToPay = 0;
            double sportTaxToPay = 0;
            double fullTaxesColected = 0;
            for (int i = 0; i < vehicles.Count; i++)
            {
                List<string> carTypes = vehicles[i].Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
                string carType = carTypes[0];
                int yearsToPay = int.Parse(carTypes[1]);
                int kmTraveled = int.Parse(carTypes[2]);
                

                if (carType == "family")
                {
                    initialTax = 50;
                    every3000kmExtraTax = kmTraveled / 3000 * 12;
                    familyTaxToPay = every3000kmExtraTax + initialTax - yearsToPay * 5;
                    Console.WriteLine($"A {carType} car will pay {familyTaxToPay:f2} euros in taxes.");
                    fullTaxesColected += familyTaxToPay;
                }
                else if (carType == "heavyDuty")
                {
                    initialTax = 80;
                    every3000kmExtraTax = kmTraveled / 9000 * 14;
                    heavyDutyTaxToPay = every3000kmExtraTax + initialTax - yearsToPay * 8;
                    Console.WriteLine($"A {carType} car will pay {heavyDutyTaxToPay:f2} euros in taxes.");
                    fullTaxesColected += heavyDutyTaxToPay;
                } 
                else if (carType == "sports")
                {
                    initialTax = 100;
                    every3000kmExtraTax = kmTraveled / 2000 * 18;
                    sportTaxToPay = every3000kmExtraTax + initialTax - yearsToPay * 9;
                    Console.WriteLine($"A {carType} car will pay {sportTaxToPay:f2} euros in taxes.");
                    fullTaxesColected += sportTaxToPay;
                         
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {fullTaxesColected:f2} euros in taxes.");
        }
    }
}