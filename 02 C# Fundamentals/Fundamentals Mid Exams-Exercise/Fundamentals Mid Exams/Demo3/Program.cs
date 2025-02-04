namespace Demo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            string[] citiesInfo = Console.ReadLine().Split("||");

            while (citiesInfo[0] != "Sail")
            {
                string cityName = citiesInfo[0];
                int population = int.Parse(citiesInfo[1]);
                int gold = int.Parse(citiesInfo[2]);

                City city = new City(cityName, population, gold);
                foreach (City c in cities)
                {
                    if (cities.Contains(c))
                    {
                        city.Population += population;
                        city.Gold += gold;
                    }
                    else
                    {
                        cities.Add(city);
                    }
                }

            }
            citiesInfo = Console.ReadLine().Split("||");

            string[] commands = Console.ReadLine().Split("=>");
            string command = commands[0];

            while (command != "End")
            {
                if (command == "Plunder")
                {
                    string cityToAttack = commands[1];
                    int peopleToKill = int.Parse(commands[2]);
                    int goldToSteal = int.Parse(commands[3]);

                    foreach (City c in cities.Where(c => c.Name == cityToAttack))
                    {
                        c.Population -= peopleToKill;
                        c.Gold -= goldToSteal;
                        if (c.Population == 0 || c.Gold == 0)
                        {
                            Console.WriteLine($"{c.Name} has been wiped off the map!");
                            cities.Remove(c);
                        }
                        else
                        {
                            Console.WriteLine($"{c.Name} plundered! {goldToSteal} gold stolen, {peopleToKill} citizens killed.");
                        }
                    }

                }
                else if (command == "Prosper")
                {

                    string cityToProsper = commands[1];
                    int goldToAdd = int.Parse(commands[2]);
                    if (goldToAdd < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }

                    else
                    {
                        foreach (City c in cities.Where(c => c.Name == cityToProsper))
                        {
                            c.Gold += goldToAdd;
                            Console.WriteLine($"{goldToAdd} gold added to the city treasury. {c.Name} now has {c.Gold} gold.");
                        }
                    }
                }
            }
            command = Console.ReadLine();

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City c in cities)
                {
                    Console.WriteLine($"{c.Name} -> Population: {c.Population} citizens, Gold: {c.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

     public class City
     {
         public City(string cityName, int population, int gold)
         {
             this.Name = cityName;
             this.Population = population;
             this.Gold = gold;
         }
     
         public string Name { get; set; }
         public int Population { get; set; }
         public int Gold { get; set; }
     }
}
