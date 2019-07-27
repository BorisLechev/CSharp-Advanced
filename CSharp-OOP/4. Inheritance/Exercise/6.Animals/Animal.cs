using System;

public class Animal : ISoundProducable
{
    private string name;

    private int age;

    private string gender;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    public string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public virtual void ProduceSound()
    {
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine} {this.Name} {this.Age} {this.Gender}";
    }
}