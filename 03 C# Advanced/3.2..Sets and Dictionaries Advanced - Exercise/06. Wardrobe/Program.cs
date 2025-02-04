using System.ComponentModel;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] clothesInfo = Console.ReadLine().Split(" -> ");
                string colour = clothesInfo[0];

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                string[] clothes = clothesInfo[1].Split(',');

                for (int j = 0; j < clothes.Length; j++)
                {
                    string cloth = clothes[j];

                    if (!wardrobe[colour].ContainsKey(cloth))
                    {
                        wardrobe[colour].Add(cloth, 0);
                    }
                    wardrobe[colour][cloth]++;
                }
            }

            string[] searchedClothAndColour = Console.ReadLine().Split();
            string searchedColour = searchedClothAndColour[0];
            string searchedCloth = searchedClothAndColour[1];
            string found = "(found!)";

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var c in item.Value)
                {
                    if (item.Key == searchedColour && c.Key == searchedCloth)
                    {
                        Console.WriteLine($"* {c.Key} - {c.Value} {found}");
                    }

                    else
                    {
                        Console.WriteLine($"* {c.Key} - {c.Value}");
                    }
                }
            }

        }
    }
}