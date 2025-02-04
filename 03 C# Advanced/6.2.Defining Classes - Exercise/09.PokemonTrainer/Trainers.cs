using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    internal class Trainer
    {

        public Trainer(string trainerName)
        {
            Name = trainerName;
            
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int BagesCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }


        public void CheckPokemon(string command)
        {
            if (Pokemons.Any(p => p.Element == command))
            {
                BagesCount++;
            }
            else
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemons[i].Health -= 10;

                    if (Pokemons[i].Health <= 0)
                    {
                        Pokemons.Remove(Pokemons[i]);
                        i--;
                    }
                }
            }
        }
    }
}
