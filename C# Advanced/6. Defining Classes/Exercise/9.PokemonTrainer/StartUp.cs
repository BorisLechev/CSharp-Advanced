using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = String.Empty;
            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens =
                    input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                trainers = ParseTrainer(trainers, tokens);
            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                trainers = ExecuteCommand(trainers, command);
            }

            trainers
                .OrderByDescending(t => t.NumberOfBadges)
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemons.Count}"));
        }

        private static List<Trainer> ParseTrainer(List<Trainer> trainers, string[] tokens)
        {
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }

            trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

            return trainers;
        }

        private static List<Trainer> ExecuteCommand(List<Trainer> trainers, string command)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.NumberOfBadges += 1;
                }

                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        var pokemon = trainer.Pokemons[i];
                        pokemon.Health -= 10;

                        if (pokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(pokemon);
                        }
                    }
                }
            }

            return trainers;
        }
    }
}
