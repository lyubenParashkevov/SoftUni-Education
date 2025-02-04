
using PokemonTrainer;
using System.Runtime.CompilerServices;


List<Trainer> trainers = new List<Trainer>();

while (true)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (input[0] == "Tournament")
    {
        break;
    }
    int bagesCount = 0;
    string trainerName = input[0];
    string pokemonName = input[1];
    string element = input[2];
    int health = int.Parse(input[3]);


    Pokemon pokemon = new Pokemon(pokemonName, element, health);

    Trainer trainer = trainers.SingleOrDefault(trainer => trainer.Name == trainerName);

    if (trainer == null)
    {
        trainer = new Trainer(trainerName);
        trainer.Pokemons.Add(pokemon);
        trainers.Add(trainer);
    }
    else
    {
        trainer.Pokemons.Add(pokemon);
    }

}

while (true)
{
    string command = Console.ReadLine().Trim();

    if (command == "End")
    {
        break;
    }

    foreach (Trainer trainer in trainers)
    {
        trainer.CheckPokemon(command);     
    }
}

foreach (Trainer trainer in trainers.OrderByDescending(t => t.BagesCount))
{
    Console.WriteLine($"{trainer.Name} {trainer.BagesCount} {trainer.Pokemons.Count}");
}