using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }
    public int NumberOfBadges { get; set; }
    public List<Pokemon> ListOfPokemons { get; set; }

    public Trainer(string name, int numberOfBadges, List<Pokemon> listOfPokemons)
    {
        this.Name = name;
        this.NumberOfBadges = numberOfBadges;
        this.ListOfPokemons = new List<Pokemon>();
    }
}