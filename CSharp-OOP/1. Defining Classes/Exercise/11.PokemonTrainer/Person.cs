using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public List<Parents> Parents { get; set; }
    public List<Children> Childrens { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Person(string name,Company company)
    {
        this.Name = name;
        this.Company = company;
    }

    public Person(string name,List<Parents> parents)
    {
        this.Name = name;
        this.Parents = new List<Parents>();
    }

    public Person(string name,List<Children> childrens)
    {
        this.Name = name;
        this.Childrens = new List<Children>();
    }
}