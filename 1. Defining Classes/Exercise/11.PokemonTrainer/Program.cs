using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "Tournament")
        {
            var splittedInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string trainerName = splittedInput[0];
            string pokemonName = splittedInput[1];
            string pokemonElement = splittedInput[2];
            double pokemonHealth = double.Parse(splittedInput[3]);

            if (!trainers.Any(t => t.Name == trainerName))
            {
                trainers.Add(new Trainer(trainerName, 0, new List<Pokemon>()));

                Trainer trainer = trainers.First(t => t.Name == trainerName);

                trainer.ListOfPokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            else
            {
                Trainer existingTrainer = trainers.First(t => t.Name == trainerName);
                existingTrainer.ListOfPokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }
        }

        string inputAfterTournament = string.Empty;

        while ((inputAfterTournament = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.ListOfPokemons.Any(p => p.Element == inputAfterTournament))
                {
                    trainer.NumberOfBadges++;
                }

                else
                {
                    trainer.ListOfPokemons.ForEach(p => p.Health -= 10);

                    if (trainer.ListOfPokemons.Any(p => p.Health <= 0))
                    {
                        trainer.ListOfPokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.ListOfPokemons.Count}");
        }
    }
}