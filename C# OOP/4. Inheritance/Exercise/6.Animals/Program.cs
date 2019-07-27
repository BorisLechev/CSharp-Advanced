using System;

public class Program
{
    public static void Main()
    {
        string animalType = string.Empty;

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ParseAnimal(animalType);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void ParseAnimal(string animalType)
    {
        var input = Console.ReadLine().Split(" ");

        string name = input[0];
        int age = int.Parse(input[1]);
        string gender = null;

        if (input.Length == 3)
        {
            gender = input[2];
        }

        switch (animalType)
        {
            case "Cat":
                Cat cat = new Cat(name, age, gender);
                Console.WriteLine(cat);
                cat.ProduceSound();
                break;
            case "Dog":
                Dog dog = new Dog(name, age, gender);
                Console.WriteLine(dog);
                dog.ProduceSound();
                break;
            case "Frog":
                Frog frog = new Frog(name, age, gender);
                Console.WriteLine(frog);
                frog.ProduceSound();
                break;
            case "Kitten":
                Kitten kitten = new Kitten(name, age, gender);
                Console.WriteLine(kitten);
                kitten.ProduceSound();
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(name, age, gender);
                Console.WriteLine(tomcat);
                tomcat.ProduceSound();
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}