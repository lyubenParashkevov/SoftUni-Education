namespace _04_03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
               

                string[] heroesInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroesInfo[0];
                int hitPoint = int.Parse(heroesInfo[1]);
                int manaPoints = int.Parse(heroesInfo[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes.Add(heroName, new List<int>());
                }
                heroes[heroName].Add(hitPoint);
                heroes[heroName].Add(manaPoints);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split(" - ");
                string command = commands[0];

                if (command == "CastSpell")
                {
                    string name = commands[1];
                    int MPneeded = int.Parse(commands[2]);
                    string spellName = commands[3];
                    if (heroes[name][1] - MPneeded >= 0)
                    {
                        heroes[name][1] -= MPneeded;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name][1]} MP!");
                    }else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    string name = commands[1];
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];

                    if (heroes[name][0] - damage > 0)
                    {
                        heroes[name][0] -= damage;
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        heroes.Remove(name);
                    }
                }
                else if (command == "Recharge")
                {
                    string name = commands[1];
                    int amount = int.Parse(commands[2]);

                    
                    if (heroes[name][1] + amount > 200)
                    {
                        Console.WriteLine($"{name} recharged for {200 - heroes[name][1]} MP!");
                        heroes[name][1] = 200;
                    }
                    else
                    {
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                        heroes[name][1] += amount;
                    }

                }
                else if (command == "Heal")
                {
                    string name = commands[1];
                    int amount = int.Parse(commands[2]);

                    

                    if (heroes[name][0] + amount > 100)
                    {
                        Console.WriteLine($"{name} healed for {100 - heroes[name][0]} HP!");
                        heroes[name][0] = 100;
                    }
                    else
                    {
                        Console.WriteLine($"{name} healed for {amount} HP!");
                        heroes[name][0] += amount;
                    }

                }
            }

            foreach (var name in heroes )
            {
                Console.WriteLine(name.Key);
                Console.WriteLine($"  HP: {name.Value[0]}");
                Console.WriteLine($"  MP: {name.Value[1]}");
            }
        }
    }
}